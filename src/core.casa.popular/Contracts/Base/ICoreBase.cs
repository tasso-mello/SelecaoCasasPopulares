namespace core.casa.popular.Contracts.Base
{
    using System.Threading.Tasks;
    public interface ICoreReadBase
    {
        Task<string> Get(Guid id);
        Task<string> Get(int skip, int take);
        Task<string> Get(string filter, int skip, int take);
    }


    public interface ICorePersistBase<T> where T : class
    {
        Task<string> Post(T model);
        Task<string> Put(T model);
        Task<string> Delete(Guid id);
    }
}
