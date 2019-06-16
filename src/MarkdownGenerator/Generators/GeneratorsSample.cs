using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Grynwald.MarkdownGenerator.Generators
{
    class DocumentMapperSample
    {

        static void Example()
        {
            var generator = new DocumentGenerator();


            generator.AddHandler((DirectoryInfo dir, DocumentGenerator context) =>
            {
                var fileList = new MdBulletList();

                var document = new MdDocument(
                    new MdHeading(1, $"Directory {dir.Name}"),
                    new MdHeading(2, "Files"),
                    fileList);

                context.RegisterDocument(dir, $"dirs/{dir.Name}.md", document);


                foreach (var file in dir.EnumerateFiles())
                {
                    context.AddItem(file);

                    fileList.Add(new MdListItem(context.TryGetLink(dir, file, file.Name)));                    
                }

            });

            generator.AddHandler((FileInfo file, DocumentGenerator context) =>
            {
                var document = new MdDocument(
                    new MdHeading(1, $"File {file.Name}"),
                    new MdParagraph("Last Write Time: " + file.LastWriteTime.ToString())
                );

                context.RegisterDocument(file, $"files/{file.Name}.md", document);

                var parentDirectoryInfo = new DirectoryInfo(file.DirectoryName);

                document.Root.Add(
                    new MdParagraph("Parent directory: ", context.TryGetLink(file, parentDirectoryInfo, parentDirectoryInfo.Name))
                );
            });


            foreach(var dir in new DirectoryInfo("C:\\Example").EnumerateDirectories())
            {
                generator.AddItem(dir);
            }

        }

    }
}
