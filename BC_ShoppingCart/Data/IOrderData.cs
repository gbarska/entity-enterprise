using ShoppingCart.Domain;
using System.Collections.Generic;

namespace ShoppingCart.Data
{
    public interface IOrderData
    {  
     List<Product> GetProductsWithCategoryForShopping();

     RevisitedCart StoreCartWithInitialProduct(NewCart newCart);
     RevisitedCart RetrieveCart(int cartId);

     RevisitedCart RetrieveCart(string cartCookie);

    void StoreNewCartItem(CartItem item);

    void UpdateItemsForExistingCart(RevisitedCart cart);
    }
}