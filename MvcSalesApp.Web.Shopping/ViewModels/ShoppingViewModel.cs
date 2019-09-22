using System.Collections.Generic;
using ShoppingCart.Domain;

namespace MvcSalesApp.Web.Shopping.ViewModels
{
  public class ShoppingViewModel
  {
    public int CartId { get;  set; }
    public string CartCookie { get;  set; }
    public int CartCount { get; set; }
    public List<ProductLineItemViewModel> Products { get; set; }
  }
}
