using BankAssignmentMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankAssignmentMVC.Controllers
{
    public class BranchesController : Controller
    {
        private TestContext db = new TestContext();

        // GET: Branches
        public ActionResult Index(int? id)
        {
            List <Branch> branchList = (db.Branches.Where(data => data.BankID == id).ToList());

            ViewBag.BankName = branchList[0].Bank.BankName;
            ViewBag.BankId = branchList[0].BankID;
            ViewBag.Title = "Branches | " + branchList[0].Bank.BankName;

            List<BranchViewModel> branchVMList = new List<BranchViewModel>();

            foreach (Branch branch in branchList)
            {
                BranchViewModel branchVM = new BranchViewModel();
                branchVM.BranchID = branch.BranchID;
                branchVM.BankID = branch.BankID;
                branchVM.BranchCode = branch.BranchCode;
                branchVM.BranchName = branch.BranchName;
                branchVM.Address = branch.Address;

                branchVMList.Add(branchVM);
            }

            return View(branchVMList);
        }

        // GET: Branches/Details/5
        public ActionResult Details(int id)
        {
            Branch branch = db.Branches.Find(id);

            ViewBag.BankName = branch.Bank.BankName;
            ViewBag.BranchName = branch.BranchName;
            ViewBag.Title = branch.BranchName + " | " + branch.Bank.BankName;

            BranchViewModel branchVM = new BranchViewModel();
            if (branch != null)
            {
                branchVM.BranchID = branch.BranchID;
                branchVM.BankID = branch.BankID;
                branchVM.BranchCode = branch.BranchCode;
                branchVM.BranchName = branch.BranchName;
                branchVM.Address = branch.Address;
            }

            return View(branchVM);
        }

        // GET: Branches/Create
        public ActionResult Create(int id)
        {
            Bank bank = db.Banks.Find(id);

            ViewBag.BankName = bank.BankName;
            ViewBag.Title = "New Branch | " + bank.BankName;

            BranchViewModel branchVM = new BranchViewModel();
            branchVM.BankID = id;

            return View(branchVM);
        }

        // POST: Branches/Create
        [HttpPost]
        public ActionResult Create(BranchViewModel branchVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Branch branch = new Branch();

                    branch.BankID = branchVM.BankID;
                    branch.BranchCode = branchVM.BranchCode;
                    branch.BranchName = branchVM.BranchName;
                    branch.Address = branchVM.Address;

                    db.Branches.Add(branch);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = branchVM.BankID });
                }

                return View(branchVM);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Branches/Edit/5
        public ActionResult Edit(int id)
        {
            Branch branch = db.Branches.Find(id);

            ViewBag.BankName = branch.Bank.BankName;
            ViewBag.BranchName = branch.BranchName;
            ViewBag.Title = "Edit " + branch.BranchName + " | " + branch.Bank.BankName;

            BranchViewModel branchVM = new BranchViewModel();

            branchVM.BankID = branch.BankID;
            branchVM.BranchID = branch.BranchID;
            branchVM.BranchCode = branch.BranchCode;
            branchVM.BranchName = branch.BranchName;
            branchVM.Address = branch.Address;

            return View(branchVM);
        }

        // POST: Branches/Edit/5
        [HttpPost]
        public ActionResult Edit(BranchViewModel branchVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Branch branch = new Branch();

                    branch.BankID = branchVM.BankID;
                    branch.BranchID = branchVM.BranchID;
                    branch.BranchCode = branchVM.BranchCode;
                    branch.BranchName = branchVM.BranchName;
                    branch.Address = branchVM.Address;

                    db.Entry(branch).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { id = branchVM.BankID });
                }

                return View(branchVM);
            }
            catch(Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Branches/Delete/5
        public ActionResult Delete(int id)
        {
            Branch branch = db.Branches.Find(id);

            ViewBag.BankName = branch.Bank.BankName;
            ViewBag.BranchName = branch.BranchName;
            ViewBag.Title = "Delete " + branch.BranchName + " | " + branch.Bank.BankName;

            BranchViewModel branchVM = new BranchViewModel();

            branchVM.BankID = branch.BankID;
            branchVM.BranchID = branch.BranchID;
            branchVM.BranchCode = branch.BranchCode;
            branchVM.BranchName = branch.BranchName;
            branchVM.Address = branch.Address;

            return View(branchVM);
        }

        // POST: Branches/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(BranchViewModel branchVM)
        {
            try
            {
                Branch branch = db.Branches.Find(branchVM.BranchID);
                db.Branches.Remove(branch);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = branchVM.BankID }); ;
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
