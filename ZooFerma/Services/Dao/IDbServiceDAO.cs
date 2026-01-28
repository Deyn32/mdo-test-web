using ZooFerma.Models.Dao;

namespace ZooFerma.Services.Dao
{
    public interface IDbServiceDAO
    {

        string GetDbVersion();

        ConnectionInfos OpenConnection();

        ConnectionInfos CloseConnection();
    }
}
