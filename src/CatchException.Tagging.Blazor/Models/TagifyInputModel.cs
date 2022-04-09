using System.Text.Json.Serialization;

namespace CatchException.Tagging.Blazor.Models;

public class TagifyInputModel
{
    [JsonPropertyName("value")]
    public string Value { get; set; } = default!;
}