namespace JON_Store.DomainModel.Abstract
{
    public interface ISoftDeleted
    {
        bool IsDeleted { get; set; }
    }
}
