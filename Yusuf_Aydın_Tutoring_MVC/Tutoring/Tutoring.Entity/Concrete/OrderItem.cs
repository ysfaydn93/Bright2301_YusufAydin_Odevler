using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Entity.Concrete
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public decimal? Price { get; set; }
        public int Amount { get; set; }
    }
}