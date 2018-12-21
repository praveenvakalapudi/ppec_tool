using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPECTool.Models;
using PPECTool.Repository.Interfaces;

namespace PPECTool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        public ISampleRepository _sampleRepository { get; set; }
        public SampleController(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        [HttpGet("{id}")]
        public List<SampleModel> Get(int id)
        {
            return _sampleRepository.GetSampleRecords();
        }

        [HttpGet]
        public List<SampleModel> GetSample()
        {
            return _sampleRepository.GetSampleRecords();
        }

        [HttpPost]
        public void Post([FromBody]SampleModel model)
        {
            _sampleRepository.AddSampleRecords(model);
        }

    }
}