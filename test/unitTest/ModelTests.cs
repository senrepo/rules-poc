using Xunit;
using Moq;
using model;

namespace ModelTests
{
    public class ModelTests
    {
        [Fact]
        public void Test_Model_Set_Get()
        {
            string jsonPayload = "{'author': '', 'count': 0, 'discount': ''}";
            var model = new Model(jsonPayload);

            model.SetJson<string>("$.author", "author");
            var author = model.GetJson<string>("$.author");
            Assert.Equal("author", author);

            model.SetJson<int>("$.count", 1);
            var count = model.GetJson<int>("$.count");
            Assert.Equal(1, count);

            model.SetJson<Discount>("$.discount", new Discount() { Name = "PaidInFull" });
            var discount = model.GetJson<Discount>("$.discount");
            Assert.IsType<Discount>(discount);
            Assert.Equal("PaidInFull", discount.Name);
        }
    }
}