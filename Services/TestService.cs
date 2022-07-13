using Dissertation.Context;
using Dissertation.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dissertation.Services
{
    public class TestService : ITestService
    {
        private readonly TestDBContext _testDBContext;

        public TestService(TestDBContext testDBContext)
        {
            _testDBContext = testDBContext;
        }
        public List<Test> GetAllTests()
        {
            return _testDBContext.Tests.ToList();
        }
    }
}
