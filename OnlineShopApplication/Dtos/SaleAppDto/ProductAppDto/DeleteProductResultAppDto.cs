

namespace OnlineShopBackOfficeApplication.Dtos.SaleAppDto.ProductAppDto
{
    public class DeleteProductResultAppDto
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateSoftDeletedLatin { get; set; }
        public string DateSoftDeletedPersian { get; set; }
    }
}
