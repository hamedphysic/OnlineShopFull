﻿using OnlineshopDmain.Aggregates.Sale;


namespace OnlineShopBackOfficeApplication.Dtos.SaleAppDto.OrderAppDto
{ 
    public class PutOrderAppDto
    {
        public Guid Id { get; set; }


        public string SellerId { get; set; }
        public string BuyerId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }



        public string Code { get; set; }
        public string Title { get; set; }
        public string EntityDescription { get; set; }
        //public bool IsActive { get; set; }
        //public DateTime DateCreatedLatin { get; set; }
        //public string DateCreatedPersian { get; set; }
    }
}
