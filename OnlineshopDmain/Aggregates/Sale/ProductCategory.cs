using OnlineshopDmain.Frameworks.Abstracts;


namespace OnlineshopDmain.Aggregates.Sale
{
    public class ProductCategory:IDbSetEntity,ITitledEntity,IEntity<int>
    {
        //keys
        public int Id { get; set; }
        public int? ParentId { get; set; }
      
        //navigation
        public ProductCategory? Parent { get; set; }
        
        //properties
        public string Title { get; set; }
    }
}
