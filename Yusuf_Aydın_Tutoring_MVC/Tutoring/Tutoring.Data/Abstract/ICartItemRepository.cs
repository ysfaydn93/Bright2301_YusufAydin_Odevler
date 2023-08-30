using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Entity.Concrete;

namespace Tutoring.Data.Abstract
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task ChangeAmountAsync(CartItem item, int amount);
        void ClearCart(int cartId);
    }
}