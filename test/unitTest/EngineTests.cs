using System;
using model;
using Newtonsoft.Json.Linq;
using rules;
using rules.AuthorityRules;
using Xunit;
using Moq;
using System.Collections.Generic;

namespace unitTest
{
    public class EngineTests
    {
        // [Fact]
        // public void Test_CreateEngine()
        // {
        //     var processorList = new List<IProcessor>() { (new Mock<IProcessor>()).Object };
        //     var engine = new Engine(processorList);
        //     Assert.IsAssignableFrom<IEngine>(engine);
        //     //TODO: find a way to test a method returing void and which doesn't throw any excetions. something like Assert.DoesNotThrow
        //     engine.Run();
        // }

        [Fact]
        public void Test_Engine_SimpleAuthorityRule()
        {
            var modelMock = new Mock<IModel>();
            var contextMock = new Mock<IContext>();

            var simpleAuthorityRuleFactory = new SimpleAuthorityRuleFactory(modelMock.Object, contextMock.Object);
            var authorityRuleProcessor = new AuthorityRuleProcessor(simpleAuthorityRuleFactory);
            var processorList = new List<IRuleProcessor>() { authorityRuleProcessor };
            var engine = new RuleEngine(processorList);

            engine.Run();
        }



        //     [Fact]
        //     public void Test_Engine_FakeAuthorityRule()
        //     {
        //         var model = new Mock<IModel>();
        //         var context = new Mock<IContext>();

        //         var authorityRuleProcessor = new AuthorityRuleProcessor(model.Object, context.Object);
        //         var processorList = new List<IProcessor>() { authorityRuleProcessor };

        //         var engine = new Engine(processorList);

        //         var fakeAuthorityRule = new TestAuthorityRule();
        //         authorityRuleProcessor.Rules.Add(fakeAuthorityRule);

        //         engine.Run();
        //     }

        // }


    }
}
