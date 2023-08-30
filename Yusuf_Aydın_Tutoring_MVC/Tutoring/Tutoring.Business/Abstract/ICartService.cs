using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Entity.Concrete;

namespace Tutoring.Business.Abstract
{
    public interface ICartService
    {
        Task InitializeCart(string userId);
        Task AddToCart(string userId, int lessonId, int amount);
        Task<Cart> GetByIdAsync(int id);
        Task<Cart> GetCartByUserId(string id);
    }
}