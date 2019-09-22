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
  public class CustomersWithOrdersController :  Microsoft.AspNetCore.Mvc.Controller
  {
    private CustomerWithOrdersData _repo;
    public CustomersWithOrdersController(CustomerWithOrdersData repo) {
      _repo = repo;
    }

    // public ActionResult Index() {
    //   return View(_repo.GetAllCustomers());
    // }

    //   public ActionResult Details(int? id) {
    //   if (id == null) {
    //     return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //   }
    //   var customer = _repo.FindCustomer(id);
    //   if (customer == null) {
    //     return HttpNotFound();
    //   }
    //   return View(customer);
    // }
  }
}
