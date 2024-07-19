using OnlineshopDmain.Aggregates.UserManagment;
using OnlineshopDmain.Frameworks.Abstracts;
using OnlineshopDmain.Frameworks.Base;


namespace OnlineshopDmain.Aggregates.Sale
{
    public class OrderHeader: MainEntityBase,IDbSetEntity
    {
        // Keys
       
        // navigation

        public OnlineShopUser? Seller { get; set; }
        public OnlineShopUser? Buyer { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = [];

        //properties
        public string SellerId { get; set; }
        public string BuyerId { get; set; }
     



        
    }
}
