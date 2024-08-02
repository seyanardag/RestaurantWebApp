﻿namespace WebUI.ViewModels
{
    public class ResultBasketViewModel
    {
        public int BasketId { get; set; }

        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int Count { get; set; }


        public string ProductName { get; set; }


        public int ProductId { get; set; }
        public int RestaurantTableId { get; set; }
    }
}
