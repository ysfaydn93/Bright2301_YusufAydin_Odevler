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
    public class EfCoreCartRepository: EfCoreGenericRepository<Cart>, ICartRepository
    {
        public EfCoreCartRepository(TutoringContext _appContext) : base(_appContext)
        {

        }
        TutoringContext AppContext
        {
            get { return _dbContext as TutoringContext; }
        }

        public async Task AddToCartAsync(string userId, int lessonId, int amount)
        {
            var cart = await GetCartByUserId(userId);
            if (cart != null)
            {
                var index = cart.CartItems.FindIndex(ci => ci.Lesson.Id == lessonId);
                if (index < 0)
                {
                    cart.CartItems.Add(new CartItem
                    {
                        Id = lessonId,
                        CartId = cart.Id,
                        Amount = amount
                    });
                }
                else
                {
                    cart.CartItems[index].Amount += amount;
                }

                AppContext.Carts.Update(cart);
                await AppContext.SaveChangesAsync();
            }
        }

        public async Task<Cart> GetCartByUserId(string userId)
        {
            var result = await AppContext
                .Carts
                .Where(c => c.UserId == userId)
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Lesson)
                .FirstOrDefaultAsync();
            return result;
        }
    }
}