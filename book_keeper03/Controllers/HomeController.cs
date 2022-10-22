using book_keeper03.Models;
using EO.WebBrowser.DOM;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace book_keeper03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(database database)
        {
            DataSet record = database.login(database.email, database.password);

            ViewBag.DataSource = record.Tables[0];

           
                foreach (System.Data.DataRow dr in ViewBag.DataSource.Rows)
                {
                    TempData["user_id"] = dr["id"].ToString();
                    TempData["user_email"] = dr["email"].ToString();
                return RedirectToAction("Index");
                }
           
            return View();
        }
        public IActionResult logout()
        {

            TempData.Remove("user_id");
            TempData.Remove("email");
            TempData.Remove("password");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult subscribe()
        {
            if (TempData.Peek("user_id") == null)
            {
                return RedirectToAction("login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult subscribe(subscription obj)
        {

            DataSet reco = obj.select_email(obj.email);
            int count = reco.Tables[0].Rows.Count;

            if (count == 0)
            {
                if (ModelState.IsValid)
                {                
                    int record = obj.insert(obj.fname,obj.lname, obj.email);
                    if (record > 0)
                    {
                        return RedirectToAction("paid", "Home");
                    }
                }
            }
            ViewBag.message = "Please, Enter Any Other Email ID";
            return View();
        }
        [HttpGet]
        public IActionResult sign_up()
        {
            return View();
        }
        [HttpPost]
        public IActionResult sign_up(database database)
        {
            DataSet reco = database.select_email(database.email);
            int count = reco.Tables[0].Rows.Count;

            if (count == 0)
            {
                if (ModelState.IsValid)
                {
                    int record = database.insert(database.fname, database.lname, database.email, database.password);
                    if (record > 0)
                    {
                        return RedirectToAction("login", "Home");
                    }
                }
            }
                ViewBag.message = "Please, Enter Any Other Email ID";
                return View();
            
        }
        [HttpGet]
        public IActionResult contact_us()
        {
            if (TempData.Peek("user_id") == null)
            {
                return RedirectToAction("login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult contact_us(contact_us obj)
        {
            if (ModelState.IsValid)
            {
                int record = obj.insert(obj.fname,obj.email, obj.subject, obj.message);
                if (record > 0)
                {
                    return RedirectToAction("contact_us", "Home");
                }
            }
            return View();
        }
        public IActionResult paid(note_detail obj)
        {
            if (TempData.Peek("user_id") == null)
            {
                return RedirectToAction("login");
            }
            else
            {
                DataSet ds2 = obj.verify(TempData.Peek("user_email").ToString());
                int count = ds2.Tables[0].Rows.Count;
                if (count > 0)
                {
                    DataSet ds = obj.paid_notes();
                    ViewBag.DataSource = ds.Tables[0];
                    return View();
                }
                return RedirectToAction("subscribe");
            }
        }
        [HttpGet]
        public IActionResult forgot_pwd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult forgot_pwd(database database)
        {
            DataSet record = database.forgot_pwd(database.email);

            ViewBag.DataSource = record.Tables[0];

          
                foreach (System.Data.DataRow dr in ViewBag.DataSource.Rows)
                {
                    TempData["user_id"] = dr["id"].ToString();
                    TempData["email"] = dr["email"].ToString();
                    TempData["password"] = dr["password"].ToString();


                    return RedirectToAction("login");

                }
            
            return View();
        }
        
        public IActionResult search_notes(note_detail obj)
        {
            if (TempData.Peek("user_id") == null)
            {
                return RedirectToAction("login");
            }
           
                DataSet ds = obj.notes();
                ViewBag.DataSource = ds.Tables[0];
                return View();
            
        }

        public IActionResult Book(string BookName)
        {
            string ReportURL = "wwwroot/FoodPDF/"+BookName;
            byte[] FileBytes = System.IO.File.ReadAllBytes(ReportURL);
            return File(FileBytes, "application/pdf");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}