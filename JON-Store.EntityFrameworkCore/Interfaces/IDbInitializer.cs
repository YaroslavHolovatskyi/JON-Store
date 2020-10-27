namespace JON_Store.EntityFrameworkCore.Interfaces
{
    public interface IDbInitializer
    {
        void Seed(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder);
    }
}
