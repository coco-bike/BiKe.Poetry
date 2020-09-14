using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace BiKe.Poetry.Pages
{
    public class Index_Tests : PoetryWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
