using System;
using rules;
using Xunit;

namespace unitTest
{
    public class EngineTests
    {
        [Fact]
        public void Test_CreateEngine()
        {


            var engine = new Engine();
            engine.Run();
        }
    }

    public class TestProcessor : Processor
    {

    }


}
