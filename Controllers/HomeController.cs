using DataBaseCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DataBaseCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext studentDBContext;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(StudentDBContext studentDBContext)
        {
            //initialize DB
            this.studentDBContext = studentDBContext;
        }

        public async Task<IActionResult> Index()
        {
            var stdData = await studentDBContext.Students.ToListAsync();

            return View(stdData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //to secure from csrf 
        public async Task<IActionResult>  Create(Student student)
        {
            if (ModelState.IsValid) { 
            
                //inserting data in DB
                await studentDBContext.Students.AddAsync(student);
                await studentDBContext.SaveChangesAsync();

                TempData["insert_success"] = "New Data Inserted successfully";
                //redirect to home page
                return RedirectToAction("Index","Home");

            }
            return View(student);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || studentDBContext.Students == null)
            {
                return NotFound(); //handle error
            }

            var stdData = await studentDBContext.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            List<SelectListItem> Gender = new()
            {
                new SelectListItem{Value="Male", Text="Male"},
                new SelectListItem{Value="Female", Text="Female"}
            };

            ViewBag.Gender = Gender;

            if (id == null || studentDBContext.Students == null)
            {
                return NotFound(); //handle error
            }

            var stdData = await studentDBContext.Students.FindAsync(id);

            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //to secure from csrf 
        public async Task<IActionResult> Edit(int? id, Student student)
        {
            if (id == null || id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //update data in database
                studentDBContext.Students.Update(student);

                await studentDBContext.SaveChangesAsync();
                TempData["update_success"] = student.Name +"'s Data Updated Successfully";
                //redirect to home page
                return RedirectToAction("Index", "Home");
            }

         
            return View(student);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || studentDBContext.Students == null)
            {
                return NotFound();
            }

            var stdData = await studentDBContext.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] //to secure from csrf 
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id == null || studentDBContext.Students == null)
            {
                return NotFound();
            }

            var stdData = await studentDBContext.Students.FindAsync(id);

            if (stdData != null)
            {
                studentDBContext.Students.Remove(stdData);
            }
           
            await studentDBContext.SaveChangesAsync();
            TempData["delete_success"] = id + "'s Data Deleted Successfully";
            return RedirectToAction("Index", "Home");
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
