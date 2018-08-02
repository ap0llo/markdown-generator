namespace Grynwald.MarkdownGenerator
{
    /// <summary>
    /// Internal enum to discriminate between ordered lists and bullet lists.
    /// </summary>
    //TODO: Consider removing this type and insted discriminate based in list class type (MdBulletList / MdOrderedList)
    internal enum MdListKind
    {
        Bullet = 0,
        Ordered = 1
    }
}
