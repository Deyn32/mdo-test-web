using ZooFerma.Models.Dao;
using ZooFerma.Services.Dao;

namespace ZooFerma.Services.Dto.Impls
{
    public class DbServiceImpl : IDbService
    {

        private IDbServiceDAO dbServiceDAO;

        public DbServiceImpl(IDbServiceDAO dbServiceDAO)
        {
            this.dbServiceDAO = dbServiceDAO;
        }

        public ConnectionInfos CloseConnection()
        {
            return dbServiceDAO.CloseConnection();
        }

        public string GetDbVersion()
        {
            return dbServiceDAO.GetDbVersion();
        }

        public ConnectionInfos OpenConnection()
        {
            return dbServiceDAO.OpenConnection();
        }
    }
}
