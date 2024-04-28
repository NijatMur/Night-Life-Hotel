namespace NightLifeHotelApp.Repositories.Base
{
    public interface ICreateAsync<TEntity>
    {
        Task CreateAsync(TEntity entity);
    }
}
