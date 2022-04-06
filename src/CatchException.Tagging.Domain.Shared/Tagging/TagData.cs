namespace CatchException.Tagging.Tagging;

public class TagData : ITagData
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }

    public TagData(
        Guid id,
        string name,
        string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}