using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MayToMay.Models;
using System.Data.Entity;

namespace MayToMay.Controllers
{
    
    public class HomeController : Controller
    {
        private StudentContext db = new StudentContext();
        public ActionResult Index()
        {
           
            return View(db.Students.ToList());
        }

        public ActionResult Details(int id=0)
        {
           // Student Student = db.Students.Include(s=>s.Courses).FirstOrDefault(s=>s.Id=id);//если не использовать виртуал
            Student Student = db.Students.Find(id);

            if (Student==null)
            {
                return HttpNotFound();
            }

            return View(Student);
        }


        public ActionResult Edit(int id=0 )
        {
            Student student = db.Students.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            ViewBag.Courses = db.Courses.ToList(); 
            return View(student);
            
        }

        [HttpPost]
        public ActionResult Edit(Student student,int[] selectedCourses )
        {
            Student newstudent = db.Students.Find(student.Id);
            newstudent.Name = student.Name;
            newstudent.Surname = student.Surname;
            newstudent.Courses.Clear();
            //получаем выбранные курсы
            if (selectedCourses != null)
            {
               foreach(var c in db.Courses.Where(co => selectedCourses.Contains(co.id)))
                {
                    newstudent.Courses.Add(c);
                }
            }
            db.Entry(newstudent).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");

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