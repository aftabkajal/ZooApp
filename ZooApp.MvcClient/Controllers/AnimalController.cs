using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.Services;
using ZooApp.ViewModels;

namespace ZooApp.MvcClient.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animal

        AnimalService service = new AnimalService();
        public ActionResult Index()
        {
           

            var viewAnimals = service.GetAll();

            return View(viewAnimals);
        }

        public ActionResult Details(int id)
        {
           ViewAnimal animal =  service.Get(id);
            return View(animal);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                service.Save(animal);
                return RedirectToAction("Index");
            }
            return View(animal);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Animal animal = service.GetDbModel(id);
            return View(animal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Animal animal)
        {
            if (ModelState.IsValid) { 
            service.Update(animal);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Animal animal = service.GetDbModel(id);
            return View(animal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Animal animal)
        {
            //if (ModelState.IsValid)
            //{
            //    service.Delete(animal);
            //}
            //return RedirectToAction("Index");

            try
            {
                // TODO: Add delete logic here
                bool deleted = service.Delete(animal);
                if (deleted)
                {
                    return RedirectToAction("Index");
                }
                return View(animal);
            }
            catch
            {
                return View();
            }
        }
    }
}