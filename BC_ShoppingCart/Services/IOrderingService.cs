using ShoppingCart.Domain;
using System.Collections.Generic;

namespace ShoppingCart.Interfaces
{
    public interface IOrderingService
    {
    List<ProductLineItemViewModel> GetProductList();

     RevisitedCart ItemSelected(int productId, int quantity,
                                      decimal displayedPrice, string sourceUrl,
                                      string memberCookie, int cartId);



    RevisitedCart RetrieveCart(string cartCookie); 
    }         
}