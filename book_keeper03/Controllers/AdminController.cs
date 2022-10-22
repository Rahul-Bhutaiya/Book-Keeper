using book_keeper03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net.Http.Headers;

namespace book_keeper03.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index(note_detail obj)
        {
            if(TempData.Peek("admin_id") == null)
            {
                return RedirectToAction("admin_login");
            }

            DataSet dataSet = obj.about_notes();
            DataSet ds = dataSet;
            ViewBag.DataSource = ds.Tables[0];
            return View();
        }

        public IActionResult admin_logout()
        {

            TempData.Remove("admin_id");
            TempData.Remove("email");
            TempData.Remove("password");
            return RedirectToAction("admin_login");
        }
        public IActionResult subscribers(category obj)
        {
            DataSet dataSet = obj.sub();
            DataSet ds = dataSet;
            ViewBag.DataSource = ds.Tables[0];
            return View();
        }
        public IActionResult delete(int id,category obj)
        {
            int record = obj.del(id);
            if (record == 1)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        [HttpGet]
        public IActionResult add_notes(category obj)
        {
            DataSet dataSet = obj.get_category();
            DataSet ds = dataSet;
            ViewBag.DataSource = ds.Tables[0];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> add_notes(IFormFile display_image, IFormFile note, add_note obj, category catobj)
        {
            var imgFilename = display_image.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "foodImage");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            using (var fileStream = new FileStream(Path.Combine(path, display_image.FileName), FileMode.Create))
            {
                await display_image.CopyToAsync(fileStream);
            }
            var pdfFilename = note.FileName;
            var pathpdf = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "foodPDF");
            if (!Directory.Exists(pathpdf)) Directory.CreateDirectory(pathpdf);
            using (var fileStream = new FileStream(Path.Combine(pathpdf, note.FileName), FileMode.Create))
            {
                await note.CopyToAsync(fileStream);
            }
            
            ViewBag.Name = pdfFilename;
            ViewBag.ImageName = imgFilename;//database ma aa name save kar va nu

            int record =  obj.insert(obj.title,
                                    obj.category, 
                                    obj.author,
                                    obj.date,
                                    ViewBag.ImageName,
                                    ViewBag.Name, 
                                    obj.type, 
                                    obj.num_page, 
                                    obj.description, 
                                    obj.role);
            if (record > 0)
            {
                Console.WriteLine("bhautik========"+ record);
            }
            DataSet dataSet = catobj.get_category();
            DataSet ds = dataSet;
            ViewBag.DataSource = ds.Tables[0];
            return View(); 
        }
        public IActionResult registered_users(category obj)
        {
            DataSet dataSet = obj.get_regi_data();
            DataSet ds = dataSet;
            ViewBag.DataSource = ds.Tables[0];
            return View();
        }
        public IActionResult user_contact(category obj)
        {
            DataSet dataSet = obj.us_contact();
            DataSet ds = dataSet;
            ViewBag.DataSource = ds.Tables[0];
            return View();
        }

        [HttpGet]
        public IActionResult admin_login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult admin_login(database database)
        {
            DataSet record = database.ad_login(database.email, database.password);

            ViewBag.DataSource = record.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.DataSource.Rows)
            {
                TempData["admin_id"] = dr["id"].ToString();
                
            }

            if (TempData.Peek("admin_id") != null)
            {
                return RedirectToAction("Index", "Admin");
            }

            return View();
        }
        [HttpGet]
        public IActionResult add_catecory()
        {

            return View();
        }
        [HttpPost]
        public IActionResult add_catecory(category obj)
        {
            if (ModelState.IsValid)
            {
                int record = obj.insert(obj.category_name,obj.description);
                if (record > 0)
                {
                    return RedirectToAction("index", "Admin");
                }
            }
            return View();
        }

    }
}
