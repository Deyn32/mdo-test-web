using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using ZooFerma.Models.Dao;

namespace ZooFerma.Services.Dao.Impls
{
    public class DbServaceDAOImpl : IDbServiceDAO
    {

        private readonly DataContext context;

        public DbServaceDAOImpl(DataContext context)
        {
            this.context = context;
        }

        public ConnectionInfos CloseConnection()
        {
            var conn = context.Database.GetDbConnection();

            try
            {
                if (conn.State == ConnectionState.Open) conn.Close();

                return successOperation(conn);
            }
            catch (Exception ex)
            {
                return failedOperation(ex);
            }
        }

        private ConnectionInfos successOperation(DbConnection conn) => new ConnectionInfos
        {
            database = conn.Database,
            dataSource = conn.DataSource,
            state = conn.State.ToString(),
            error = ""
        };

        private ConnectionInfos failedOperation(Exception ex)
        {
            return new ConnectionInfos()
            {
                error = ex.Message
            };
        }

        public string GetDbVersion()
        {
            return context.Database
                    .SqlQueryRaw<string>("SELECT @@VERSION AS Version")
                    .AsEnumerable()
                    .FirstOrDefault() ?? "Не известно";
        }

        public ConnectionInfos OpenConnection()
        {
            var conn = context.Database.GetDbConnection();

            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();

                return successOperation(conn);
            } catch (Exception ex)
            {
                return failedOperation(ex);
            }
        }
    }
}
