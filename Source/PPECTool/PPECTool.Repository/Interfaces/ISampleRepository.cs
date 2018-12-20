using PPECTool.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PPECTool.Repository.Interfaces
{
    public interface ISampleRepository
    {
        List<SampleModel> GetSampleRecords();
    }
}
