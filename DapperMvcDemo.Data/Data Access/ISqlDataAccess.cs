namespace DapperMvcDemo.Data.Data_Access
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters, string connectionId = "conn");

        Task SaveData<P>(string spName, P parameters, string connectionId = "conn");
    }
}