using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApiDemo6.Interface;
using TestWebApiDemo6.Model;
using TestWebApiDemo6.Resposity;
using TestWebApiDemo6.UnitofWork;

namespace TestWebApiDemo6.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestSqlSugarController : ControllerBase
    {
        private readonly IUnitOfWorkManger unitOfWorkManger;
        private readonly IBaseRepository<UploadedItem> upRep;
        private readonly IBaseRepository<Article> artRep;

        public TestSqlSugarController(IUnitOfWorkManger unitOfWorkManger, IBaseRepository<Article> artRep, IBaseRepository<UploadedItem> upRep)
        {
            this.unitOfWorkManger = unitOfWorkManger;
            this.artRep = artRep;
            this.upRep = upRep;
        }

       
        [HttpGet]
        public async Task <IActionResult> TestSqlSugarTran()
        {
            //需要测试什么 
            // 数据库连接？
            // sington注入 每次都是同一个 
            // base
            Console.WriteLine(unitOfWorkManger.GetDbClient().GetHashCode());
            Console.WriteLine(artRep.GetHashCode());
            Console.WriteLine(artRep.Db.AsTenant().GetHashCode());
            Console.WriteLine(upRep.Db.AsTenant().GetHashCode());
            return Ok();
        }
    }
}
