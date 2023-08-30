using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tutoring.Data.Abstract;
using Tutoring.Data.Concrete.EfCore.Contexts;
using Tutoring.Entity.Concrete;

namespace Tutoring.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCartItemRepository : EfCoreGenericRepository<CartItem>, ICartItemRepository
    {
    public EfCoreCartItemRepository(TutoringContext _appContext) : base(_appContext)
    {

    }
        TutoringContext AppContext
    {
        get { return _dbContext as TutoringContext; }
    }

        public async Task ChangeAmountAsync(CartItem item, int amount)
        {
            item.Amount = amount;
            AppContext.CartItems.Update(item);
            await AppContext.SaveChangesAsync();
        }

      

    public void ClearCart(int cartId)
    {
        AppContext
            .CartItems
            .Where(ci => ci.CartId == cartId)
            .ExecuteDelete();
    }
}
}