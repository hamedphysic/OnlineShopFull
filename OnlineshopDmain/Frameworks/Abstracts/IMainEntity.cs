
namespace OnlineshopDmain.Frameworks.Abstracts
{
    public interface IMainEntity:IEntity<Guid>,ICodedEntity<string>,ITitledEntity,IDescribedEntity,IActiveEntity,ICreatedEntity,IModifiedEntity,ISoftDeletedEntity
    {
    }
}
