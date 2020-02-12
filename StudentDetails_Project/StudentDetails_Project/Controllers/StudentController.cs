using StudentDetails_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentDetails_Project.Controllers
{
    public class StudentController : Controller
    {
        StudentsEntities db = new StudentsEntities();
        // GET: Student
        public ActionResult Index()
        {

            return View(db.StudentsTable.ToList());
        }
        [HttpPost]
        public ActionResult SearchGradeAccordingID()
        {
          //  string sto = st;
            return View();
        }
     
        public ActionResult SearchGrade()
        {
            return View(new StudentVM());
        }
        [HttpPost]
        public ActionResult Create(StudentsTable st)
        {
            if (st != null)
            {
                db.StudentsTable.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(st);
        }



        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        
        [HttpPost]
        public ActionResult SearchGrade(StudentVM vm)
        {
            using (var context = new StudentsEntities())
            {

                var st = context.StudentsTable
                                .Where(s => s.StudentID == vm.StudentID)
                                .FirstOrDefault();

                if (st == null)
                {
                    StudentsTable StudentNotFound=new StudentsTable();
                    StudentNotFound.GradeInEnglishCourse = null;
                    st = StudentNotFound;

                }
                ViewData["student"] = st;

                 return View();
              
            }
        }

        public ActionResult Edit(string id)
        {

            if (id != null)
            {
                var std = db.StudentsTable.Where(s => s.StudentID == id).FirstOrDefault();

                return View(std);
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Edit(string id,StudentsTable std)
        {

            try
            { 
                db.Entry(std).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

       
       
        public ActionResult Delete(string id)
        {
            if (id != null)
            {
                var std = db.StudentsTable.Where(s => s.StudentID == id).FirstOrDefault();
                db.StudentsTable.Remove(std);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}