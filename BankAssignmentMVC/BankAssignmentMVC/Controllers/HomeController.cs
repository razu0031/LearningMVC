using BankAssignmentMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BankAssignmentMVC.Controllers
{
    public class HomeController : Controller
    {
        private TestContext db = new TestContext();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Bank Home";

            List<Bank> bankList = db.Banks.ToList();
            List<BankViewModel> bankVMList = new List<BankViewModel>();

            foreach (Bank bank in bankList)
            {
                BankViewModel bankVM = new BankViewModel();
                bankVM.BankId = bank.BankID;
                bankVM.BankName = bank.BankName;
                bankVM.BankCode = bank.BankCode;
                bankVM.Address = bank.Address;
                bankVM.TotalBranches = bank.Branches.Count;
                //(db.Branches.Where(data => data.BankID == bank.BankID).ToList()).Count;

                bankVMList.Add(bankVM);
            }

            return View(bankVMList);
        }

        // GET: Home/Branches/5
        public ActionResult Branches(int? id)
        {
            Bank bank = db.Banks.Find(id);

            if (bank != null && bank.Branches != null && bank.Branches.Count > 0)
            {
                return RedirectToAction("Index", "Branches", new { id = id });
            }

            return RedirectToAction("Index", "Index");        
        }

        // GET: Home/Branches/5
        public ActionResult NewBranch(int? id)
        {
            return RedirectToAction("Create", "Branches", new { id = id });
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            Bank bank = db.Banks.Find(id);

            ViewBag.BankName = bank.BankName;
            ViewBag.Title = "Details | " + bank.BankName;


            BankViewModel bankVM = new BankViewModel();

            bankVM.BankId = bank.BankID;
            bankVM.BankName = bank.BankName;
            bankVM.BankCode = bank.BankCode;
            bankVM.Address = bank.Address;
            bankVM.TotalBranches = bank.Branches.Count;

            return View(bankVM);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Register | New Bank";

            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(BankViewModel bankVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Bank bank = new Bank();
                   
                    bank.BankName = bankVM.BankName;
                    bank.BankCode = bankVM.BankCode;
                    bank.Address = bankVM.Address;

                    db.Banks.Add(bank);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(bankVM);
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            Bank bank = db.Banks.Find(id);

            ViewBag.BankName = bank.BankName;
            ViewBag.Title = "Edit | " + bank.BankName;


            BankViewModel bankVM = new BankViewModel();

            bankVM.BankId = bank.BankID;
            bankVM.BankName = bank.BankName;
            bankVM.BankCode = bank.BankCode;
            bankVM.Address = bank.Address;

            return View(bankVM);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(BankViewModel bankVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Bank bank = new Bank();

                    bank.BankID = bankVM.BankId;
                    bank.BankName = bankVM.BankName;
                    bank.BankCode = bankVM.BankCode;
                    bank.Address = bankVM.Address;

                    db.Entry(bank).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View(bankVM);
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            Bank bank = db.Banks.Find(id);

            ViewBag.BankName = bank.BankName;
            ViewBag.Title = "Delete | " + bank.BankName;

            BankViewModel bankVM = new BankViewModel();

            bankVM.BankId = bank.BankID;
            bankVM.BankName = bank.BankName;
            bankVM.BankCode = bank.BankCode;
            bankVM.Address = bank.Address;
            bankVM.TotalBranches = bank.Branches.Count;

            return View(bankVM);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(BankViewModel bankVM)
        {
            try
            {
                Bank bank = db.Banks.Find(bankVM.BankId);
                db.Banks.Remove(bank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
