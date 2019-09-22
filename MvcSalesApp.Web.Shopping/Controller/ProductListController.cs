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
using ShoppingCart.Domain;

namespace MvcSalesApp.Web.Shopping.Controller
{
  public class ProductListController : Microsoft.AspNetCore.Mvc.Controller
  {
    private IOrderingService _service;

    public ProductListController(IOrderingService service) {
      _service = service;
    }

   [HttpGet]
    public ShoppingViewModel Index() {
     
      var products= _service.GetProductList();
      var svm = BuildCartViewModelFromProductListAndTempData
                 (10, 1,products);
      // ViewBag.CartCount = svm.CartCount;
      return svm;
    }

    private ShoppingViewModel BuildCartViewModelFromProductListAndTempData 
       (object tempCount, object tempId, List<ProductLineItemViewModel> products )
    {
      var svm = new ShoppingViewModel();
      svm.Products = products;
      int cartCount = 0;
      int cartId = 0;
      if (tempCount != null) int.TryParse(tempCount.ToString(), out cartCount);
      if (tempId != null) int.TryParse(tempId.ToString(), out cartId);
      svm.CartCount = cartCount;
      svm.CartId = cartId;
      return svm;
    }
  }
}