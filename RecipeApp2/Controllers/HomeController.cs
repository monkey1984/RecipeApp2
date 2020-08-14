using RecipeApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeApp2.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Recipes()
        {
            Recipe obj = new Recipe();
            List<RecipeAccessLayer> rec = obj.Getdata();
            return View(rec);
        }
        public ActionResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRecipe([Bind] RecipeAccessLayer rec)
        {
            Recipe obj = new Recipe();
            try {
                if (ModelState.IsValid)
                {
                   
                    string result = obj.SaveData(rec);
                    TempData["msg"] = result;

                }
            } catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }

            return View();
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