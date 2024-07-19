
namespace OnlineshopDmain.Frameworks.Abstracts
{
    public interface ISoftDeletedEntity
    {
        bool IsDeleted { get; set; }
        DateTime DateSoftDeletedLatin { get; set; }
        string? DateSoftDeletedPersian { get; set; }
    }
}
