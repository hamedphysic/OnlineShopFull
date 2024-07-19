

namespace OnlineshopDmain.Frameworks.Abstracts
{
    public interface ICodedEntity<TCode>
    {
        public TCode Code { get; set; }
    }
}
