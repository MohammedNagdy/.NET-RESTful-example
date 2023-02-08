using System;
using Xunit;

namespace Testingproject
{
    public class UnitTest1
    {
        public delegate string WriteLogs(string msg);

        [Fact]
        public void Test2()
        {
            WriteLogs logs;

            logs = new WriteLogs(HelpWriteLogs);
            string res = logs("Hello!");

            Assert.Equal("Hello!", res);
        }
        string HelpWriteLogs(string message)
        {
            return message;
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
