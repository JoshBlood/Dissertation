using Dissertation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dissertation.Services
{
    public interface ITestService
    {
        List<Test> GetAllTests();
    }


}
