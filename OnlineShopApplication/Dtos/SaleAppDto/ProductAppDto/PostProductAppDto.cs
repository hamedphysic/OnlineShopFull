
namespace OnlineShopBackOfficeApplication.Dtos.SaleAppDto.ProductAppDto
{
    public class PostProductAppDto
    {
    
        public Guid Id { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public string Code { get; set; }
        public string Pic { get; set; }
        public string Title { get; set; }
        public string EntityDescription { get; set; }
        public DateTime DateCreatedLatin { get; set; }
        public string? DateCreatedPersian { get; set; }
    
        
    }
}
