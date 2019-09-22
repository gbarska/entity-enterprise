using System.Net;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Maintenance.Domain;
using Maintenance.Data;
using ShoppingCart.Interfaces;
using Newtonsoft.Json;

namespace MvcSalesApp.Web.Maintenance.Controller
{
  public class CustomersController : Microsoft.AspNetCore.Mvc.Controller
  {
    IGenericRepository<Customer> _repo;

    public CustomersController(IGenericRepository<Customer> repo) {
      _repo = repo;
    }
   
    // public ActionResult Index() {
    //   return View(_repo.All());
    // }

    // [HttpGet]
    // public ActionResult Details(int? id) {
    //   // if (id == null) {
    //   //   return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
    //   // }
    //   // Customer customer = _repo.FindByKey(id.Value);
    //   // if (customer == null) {
    //   //   return HttpNotFound();
    //   // }
    //   // return View(customer);
    // }

    // // public ActionResult Create() {
    // //   return View();
    // // }

    // [HttpPost]
    // // [ValidateAntiForgeryToken]
    // public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,DateOfBirth")] Customer customer) {
    //   // if (ModelState.IsValid) {
    //   //   _repo.Insert(customer);
    //   //   return RedirectToAction("Index");
    //   // }
    //   // return View(customer);
    // }

    // public ActionResult Edit(int? id) {
    //   if (id == null) {
    //     return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
    //   }
    //   Customer customer = _repo.FindByKey(id.Value);
    //   if (customer == null) {
    //     return HttpNotFound();
    //   }
    //   return View(customer);
    // }

    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public ActionResult Edit([Bind(Include = "CustomerId,FirstName,LastName,DateOfBirth")] Customer customer) {
    //   if (ModelState.IsValid) {
    //     _repo.Update(customer);
    //     return RedirectToAction("Index");
    //   }
    //   return View(customer);
    // }

    // public ActionResult Delete(int? id) {
    //   if (id == null) {
    //     return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
    //   }
    //   Customer customer = _repo.FindByKey(id.Value);
    //   if (customer == null) {
    //     return HttpNotFound();
    //   }
    //   return View(customer);
    // }

    // [HttpPost, ActionName("Delete")]
    // [ValidateAntiForgeryToken]
    // public ActionResult DeleteConfirmed(int id) {
    //   _repo.Delete(id);

    //   return RedirectToAction("Index");
    // }
  }
}