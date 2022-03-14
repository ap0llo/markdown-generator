using CommandLine;
using Grynwald.MarkdownGenerator;
using Spectre.Console;
using XmlDocMarkdown.Core;

var settings = new XmlDocMarkdownSettings()
{
    IncludeObsolete = true,
    GenerateToc = false,
    VisibilityLevel = XmlDocVisibilityLevel.Public,
    NamespacePages = true,
    ShouldClean = true,
};

var parser = new Parser(config =>
{
    config.CaseSensitive = false;
    config.CaseInsensitiveEnumValues = true;
    config.HelpWriter = Console.Out;
});


return parser.ParseArguments<GenerateCommandLineParameters, ValidateCommandLineParameters>(args).MapResult(
    (GenerateCommandLineParameters generateParameters) =>
    {
        AnsiConsole.MarkupLine("[white]Generating API documentation...[/]");
        var result = XmlDocMarkdownGenerator.Generate(typeof(MdDocument).Assembly.Location, generateParameters.ApiReferencePath, settings);
        var upToDate = result.Added.Count + result.Removed.Count + result.Changed.Count == 0;

        PrintMessages(result);
        AnsiConsole.MarkupLine(
            upToDate
                ? "[green]Auto-generated API documentation is already up-to-date.[/]"
                : "[green]Auto-generated API documentation updated.[/]");

        return 0;
    },
    (ValidateCommandLineParameters validateParameters) =>
    {
        AnsiConsole.MarkupLine("[white]Validating auto-generated API documentation...[/]");
        settings.IsDryRun = true;
        var result = XmlDocMarkdownGenerator.Generate(typeof(MdDocument).Assembly.Location, validateParameters.ApiReferencePath, settings);
        var upToDate = result.Added.Count + result.Removed.Count + result.Changed.Count == 0;

        PrintMessages(result);

        if (upToDate)
        {
            AnsiConsole.MarkupLine("[green]Auto-generated API documentation is up-to-date.[/]");
            return 0;
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Auto-generated API documentation is outdated[/]");
            return 1;
        }
    },
    errors =>
    {
        if (errors.All(e => e is HelpRequestedError || e is VersionRequestedError))
        {
            return 0;
        }

        AnsiConsole.MarkupLine("[red]Invalid arguments[/]");
        return 1;
    });


void PrintMessages(XmlDocMarkdownResult xmlDocResult)
{
    foreach (var message in xmlDocResult.Messages)
    {
        AnsiConsole.WriteLine($"  {message}");
    }
}

class CommandLineParameterBase
{
    [Option("apiReferencePath", Required = true)]
    public string ApiReferencePath { get; set; } = "";
}

[Verb("generate", HelpText = "Update all generated documentation files")]
class GenerateCommandLineParameters : CommandLineParameterBase
{ }

[Verb("validate", HelpText = "Validate all documentation files")]
class ValidateCommandLineParameters : CommandLineParameterBase
{ }
