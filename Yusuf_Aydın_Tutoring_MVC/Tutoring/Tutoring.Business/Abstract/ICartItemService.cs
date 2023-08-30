using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Entity.Concrete;

namespace Tutoring.Business.Abstract
{
    public interface ICartItemService
    {
         Task ChangeAmountAsync(int cartItemId, int amount);
        void ClearCart(int cartId);
        void Delete(CartItem item);
        Task<CartItem> GetByIdAsync(int cartItemId);
    }
}