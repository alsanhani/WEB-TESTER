using f_WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace f_WebApplication1.Controllers
{
    public class AccountantLowController : Controller
    {
        private readonly CHACCContext _context;

        public AccountantLowController(CHACCContext context)
        {
            _context = context;
        }
        // GET: AccountantLowController
        public ActionResult Index()
        {
            var AccountantLows = _context.AccountantLows.ToList();
            return View(AccountantLows);
        }

        // GET: AccountantLowController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountantLowController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountantLowController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountantLow accountantLow)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(accountantLow);
                }
                else
                {
                    var res = _context.AccountantLows.Add(accountantLow);

                    var rowcount = _context.SaveChanges();
                    TempData["msg"] = "تمت الاضافة بنجاح";
                    return RedirectToAction("Create", "AccountantLow");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=====Exp In Edit AccountantInfo Action");
                Console.WriteLine($"{ex.Message}");
                TempData["msg"] = "خطأ غير متوقع catch";
                return View(accountantLow);
            }
        }

        // GET: AccountantLowController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountantLowController/Edit/5
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

        // GET: AccountantLowController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountantLowController/Delete/5
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
