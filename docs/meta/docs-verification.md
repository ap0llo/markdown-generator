# Verification of documentation code samples

All C# code samples that are part of the documentation are verified
automatically to ensure they are valid C# code.

This is implemented in the unit test project
[MarkdownGenerator.Test.DocsVerification](../../src/MarkdownGenerator.Test.DocsVerification).

The unit test project proceeds as follows:

- All markdown documents under `docs/examples` and `docs/api` are parsed
- All fenced code blocks with a `csharp` infostring are extracted from the document
- Each code sample is checked syntactically and semantically using
  [Roslyn](https://github.com/dotnet/roslyn)
- If Roslyn finds no errors, code sample is valid and could be compiled
  and executed.

When a code sample is not valid C# or cannot be compiled with the current
version of Markdown Generator (e.g. when APIs are changed), the corresponding 
test case will fail.