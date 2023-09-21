using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        //api/Calculator/add?x=100&y=20
        [HttpGet("/Add")]
        public int Add(int x, int y)
        {
            return x + y;
        }
        [HttpGet("/Sum")]
        public int Sum(int x, int y)
        {
            return x+y+100 ;
        }
        //api/Calculator/Multiply?x=100&y=20
        [HttpPost]
        public int Multiply(int x, int y)
        {
            return x*y;
        }
        //api/Calculator/Divide? x = 100&y=20
        [HttpPut]
        public int Divide(int x, int y)
        {
            return x/y;
        }
        //api/Calculator/Subtract?x=100&y=20
        [HttpDelete]
        public int Subtract(int x, int y)
        {
            return x-y;
        }

    }
}
