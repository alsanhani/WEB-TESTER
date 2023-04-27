using f_WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace f_WebApplication1.Controllers
{
    public class Marks2Controller : Controller
    {
        private readonly CHACCContext _context;

        public Marks2Controller(CHACCContext context)
        {
            _context = context;
        }
        // GET: Marks2Controller
        public ActionResult Index()
        {
            var Marks2s = _context.Marks2s.ToList();
            return View(Marks2s);
        }

        // GET: Marks2Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Marks2Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marks2Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Marks2 marks2)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["msg"] = "!ModelState.IsValid داخل";
                    return View(marks2);
                }
                else
                {
                   
                     var res = _context.Database.ExecuteSqlRaw($"insert into MARKS2 values ({marks2.M1},{marks2.M2},{marks2.M3},{marks2.M4},{marks2.Id},'{marks2.Type}')");
                    var rowcount = _context.SaveChanges();
                    TempData["msg"] = "تمت الاضافة بنجاح";
                    return RedirectToAction("Create", "Marks2");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=====Exp In Edit Marks2 Action");
                Console.WriteLine($"{ex.Message}");
                TempData["msg"] = "خطأ غير متوقع catch Marks2";
                return View(marks2);
            }
        }

        // GET: Marks2Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Marks2Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Marks2Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Marks2Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
