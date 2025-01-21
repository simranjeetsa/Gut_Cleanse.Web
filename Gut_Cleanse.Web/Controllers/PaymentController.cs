using Gut_Cleanse.Common.Enums;
using Gut_Cleanse.Model;
using Gut_Cleanse.Service.CommonService;
using Gut_Cleanse.Service.PaymentService;
using Microsoft.AspNetCore.Mvc;
using System.Text;


namespace Gut_Cleanse.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ICommonService _commonService;
        private readonly IPaymentService _paymentService;
        public PaymentController(IConfiguration configuration, ICommonService commonService, IPaymentService paymentService)
        {
            _configuration = configuration;
            _commonService = commonService;
            _paymentService = paymentService;
        }
        public IActionResult Revolution()
        {
            var model=_commonService.GetPaymentTypeId(1);
            return View(model);
        }

        public IActionResult Glory()
        {
            var model = _commonService.GetPaymentTypeId(2);
            return View(model);
        }

        public IActionResult Workshop()
        {
            var model = _commonService.GetPaymentTypeId(3);
            return View(model);
        }

        public IActionResult Challenge()
        {
            var model = _commonService.GetPaymentTypeId(4);
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateOrder(PaymentInitiateModel _requestData)
        {
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
                Description = _requestData.Description,
                PaymentTypeId = _requestData.PaymentTypeId,
                Status = (int)PaymentStatus.Waiting
            };

            var paymentResult = _paymentService.CreatePayment(paymentModel);

            // Return on PaymentPage with Order data
            return View("PaymentPage", paymentModel);
        }




        [HttpPost]
        public ActionResult Complete(string rzp_paymentid, string rzp_orderid)
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


            if (paymentCaptured.Attributes["status"] == "captured")
            {
                // Create these action method
                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Failed");
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

        public async Task SendMessage()
        {
            string accessToken = "your_access_token";  // The WhatsApp API access token
            string phoneNumberId = "your_phone_number_id";  // Your WhatsApp phone number ID
            string recipientPhoneNumber = "recipient_phone_number"; // Recipient phone number (include country code, no +)

            var message = new
            {
                messaging_product = "whatsapp",
                to = recipientPhoneNumber,
                text = new { body = "Hello, this is a test message from WhatsApp API!" }
            };

            var jsonMessage = Newtonsoft.Json.JsonConvert.SerializeObject(message);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            var content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");

            // Replace the URL with the WhatsApp API endpoint for sending messages
            var url = $"https://graph.facebook.com/v15.0/{phoneNumberId}/messages";

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

    }

}
