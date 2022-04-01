namespace CatchException.Tagging;

public static class TaggingDbProperties
{
    public static string DbTablePrefix { get; set; } = "Tagging";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Tagging";
}
