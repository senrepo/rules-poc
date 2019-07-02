using System;
using model;
using Newtonsoft.Json.Linq;
using rules;
using rules.AuthorityRules;
using Xunit;
using Moq;
using System.Collections.Generic;
using rules.Repository;

namespace EngineTests
{
    public class EngineTests
    {
        [Fact]
        public void Test_Create_Engine()
        {
            var processorList = new List<IRuleProcessor>() { (new Mock<IRuleProcessor>()).Object };
            var engine = new RuleEngine(processorList);
            Assert.IsAssignableFrom<IRuleEngine>(engine);
        }

        [Fact]
        public void Test_Engine_With_AuthorityRuleProcessor()
        {
            var jsonModel = @"{'SimpleAuthorityRule':'','DatabaseAuthorityRule':'','ComplexAuthorityRule':''}";
            var model = new Model(jsonModel);
            var context = new Context();
            var repository = new Repository();
            var config = new RuleConfig();

            var simpleAuthorityRuleFactory = new SimpleAuthorityRuleFactory(model, context);
            var databaseAuthorityRuleFactory = new DatabaseAuthorityRuleFactory(model, context, repository);
            var complexAuthorityRuleFactory = new ComplexAuthorityRuleFactory(model, context, repository);
            var authorityRuleProcessor = new AuthorityRuleProcessor(config, simpleAuthorityRuleFactory, databaseAuthorityRuleFactory, complexAuthorityRuleFactory);
            var processorList = new List<IRuleProcessor>() { authorityRuleProcessor };
            var engine = new RuleEngine(processorList);

            engine.Run();

            var simpleRuleResult = model.GetJson<int>("$.SimpleAuthorityRule");
            Assert.Equal(10, simpleRuleResult);

            var databaseRuleResult = model.GetJson<double>("$.DatabaseAuthorityRule");
            Assert.Equal(1.1, databaseRuleResult);

            var complexRuleResult = model.GetJson<Discount>("$.ComplexAuthorityRule");
            Assert.IsType<Discount>(complexRuleResult);
            Assert.Equal("PaidInFull", complexRuleResult.Name);
        }

    }
}
