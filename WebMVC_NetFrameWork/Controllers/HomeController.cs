using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC_NetFrameWork.Models;

namespace WebMVC_NetFrameWork.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var lst = new List<BE_2505.DataAccess.DTO.Student>();
            lst = new BE_2505.DataAccess.DALImpl.StudentManager().GetStudents();
            // trả về view 
            return View(lst);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}