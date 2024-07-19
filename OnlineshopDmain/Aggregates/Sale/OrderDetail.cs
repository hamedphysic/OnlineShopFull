using OnlineshopDmain.Frameworks.Abstracts;


namespace OnlineshopDmain.Aggregates.Sale
{
    public class OrderDetail:IDbSetEntity
    {
        //keys
        public Guid ProductId { get; set; }
        public Guid OrderHeaderId { get; set; }
        //navigation
        public Product? Product { get; set; }    
        //properties
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        

    }
}
