using mvcwithado.Models;
using mvcwithado.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcwithado.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            EmpRepository EmpRepo = new EmpRepository();
            ModelState.Clear();
            return View(EmpRepo.GetAllEmployees());
        }
        [HttpGet]
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(EmpModel emp,HttpPostedFileBase file)
        {
            EmpRepository repo = new EmpRepository();
            //HttpPostedFileBase file = Request.Files["Imagefile"];
            emp.Image = file.FileName;
            string  files = file.FileName;
            string name = Path.Combine(Server.MapPath("~/photo/") + files);
            file.SaveAs(name);
            repo.AddEmployee(emp);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmpRepository repository = new EmpRepository();
            var data = repository.GetAllEmployees().Find(x=>x.EmployeeId==id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(int id,EmpModel emp,HttpPostedFileBase file)
        {
            EmpRepository repository = new EmpRepository();
            emp.Image = file.FileName;
            emp.EmployeeId = id;
            string files = file.FileName;
            string name = Path.Combine(Server.MapPath("~/photo/") + files);
            file.SaveAs(name);
            repository.EditEmployee(emp);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            EmpRepository repository = new EmpRepository();
            repository.DeleteEmployee(id);
    
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            EmpRepository repository = new EmpRepository();
            var data = repository.GetAllEmployees().Find(x=>x.EmployeeId==id);
            return View(data);
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