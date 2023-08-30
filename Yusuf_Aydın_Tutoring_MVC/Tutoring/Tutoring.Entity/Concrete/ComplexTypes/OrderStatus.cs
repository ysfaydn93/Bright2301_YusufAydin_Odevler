using System.ComponentModel.DataAnnotations;

namespace Tutoring.Entity.Concrete.ComplexTypes
{
    public enum OrderStatus
    {
        [Display(Name = "Siparişiniz alındı.")]
        Received = 0,
        [Display(Name = "Hazırlanıyor.")]
        Preparing = 1,
        [Display(Name = "Gönderildi.")]
        Sent = 2,
        [Display(Name = "Teslim edildi.")]
        Delivered = 3
    }
}