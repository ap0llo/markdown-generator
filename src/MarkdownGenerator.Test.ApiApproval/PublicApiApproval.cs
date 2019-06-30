using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using Grynwald.MarkdownGenerator;
using PublicApiGenerator;
using Xunit;

namespace MarkdownGenerator.Test.ApiApproval
{
    [UseReporter(typeof(DiffReporter))]
    public class PublicApiApproval
    {
        [Fact]
        public void MarkdownGenerator_must_not_have_unapproved_API_changes()
        {
            // ARRANGE
            var assembly = typeof(MdDocument).Assembly;

            // ACT
            var publicApi = ApiGenerator.GeneratePublicApi(assembly);

            // ASSERT
            var writer = new ApprovalTextWriter(publicApi);
            Approvals.Verify(writer, new UnitTestFrameworkNamer(), Approvals.GetReporter());
        }
    }
}
