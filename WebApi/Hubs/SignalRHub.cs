using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs
{
    public class SignalRHub : Hub
    {
		

		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
        private readonly IMoneyBoxService _moneyBoxService;
        private readonly IRestaurantTableService _restaurantTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;
        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyBoxService moneyBoxService, IRestaurantTableService restaurantTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyBoxService = moneyBoxService;
            _restaurantTableService = restaurantTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public async Task SendData()
		{
			var val1 = _productService.TGetProductCount();
			await Clients.All.SendAsync("productCount", val1);

			var val2 = _categoryService.TGetCategoryCount();
			await Clients.All.SendAsync("CategoryCount", val2);

			var val3 = _categoryService.TGetActiveCategoryCount();	
			await Clients.All.SendAsync("ActiveCategoryCount", val3);

			var val4 = _categoryService.TGetPassiveCategoryCount();
			await Clients.All.SendAsync("PassiveCategoryCount", val4);

			var val5 = _productService.TGetProductCountByHamburger();
			await Clients.All.SendAsync("GetProductCountByHamburger", val5);

			var val6 = _productService.TGetProductCountByCategoryDrink();
			await Clients.All.SendAsync("GetProductCountByCategoryDrink", val6);

			var val7 = _productService.TGetAverageProductPrice();
			await Clients.All.SendAsync("GetAverageProductPrice",val7.ToString("0.00")+" TL");

            var val8 = _productService.TGetProductNameByMaxPrice();
            await Clients.All.SendAsync("GetProductNameByMaxPrice", val8);

            var val9 = _productService.TGetProductNameByMinPrice();
            await Clients.All.SendAsync("GetProductNameByMinPrice", val9);
			
            var val10 = _productService.TAverageHamburgerPrice();
            await Clients.All.SendAsync("AverageHamburgerPrice", val10.ToString("0.00")+ " TL");

            var val11 = _orderService.TGetTotalOrderCount();
            await Clients.All.SendAsync("GetTotalOrderCount", val11);

            var val12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ActiveOrderCount", val12);



            var val13 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("LastOrderPrice", val13);

            var val14 = _moneyBoxService.TGetAll().FirstOrDefault().TotalAmount;
            await Clients.All.SendAsync("MoneyBoxAmount", val14);

            var val15 = _orderService.TEndorsementToday();
            await Clients.All.SendAsync("EndorsementToday", val15);

            var val16 = _restaurantTableService.TGetAll().Count();
            await Clients.All.SendAsync("RestaurantTableCount", val16);

        }
        
        public async Task SendProgressBarData ()
        {
            var val1 = _moneyBoxService.TGetAll().FirstOrDefault().TotalAmount;
            await Clients.All.SendAsync("MoneyBoxAmount", val1.ToString("0.00")+ "TL");


            var activeOrder = _orderService.TActiveOrderCount();
            var totalOrder = _orderService.TGetTotalOrderCount();
            int[] activeTotal = new int[2];
            activeTotal[0] = activeOrder;
            activeTotal[1] = totalOrder;

            await Clients.All.SendAsync("active-total-counts", activeTotal);


            

            int[] activepassivetable = new int[2];
            activepassivetable[0] = _restaurantTableService.TGetAll().Where(x=>x.Status == true).Count();
            activepassivetable[1] = _restaurantTableService.TGetAll().Count();
                       

            await Clients.All.SendAsync("tablecount", activepassivetable);



        }

        public async Task GetBookingList()
        {
            var values = _bookingService.TGetAll().OrderBy(x=>x.BookingDate);
            await Clients.All.SendAsync("getBookingList", values);
        }

        public async Task GetUnreadNotifications()
        {
            var notifications = _notificationService.TGetUnReadNotifications();
            await Clients.All.SendAsync("unreadnotificationslist", notifications);
        }

        public async Task TablesRealtime()
        {
            var values = _restaurantTableService.TGetAll();
            await Clients.All.SendAsync("tableList", values);
        }

        public async Task SendMessage(string user, string message)
        {           
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendCategoryProductCounts()
        {
            var categoryProductCounts = _categoryService.TGetCategoryProductCounts();            
            await Clients.All.SendAsync("categoryProductCounts", categoryProductCounts);
        }


    }
}
