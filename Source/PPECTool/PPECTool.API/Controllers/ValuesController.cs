using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PPECTool.Models;
using PPECTool.Repository.Interfaces;

namespace PPECTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ISampleRepository _sampleRepository { get; set; }

        public ValuesController(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //_sampleRepository.GetSampleRecords();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Route("api/InsertSample")]
        public IActionResult Post([FromBody] SampleModel objSample)
        {
            //SampleModel objSample = new SampleModel();
            //objSample.Name = "SampleName";
            //objSample.Email = "p@p.com";
            //objSample.Mobile = "1234567890";
            var result = _sampleRepository.AddSampleRecords(objSample);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/GetSampleData")]
        public IActionResult GetSampleData()
        {
            var result=_sampleRepository.GetSampleRecords();
            return Ok(result);
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
}
