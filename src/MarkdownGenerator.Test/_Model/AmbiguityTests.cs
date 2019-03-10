using System.Collections.Generic;

namespace Grynwald.MarkdownGenerator.Test
{
    /// <summary>
    /// Sample code to ensure calls to constructors are not ambiguous
    /// </summary>
    /// <remarks>
    /// This is not really a test class, rather the test is if this code even compiles.
    /// <para>
    /// The implementations of <see cref="MdContainerBlockBase"/> all accept a <see cref="IEnumerable{MdBlock}"/>
    /// as constructor parameters. As some blocks also implement this interface,
    /// some constructor calls can get ambiguous (e.g. <c>new MdListItem(new MdContainerBlock)</c>.
    /// </para>
    /// <para>
    /// To work around this, additional constructors have to be defined in the implementations of <see cref="MdContainerBlockBase"/>.
    /// As long as this class compiles, constructor call are not ambiguous.
    /// </para>
    /// </remarks>
    public class AmbiguityTests
    {
        public void Initialization_of_MdListItem_using_constructor()
        {
            _ = new MdListItem();

            _ = new MdListItem(new MdContainerBlock());
            _ = new MdListItem(new MdContainerBlock(), new MdContainerBlock());

            _ = new MdListItem(new MdListItem());
            _ = new MdListItem(new MdListItem(), new MdListItem());

            _ = new MdListItem(new MdBlockQuote());
            _ = new MdListItem(new MdBlockQuote(), new MdBlockQuote());
        }

        public void Initialization_of_MdListItem_using_FactoryMethods()
        {
            _ = FactoryMethods.ListItem();

            _ = FactoryMethods.ListItem(FactoryMethods.Container());
            _ = FactoryMethods.ListItem(FactoryMethods.Container(), FactoryMethods.Container());

            _ = FactoryMethods.ListItem(FactoryMethods.ListItem());
            _ = FactoryMethods.ListItem(FactoryMethods.ListItem(), FactoryMethods.ListItem());

            _ = FactoryMethods.ListItem(FactoryMethods.BlockQuote());
            _ = FactoryMethods.ListItem(FactoryMethods.BlockQuote(), FactoryMethods.BlockQuote());
        }

        public void Initialization_of_MdContainerBlock_using_constructor()
        {
            _ = new MdContainerBlock();

            _ = new MdContainerBlock(new MdContainerBlock());
            _ = new MdContainerBlock(new MdContainerBlock(), new MdContainerBlock());

            _ = new MdContainerBlock(new MdListItem());
            _ = new MdContainerBlock(new MdListItem(), new MdListItem());

            _ = new MdContainerBlock(new MdBlockQuote());
            _ = new MdContainerBlock(new MdBlockQuote(), new MdBlockQuote());
        }

        public void Initialization_of_MdContainerBlock_using_FactoryMethods()
        {
            _ = FactoryMethods.Container();

            _ = FactoryMethods.Container(FactoryMethods.Container());
            _ = FactoryMethods.Container(FactoryMethods.Container(), FactoryMethods.Container());

            _ = FactoryMethods.Container(FactoryMethods.ListItem());
            _ = FactoryMethods.Container(FactoryMethods.ListItem(), FactoryMethods.ListItem());

            _ = FactoryMethods.Container(FactoryMethods.BlockQuote());
            _ = FactoryMethods.Container(FactoryMethods.BlockQuote(), FactoryMethods.BlockQuote());
        }

        public void Initialization_of_MdBlockQuote_using_constructor()
        {
            _ = new MdBlockQuote();

            _ = new MdBlockQuote(new MdContainerBlock());
            _ = new MdBlockQuote(new MdContainerBlock(), new MdContainerBlock());

            _ = new MdBlockQuote(new MdListItem());
            _ = new MdBlockQuote(new MdListItem(), new MdListItem());

            _ = new MdBlockQuote(new MdBlockQuote());
            _ = new MdBlockQuote(new MdBlockQuote(), new MdBlockQuote());
        }

        public void Initialization_of_MdBlockQuote_using_FactoryMethods()
        {
            _ = FactoryMethods.BlockQuote();

            _ = FactoryMethods.BlockQuote(FactoryMethods.Container());
            _ = FactoryMethods.BlockQuote(FactoryMethods.Container(), FactoryMethods.Container());

            _ = FactoryMethods.BlockQuote(FactoryMethods.ListItem());
            _ = FactoryMethods.BlockQuote(FactoryMethods.ListItem(), FactoryMethods.ListItem());

            _ = FactoryMethods.BlockQuote(FactoryMethods.BlockQuote());
            _ = FactoryMethods.BlockQuote(FactoryMethods.BlockQuote(), FactoryMethods.BlockQuote());
        }
    }
}
