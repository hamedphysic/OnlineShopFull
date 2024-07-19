
namespace OnlineShopOfficeApplication.Dtos.SaleAppDto.OrderAppDto
{
    public class OrderDetailDto
    {
        
        public Guid ProductId { get; set; }
        public Guid? OrderHeaderId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
