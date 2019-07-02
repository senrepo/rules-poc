using model;
using Moq;
using rules.AuthorityRules;
using Xunit;

namespace unitTest
{
    public class DemoSimpleAuthorityRuleTests
    {
        [Fact]
        public void Test_DemoSimpleAuthorityRule()
        {
            var jsonModel = @"{'SimpleAuthorityRule':''}";
            var model = new Model(jsonModel);
            var rule = new DemoSimpleAuthorityRule();
            var result = rule.Execute(model, new Mock<IContext>().Object);
            rule.Update(result, model,new Mock<IContext>().Object);
            Assert.Equal(10, result);
            Assert.Equal(10, model.GetJson<int>("$.SimpleAuthorityRule"));
        }
    }
}