using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Business.Abstract;
using Tutoring.Data.Abstract;
using Tutoring.Entity.Concrete;

namespace Tutoring.Business.Concrete
{
    public class CartItemManager : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemManager(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public Task ChangeAmountAsync(int cartItemId, int amount)
        {
            throw new NotImplementedException();
        }

        public async Task ChangeAmounAsync(int cartItemId, int amount)
        {
            var cart = await GetByIdAsync(cartItemId);
            await _cartItemRepository.ChangeAmountAsync(cart, amount);
        }

        public void ClearCart(int cartId)
        {
            _cartItemRepository.ClearCart(cartId);
        }

        public void Delete(CartItem item)
        {
            _cartItemRepository.Delete(item);
        }

        public async Task<CartItem> GetByIdAsync(int cartItemId)
        {
            return await _cartItemRepository.GetByIdAsync(cartItemId);
        }
    }
}