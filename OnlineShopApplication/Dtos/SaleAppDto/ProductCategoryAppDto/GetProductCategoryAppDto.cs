
namespace OnlineShopBackOfficeApplication.Dtos.SaleAppDto.ProductCategoryAppDto
{
    public class GetProductCategoryAppDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
    }
}
