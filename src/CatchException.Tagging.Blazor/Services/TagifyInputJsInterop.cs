using CatchException.Tagging.Blazor.Components;
using Microsoft.JSInterop;
using Volo.Abp.DependencyInjection;

namespace CatchException.Tagging.Blazor.Services;

public class TagifyInputJsInterop : IAsyncDisposable, IScopedDependency
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public TagifyInputJsInterop(IJSRuntime jsRuntime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/CatchException.Tagging.Blazor/tagify-input.js").AsTask());
    }

    public async ValueTask InitialAsync(DotNetObjectReference<TagifyInput> tagsInput, Guid id)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("initial", tagsInput, id);
    }
    
    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}