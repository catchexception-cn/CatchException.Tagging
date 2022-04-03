namespace CatchException.Tagging.Tagging;

public class TagEto : ITagData
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}