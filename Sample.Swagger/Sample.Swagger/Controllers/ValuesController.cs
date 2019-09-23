using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sample.Swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// This is example text for api description!!!!@!
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Sample of Param description
        /// </summary>
        /// <param name="id">This id is SampleID</param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> GetBySampleID(int id)
        {
            return "value";
        }

        [HttpGet("Get1")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(sampleobj))]
        public IActionResult Get1()
        {
            return Ok(new sampleobj()
            {
                Age = 22,
                FirstName = "test1"
            });
        }

        /// <summary>
        /// if keyin 0 will show notfound
        /// </summary>
        /// <param name="aa"></param>
        /// <returns></returns>
        [HttpGet("testNotFound")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult testNotFound(int aa = 0)
        {
            if (aa == 0)
                return NotFound();

            return Ok(aa);
        }

        /// <summary>
        /// return bad request with object type
        /// </summary>
        /// <param name="aa"></param>
        /// <returns></returns>
        [HttpGet("testBadRequest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(badsampleobj), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public IActionResult testBadReq(int aa = 0)
        {
            if (aa == 0)
                return BadRequest(new badsampleobj
                {
                    ErrorCode = "Er1",
                    ErrorMessage = "Msg1"
                });

            return Ok(aa);
        }

        /// <summary>
        /// Example for return list of object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetObjList")]
        public ActionResult<IEnumerable<sampleobj>> GetObjList()
        {
            return new List<sampleobj>{ new sampleobj()
            {
                FirstName = "FirstName1",
                LastName = "lastName1",
                Age = 20
            },
            new sampleobj()
            {
                FirstName = "FirstName2",
                LastName = "lastName2",
                Age = 21
            }
            };
        }

        /// <summary>
        /// Example to pass multiple parameter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{id}/{name}")]
        public ActionResult<sampleobj> GetObj(int id, string name)
        {
            var returnObj = new sampleobj
            {
                FirstName = name,
                LastName = "lastName1",
                Age = 20
            };
            return Ok(returnObj);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class sampleobj
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class badsampleobj
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
    }
}
