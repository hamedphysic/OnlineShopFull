using OnlineshopDmain.Aggregates.UserManagment;


namespace OnlineShopOfficeApplication.Dtos.SaleAppDto.OrderAppDto
{
    public class GetOrderAppDto
    {
        public Guid Id { get; set; }


        public OnlineShopUser Seller { get; set; }
        public OnlineShopUser Buyer { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }


        public string Code { get; set; }
        public string Title { get; set; }
        public string EntityDescription { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreatedLatin { get; set; }
        public string DateCreatedPersian { get; set; }
        public bool IsModified { get; set; }
        public DateTime DateModifiedLatin { get; set; }
        public string DateModifiedPersian { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateSoftDeletedLatin { get; set; }
        public string DateSoftDeletedPersian { get; set; }
    }
}
