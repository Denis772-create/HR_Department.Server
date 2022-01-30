using System;
using HR.Department.Infrastructure.Data;

namespace HR.Department.UnitTests.Common
{
    public class TestCommandBase : IDisposable
    {
        protected readonly DepartmentContext Context;
        public TestCommandBase() => Context = DepartmentContextFactory.Create();
        public void Dispose()
        {
            DepartmentContextFactory.Destroy(Context);
        }
    }
}
