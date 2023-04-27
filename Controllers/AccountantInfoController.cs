using f_WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace f_WebApplication1.Controllers
{
    public class AccountantInfoController : Controller
    {
        private readonly CHACCContext _context;

        public AccountantInfoController(CHACCContext context)
        {
            _context = context;
        }
        // GET: AccountantInfoController
        public ActionResult Index()
        {
            var AccountantInfos = _context.AccountantInfos.FromSqlRaw($"SELECT * FROM Accountant_info ").ToList();
            return View(AccountantInfos);
        }
        public ActionResult rquset_come_from_admin()
        {
            var AccountantInfos = _context.AccountantInfos.FromSqlRaw($"SELECT * FROM Accountant_info ").ToList();
            return View(AccountantInfos);
        }

        // GET: AccountantInfoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountantInfoController/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult change_state(int id)
        {
            try
            {
                var res = _context.Database.ExecuteSqlRaw($"UPDATE Accountant_info SET name = 'السنحاني' WHERE ID={id}");
                var rowcount = _context.SaveChanges();
                TempData["msg"] = "تمت العملية بنجاح ";
                return RedirectToAction("Create", "AccountantInfo");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=====Exp In Edit AccountantInfo Action");
                Console.WriteLine($"{ex.Message}");
                TempData["msg"] = "خطأ غير متوقع ";
                return RedirectToAction("Create", "AccountantInfo");
            }
          
        }

        // POST: AccountantInfoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountantInfo accountantInfo)
        {
            
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(accountantInfo);
                }
                else
                {
                    var res = _context.Database.ExecuteSqlRaw($"insert into Accountant_info values ('{accountantInfo.Name}','{accountantInfo.IssuePlace}')");
                    var rowcount = _context.SaveChanges();
                    TempData["msg"] = "تمت الاضافة بنجاح";
                    return RedirectToAction("Index", "AccountantInfo");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=====Exp In Edit AccountantInfo Action");
                Console.WriteLine($"{ex.Message}");
                TempData["msg"] = "خطأ غير متوقع catch";
                return View(accountantInfo);
            }
        }

        // GET: AccountantInfoController/Edit/5
        public ActionResult Edit(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["msg"] = "يجب ادخال رقم طالب صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var s = _context.AccountantInfos.Find(Id);
                    if (s == null)
                    {
                        TempData["msg"] = "يجب ادخال رقم طالب صحيح";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return View(s);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=====Exp In Edit Student Action");
                Console.WriteLine($"{ex.Message}");
                TempData["msg"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: AccountantInfoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AccountantInfo accountantInfo)
        {
            


            if (!ModelState.IsValid)
            {
                return View(accountantInfo);
            }
            else
            {
                var res = _context.AccountantInfos.Update(accountantInfo);
                if (res.State == EntityState.Modified)
                {
                    
                    var rowcount = _context.Database.ExecuteSqlRaw($"UPDATE Accountant_info SET name = '{accountantInfo.IssuePlace}' WHERE ID={accountantInfo.Id}");
                    TempData["msg"] = "تم التعديل بنجاح";
                    return RedirectToAction("Index");
                    //  return View(res.Entity);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int Id, AccountantInfo accountantInfo)
        {
            try
            {
                if (Id == 0)
                {
                    TempData["msg"] = "يجب ادخال رقم طالب صحيح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var s = _context.AccountantInfos.Find(Id);
                    if (s == null)
                    {
                        TempData["msg"] = "يجب ادخال رقم طالب صحيح";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return View(s);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=====Exp In Edit Student Action");
                Console.WriteLine($"{ex.Message}");
                TempData["msg"] = "خطأ غير متوقع";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public IActionResult Delete(AccountantInfo accountantInfo)
        {

            var res = _context.AccountantInfos.Remove(accountantInfo);
            var rowcount = _context.SaveChanges();

            TempData["msg"] = "تم التعديل بنجاح";
            return RedirectToAction("Index");
            //  return View(res.Entity);



        }
    }
}

