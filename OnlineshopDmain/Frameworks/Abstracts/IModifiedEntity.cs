
namespace OnlineshopDmain.Frameworks.Abstracts
{
    public interface IModifiedEntity
    {
        bool IsModified { get; set; }
        DateTime DateModifiedLatin { get; set; }
        string? DateModifiedPersian { get; set; }
    }
}
