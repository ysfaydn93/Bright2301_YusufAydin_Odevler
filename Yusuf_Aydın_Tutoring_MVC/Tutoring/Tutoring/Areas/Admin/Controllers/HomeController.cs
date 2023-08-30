using Tutoring.Business.Abstract;
using Tutoring.Business.Concrete;
using Tutoring.Entity.Concrete;
using Tutoring.Core;
using Tutoring.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutoring.Models;
using Tutoring.Entity.Concrete.ComplexTypes;
using Tutoring.Extensions;

namespace Tutoring.Areas.Admin.Controllers
{ 
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController: Controller
    {
        private readonly IOrderService _orderManager;

        public HomeController(IOrderService orderManager)
        {
            _orderManager = orderManager;
        }

        public async Task<IActionResult> Index()
        {
            var totalSalesAmount = await _orderManager.GetTotalAsync(0);
            var totalSalesCount = await _orderManager.GetTotalAsync(1);
            var totalBookSalesCount = await _orderManager.GetTotalAsync(2);
            AdminDashboardViewModel model = new AdminDashboardViewModel
            {
                TotalSalesAmount = totalSalesAmount == "" ? 0 : Convert.ToDecimal(totalSalesAmount),
                TotalSalesCount = totalSalesCount == "" ? 0 : Convert.ToInt32(totalSalesCount),
                TotalLessonSalesCount = totalBookSalesCount == "" ? 0 : Convert.ToInt32(totalBookSalesCount)
            };
            List<Order> receivedOrderList = await _orderManager.GetAllOrdersAsync(null, true, OrderStatus.Received);
            List<OrderViewModel> receivedOrders = receivedOrderList.Select(o => new OrderViewModel
            {
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                City = o.City,
                Address = o.Address,
                PhoneNumber = o.PhoneNumber,
                Email = o.Email,
                OrderDate = o.OrderDate,
                OrderItems = o.OrderItems,
                OrderStatus = o.OrderStatus.GetDisplayName()
            }).ToList();
            model.ReceivedOrders = receivedOrders;

            List<Order> preparingOrderList = await _orderManager.GetAllOrdersAsync(null, true, OrderStatus.Preparing);
            List<OrderViewModel> preparingOrders = preparingOrderList.Select(o => new OrderViewModel
            {
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                City = o.City,
                Address = o.Address,
                PhoneNumber = o.PhoneNumber,
                Email = o.Email,
                OrderDate = o.OrderDate,
                OrderItems = o.OrderItems,
                OrderStatus = o.OrderStatus.GetDisplayName()
            }).ToList();
            model.PreparingOrders = preparingOrders;


            return View(model);
        }
    }
}
