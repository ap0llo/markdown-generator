using Grynwald.MarkdownGenerator;
using PublicApiGenerator;
using Shouldly;
using Xunit;

namespace MarkdownGenerator.Test.ApiApproval
{
    public class PublicApiApproval
    {
        [Fact]
        public void MarkdownGenerator_must_not_have_unapproved_API_changes()
        {
            var publicApi = ApiGenerator.GeneratePublicApi(typeof(MdDocument).Assembly);
            publicApi.ShouldMatchApproved();
        }
    }
}
