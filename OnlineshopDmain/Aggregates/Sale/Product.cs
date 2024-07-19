using OnlineshopDmain.Frameworks.Abstracts;
using OnlineshopDmain.Frameworks.Base;

namespace OnlineshopDmain.Aggregates.Sale
{
    public class Product : MainEntityBase, IDbSetEntity
    {
     
        // forgin key
        public int ProductCategoryId { get; set; }
      
        
        //navigation
        public ProductCategory ProductCategory { get; set; }
       
        //properties
        public decimal UnitPrice { get; set; }
        public string? Pic { get; set; }
       
    }
}
