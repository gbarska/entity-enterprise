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
using MvcSalesApp.Web.Shopping.ViewModels;

namespace MvcSalesApp.Web.Shopping.Controller
{
  public class CartController : Microsoft.AspNetCore.Mvc.Controller
  {
    private IOrderingService _service;

    public CartController(IOrderingService service) {
      _service = service;
    }

    public string ItemSelected(int? productId, int quant, decimal unitPrice,
                                     string memberCookie,int cartId) {
      var createdCart =
        _service.ItemSelected(productId.Value, quant, unitPrice,
                              "http://thedatafarm.com", memberCookie,cartId);
      // ControllerContext.HttpContext.Response.Cookies.Add(
      //   CookieUtilities.BuildCartCookie(createdCart.CartCookie, createdCart.CartCookieExpires));
      // TempData["CartCount"] =  createdCart.TotalItems;
      // TempData["CartId"] = createdCart.CartId;
      // return RedirectToAction("../ProductList");
      return "OK";
    }
  }
}