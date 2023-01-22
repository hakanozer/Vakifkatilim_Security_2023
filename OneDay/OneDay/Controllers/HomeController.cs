using Microsoft.AspNetCore.Mvc;
using OneDay.Models;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace OneDay.Controllers
{
    public class HomeController : Controller
    {
        public string token = Guid.NewGuid().ToString();
        private readonly ILogger<HomeController> _logger;
        private string cipher = "T5pCvAhkGok50CBNKJjo8Q==";
        private ISession _session;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_session = contextAccessor.HttpContext.Session;
        }

        [HttpPost]
        public ActionResult Index(string email, string password, string token)
        {
            
            if (email ==null || password == null || email.Equals("") || password.Equals(""))
            {
                ViewBag.Error = "Inputs Not Valid";
                return View();
            }
            string pass = AesOperation.DecryptString(cipher, "asasasasasasasas");
            if ( email.Equals("ali@mail.com") && "12345".Equals(password) )
            {
                ViewBag.Error = "Login Success";
                // session  create
                ViewBag.Email = email;
                ViewBag.Password = password;
                //HttpContext.Session.SetString("user", email);
                Redirect("/Privacy");
            }else
            {
                ViewBag.Error = "Email or Password Fail";
                
            }

            return View();

        }

        public IActionResult Index()
        {
            string cipherText = AesOperation.EncryptString("12345", "asasasasasasasas");
            ViewBag.CipherText = cipherText;
            string plainText = AesOperation.DecryptString(cipherText, "asasasasasasasas");

            ViewBag.token = token;
            ViewBag.plainText = plainText;
            return View();
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}