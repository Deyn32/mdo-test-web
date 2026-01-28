using Microsoft.AspNetCore.Mvc;
using ZooFerma.Models.Dao;
using ZooFerma.Services.Dto;

namespace ZooFerma.Controllers
{

    [ApiController]
    [Route("api/sql/server")]
    public class DbSqlServerController : Controller
    {

        private readonly IDbService dbService;

        public DbSqlServerController(IDbService dbService)
        {
            this.dbService = dbService;
        }

        [HttpGet("version")]
        public string getDbVersion()
        {

            return dbService.GetDbVersion();
        }

        [HttpGet("open")]
        public ConnectionInfos openConnection()
        {
            return dbService.OpenConnection();
        }

        [HttpGet("close")]
        public ConnectionInfos closeConnection()
        {
            return dbService.CloseConnection();
        }
    }
}
