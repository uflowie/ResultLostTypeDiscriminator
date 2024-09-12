using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace ResultLostTypeDiscriminator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooController : ControllerBase
    {
        [HttpGet("result")]
        [TranslateResultToActionResult]
        public Result<BaseFoo> GetFooResult()
        {
            return Result.Success<BaseFoo>(new Foo());
        }

        [HttpGet("normal")]
        public BaseFoo GetFoo()
        {
            return new Foo();
        }


        [HttpGet("actionresult")]
        public ActionResult<BaseFoo> GetFooActionResult()
        {
            return new Foo();
        }
    }

    [JsonDerivedType(typeof(Foo), nameof(Foo))]
    public abstract class BaseFoo
    {
        public string BaseFooProperty { get; set; } = Guid.NewGuid().ToString();
    }

    public class Foo : BaseFoo
    {
        public string FooProperty { get; set; } = Guid.NewGuid().ToString();
    }
}
