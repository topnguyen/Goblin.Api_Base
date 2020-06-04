using Elect.Web.Swagger.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Goblin.Microservice_Base.Controllers
{
    public class TestController : BaseController
    {
        /// <summary>
        ///     Test Model
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [ApiDocGroup("Test")]
        [HttpPost]
        [Route("/test")]
        public IActionResult Index([FromBody] TestModel content)
        {
            return Ok(content);
        }

        public class TestModel
        {
            public string Data { get; set; }

            public TestEnum Enum { get; set; }
        }

        public enum TestEnum
        {
            Value1 = 1,

            Value2 = 2
        }
    }
}