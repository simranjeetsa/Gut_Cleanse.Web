using Gut_Cleanse.Model;
using Microsoft.AspNetCore.Mvc;


namespace Gut_Cleanse.Web.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Revolution()
        {
            return View();
        }

        public IActionResult Glory()
        {
            return View();
        }

        public IActionResult Workshop()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrder(PaymentInitiateModel _requestData)
        {
            // Generate random receipt number for order
            Random randomObj = new Random();
            string transactionId = randomObj.Next(10000000, 100000000).ToString();

            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_umbrFAbVJ3slyJ", "su9eXFaihGucMmKECVRcRk0Q");
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", _requestData.Amount * 100);  // Amount will in paise
            options.Add("receipt", transactionId);
            options.Add("currency", "INR");
            options.Add("payment_capture", "0"); // 1 - automatic  , 0 - manual
                                                 //options.Add("notes", "-- You can put any notes here --");
            Razorpay.Api.Order orderResponse = client.Order.Create(options);
            string orderId = orderResponse["id"].ToString();

            // Create order model for return on view
            OrderModel orderModel = new OrderModel
            {
                orderId = orderResponse.Attributes["id"],
                razorpayKey = "rzp_test_umbrFAbVJ3slyJ",
                amount = _requestData.Amount * 100,
                currency = "INR",
                name = _requestData.Name,
                email = _requestData.Email,
                contactNumber = _requestData.ContactNumber,
                address = _requestData.Address,
                description = "Testing description"
            };

            // Return on PaymentPage with Order data
            return View("PaymentPage", orderModel);
        }

       


        //[HttpPost]
        //public ActionResult Complete()
        //{
        //    // Payment data comes in url so we have to get it from url

        //    // This id is razorpay unique payment id which can be use to get the payment details from razorpay server
        //    string paymentId = Request.Params["rzp_paymentid"];

        //    // This is orderId
        //    string orderId = Request.Params["rzp_orderid"];
        //    Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_umbrFAbVJ3slyJ", "su9eXFaihGucMmKECVRcRk0Q");

        //    Razorpay.Api.Payment payment = client.Payment.Fetch(paymentId);

        //    // This code is for capture the payment 
        //    Dictionary<string, object> options = new Dictionary<string, object>();
        //    options.Add("amount", payment.Attributes["amount"]);
        //    Razorpay.Api.Payment paymentCaptured = payment.Capture(options);
        //    string amt = paymentCaptured.Attributes["amount"];

        //    //// Check payment made successfully

        //    if (paymentCaptured.Attributes["status"] == "captured")
        //    {
        //        // Create these action method
        //        return RedirectToAction("Success");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Failed");
        //    }
        //}

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Failed()
        {
            return View();
        }

    }

}
