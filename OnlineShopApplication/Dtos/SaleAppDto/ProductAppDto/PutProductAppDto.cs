namespace OnlineShopBackOfficeApplication.Dtos.SaleAppDto.ProductAppDto
{
    public class PutProductAppDto
    {
      
        public Guid Id { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string EntityDescription { get; set; }
        public string Pic { get; set; }
        //public bool IsModified { get; set; }
        //public DateTime DateModifiedLatin { get; set; }
        //public string DateModifiedPersian { get; set; }

    }
}
