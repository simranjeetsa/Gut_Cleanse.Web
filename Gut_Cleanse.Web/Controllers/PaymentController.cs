﻿using Azure.Core;
using Gut_Cleanse.Common.Enums;
using Gut_Cleanse.Data;
using Gut_Cleanse.Data.Tables;
using Gut_Cleanse.Model;
using Gut_Cleanse.Service.CommonService;
using Gut_Cleanse.Service.PaymentService;
using Gut_Cleanse.Service.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;


namespace Gut_Cleanse.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ICommonService _commonService;
        private readonly IPaymentService _paymentService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        private readonly RoleManager<IdentityRole> _roleManager;
        public PaymentController(IConfiguration configuration, ICommonService commonService, IPaymentService paymentService, UserManager<ApplicationUser> userManager, IUserService userService, RoleManager<IdentityRole> roleManager)
        {
            _configuration = configuration;
            _commonService = commonService;
            _paymentService = paymentService;
            _userManager = userManager;
            _userService = userService;
            _roleManager = roleManager;
        }

        public IActionResult Index(int id)
        {
            var model = _commonService.GetPaymentModel(id);
            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> CreateOrder(PaymentInitiateModel _requestData)
        {
            var currentUser = _commonService.GetCurrentUserInfo();
            var keyId = _configuration.GetValue<string>("RazorPay_KeyId");
            var secretKey = _configuration.GetValue<string>("RazorPay_SecretKey");
            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient(keyId, secretKey);
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", _requestData.Amount * 100);  // Amount will in paise
            options.Add("receipt", Guid.NewGuid().ToString());
            options.Add("currency", "INR");
            options.Add("payment_capture", "0");

            Razorpay.Api.Order orderResponse = client.Order.Create(options);
            string orderId = orderResponse["id"].ToString();

            var user = _userService.GetUserByEmail(_requestData.Email);
            var userId = 0;
            if (user != null && user.Id != 0)
            {
                userId = user.Id;
            }
            else
            {
                try
                {
                    var User = new ApplicationUser { Email = _requestData.Email, UserName = _requestData.Email };
                    var result = await _userManager.CreateAsync(User, "Admin@123");

                    if (result.Succeeded)
                    {
                        var aspNetUser = await _userManager.FindByEmailAsync(_requestData.Email);

                        await _userManager.AddToRoleAsync(aspNetUser, "Customer");
                        if (aspNetUser != null)
                        {
                            var newUser = new UserModel()
                            {
                                Email = _requestData.Email,
                                AspNetUserId = aspNetUser.Id,
                                FirstName = _requestData.FirstName,
                                LastName = _requestData.LastName,
                                IsDeleted = false,
                                IsLocked = true,
                            };

                            _userService.AddUser(newUser);
                        }

                        user = _userService.GetUserByEmail(_requestData.Email);
                        userId = user?.Id ?? 0;
                    }
                }
                catch (Exception ex)
                {
                    return Content("Error while registering user - error : " + ex.Message);
                }
            }

            // Create order model for return on view
            PaymentModel paymentModel = new PaymentModel
            {
                OrderId = orderResponse.Attributes["id"],
                RazorPayKeyId = keyId,
                Amount = _requestData.Amount * 100,
                Currency = "INR",
                Name = _requestData.Name,
                Email = _requestData.Email,
                ContactNumber = _requestData.ContactNumber,
                Address = _requestData.Address,
                //  Description = _requestData.Description.Length > 255 ? _requestData.Description.Substring(0,254) : _requestData.Description,
                ProgramId = _requestData.ProgramId,
                Status = (int)PaymentStatus.Waiting,
                UserId = userId,
            };

            var paymentResult = _paymentService.CreatePayment(paymentModel);

            // Return on PaymentPage with Order data
            return PartialView("_PaymentPage", paymentModel);
        }

        [HttpPost]
        public async Task<JsonResult> Complete(string rzp_paymentid, string rzp_orderid, string ContactNumber, string FirstName, string Name)
        {
            var keyId = _configuration.GetValue<string>("RazorPay_KeyId");
            var secretKey = _configuration.GetValue<string>("RazorPay_SecretKey");
            string paymentId = rzp_paymentid;

            // This is orderId
            string orderId = rzp_orderid;
            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient(keyId, secretKey);

            Razorpay.Api.Payment payment = client.Payment.Fetch(paymentId);

            // This code is for capture the payment 
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", payment.Attributes["amount"]);
            Razorpay.Api.Payment paymentCaptured = payment.Capture(options);
            string amt = paymentCaptured.Attributes["amount"];

            if (ContactNumber.Length == 10)
                ContactNumber = "whatsapp:+91" + ContactNumber;
            await SendMessage(ContactNumber, FirstName, Name);

            if (paymentCaptured.Attributes["status"] == "captured")
            {
                var paymentModel = new PaymentModel()
                {
                    PaymentId = rzp_paymentid,
                    Status = (int)PaymentStatus.Success,
                    OrderId = rzp_orderid,
                };

                var updateStatus = _paymentService.UpdatePayment(paymentModel);
                return Json(new { Success = true, Message = "Payment completed successfully!" });
            }
            else
            {
                var paymentModel = new PaymentModel()
                {
                    PaymentId = rzp_paymentid,
                    Status = (int)PaymentStatus.Failed,
                    OrderId = rzp_orderid,
                };

                var updateStatus = _paymentService.UpdatePayment(paymentModel);

                return Json(new { Success = false, Message = "Payment failed!" });
            }
        }
        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Failed()
        {
            return View();
        }

        public async Task SendMessage(string recipientPhoneNumber, string customerName, string programName)
        {
            string accessToken = "EAAI0cZCvNMsABO9Dx4S3hTZBPuhBu27I5FyzFZCxNDxAwNy4VnvmIzYk4PW3UCqZAhWpix4OJocAVaApwUPwEncoh2YYibINxDzhIZAAJhQgjXbntybu7BtyEahZBqbq29bHmtZA8sle9vrfYqWaGCZCSj6u1FdZBCrk4Hc5VGks4m9NDGjBOog1zWBErm6T3owi6RAZDZD";  // The WhatsApp API access token
            string phoneNumberId = "519981084538466";  // Your WhatsApp phone number ID

            var message = new
            {
                messaging_product = "whatsapp",
                to = recipientPhoneNumber,
                type = "template",
                template = new
                {
                    name = "successpayment",
                    language = new { code = "en" },
                    components = new[] {
                     new
                     {
                        type = "body",
                        parameters = new[]
                        {
                            new { parameter_name = "customer_name",type = "text", text = customerName },  // Template parameter 1
                            new { parameter_name = "program_name",type = "text", text = programName }   // Template parameter 2
                        }
                     }
                    }
                }
            };

            var jsonMessage = Newtonsoft.Json.JsonConvert.SerializeObject(message);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            var content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

            // Replace the URL with the WhatsApp API endpoint for sending messages
            var url = $"https://graph.facebook.com/v21.0/{phoneNumberId}/messages";

            try
            {
                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Message sent successfully!");
                }
                else
                {
                    Console.WriteLine($"Failed to send message. Status: {response.StatusCode}");
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }


        }
        [Authorize(Roles = "Customer")]
        public IActionResult PaymentInfo()
        {
            var session = HttpContext?.Session;
            var userData = new UserModel();
            if (session != null && session.Keys.Count() > 0)
                userData = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(session.GetString("User"));
            var payments = _paymentService.GetPaymentDetailByProgramId(userData.Id);
            return View(payments);
        }

    }

}
