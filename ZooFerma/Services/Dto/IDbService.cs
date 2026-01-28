using ZooFerma.Models.Dao;

namespace ZooFerma.Services.Dto
{
    public interface IDbService
    {
        ConnectionInfos OpenConnection();
        ConnectionInfos CloseConnection();
        string GetDbVersion();
    }
}
