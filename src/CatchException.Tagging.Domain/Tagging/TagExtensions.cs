namespace CatchException.Tagging.Tagging;

public static class TagExtensions
{
    public static ITagData ToTagData(this ITag tag)
    {
        return new TagData(
            tag.Id,
            tag.Name,
            tag.Description);
    }
    
}