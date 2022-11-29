using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelBindingTask.Data;
using ModelBindingTask.Models;

namespace ModelBindingTask.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext db;

        public StudentController(AppDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var employee = db.Students.ToList();
            return View(employee);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //From Form 
        [HttpPost]
        public IActionResult Create (Student s)
        {
            var emp= "Name = " + s.Name + "Age =" + s.Age  + "City =" + s.City ;
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection std)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Student student = new Student();
        //        student.Name = std["Name"];
        //        student.Age = std["Age"];
        //        //student.Age =Convert.ToInt32(formCollection["Age"]);
        //        student.City = std["City"];

        //        db.Students.Add(student);
        //        db.SaveChanges();
        //        RedirectToAction("Index");
        //    }

        //    return View();
        //}



        [HttpGet]
        public IActionResult Edit(Student student)
        {
            var edit = db.Students.Where(x => x.Id == student.Id);
            return View(student);
        }



        [HttpPost]
        public ActionResult Edit(int id)
        {
            var update = db.Students.Where(x => x.Id == id).FirstOrDefault();
            if (update != null)
            {
                db.Students.Update(update);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        ////Form Route 
        //[HttpPost({"student"})]
        //public IActionResult CreateStd([FromRoute] Student student)
        //    {
        //        return 

        //    }

        [HttpGet]
        public ActionResult Delete(Student student)
        {
            var del = db.Students.Where(x => x.Id == student.Id).FirstOrDefault();
            return View(del);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var del = db.Students.Where(x => x.Id == id).FirstOrDefault();
            //  db.Remove(del);
            db.Students.Remove(del);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //From Query
        [HttpPost]
         public ActionResult<Student> FromQuery([FromQuery] Student std)
         {
                 db.Students.Add(std);
                 db.SaveChanges();
                 return RedirectToAction("Index");
         }


        //From Route
        [Route("/s/{Name}/{City}")]
        [HttpPost]
        public ActionResult<Student> FromRoute([FromRoute] Student std)
        {
            db.Students.Add(std);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // From Body Method 
        [HttpPost]
        public ActionResult<Student> FromBody([FromBody] Student student)
        {
            var std = db.Students.Where(x => x.Id == student.Id).FirstOrDefault();
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //From Header
        [HttpPost]
        public ActionResult<Student> FromHeader([FromHeader] Student std)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(std);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult<Student> FromForm()
        {
            return View();
        }

        //From Form method
        [HttpPost]
        public ActionResult<Student> FromForm([FromForm] Student std)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(std);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
