using EShop.Domain.DomainModels;
using EShop.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EShop.web.Controllers.API
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IOrderService _orderService;

        public AdminController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("[action]")]
        public List<Order> GetAllOrders()
        {
            return _orderService.GetAllOrders();
        }

        [HttpPost("[action]")]
        public Order GetOrderDetails(Guid id)
        {
            return _orderService.GetOrderDetails(id);
        }
    }
}
