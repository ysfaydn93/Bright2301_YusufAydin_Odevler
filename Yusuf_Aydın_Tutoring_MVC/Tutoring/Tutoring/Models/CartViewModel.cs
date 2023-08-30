using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
        public decimal? TotalPrice()
        {
            return CartItems.Sum(ci => ci.Price * ci.Amount);
        }
    }
    public class CartItemViewModel
    {
        public int CartItemId { get; set; }
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string LessonUrl { get; set; }
        public string LessonImageUrl { get; set; }
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Boş bırakılmalalıdır.")]
        public int Amount { get; set; }
    }
}