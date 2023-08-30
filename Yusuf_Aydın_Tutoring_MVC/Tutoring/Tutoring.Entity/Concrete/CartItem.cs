using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Entity.Concrete
{
    public class CartItem
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int Amount { get; set; }
    }
}