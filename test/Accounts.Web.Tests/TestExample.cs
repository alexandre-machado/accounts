using Xunit;

namespace Accounts.Web.Tests
{
	public class TestExample
	{
		[Fact]
		public void ThisShouldBeOne()
		{
			Assert.Equal(1, 1);
		}

		[Fact]
		public void ThisShouldBeFail()
		{
			Assert.Equal(1, 1);
		}
	}
}