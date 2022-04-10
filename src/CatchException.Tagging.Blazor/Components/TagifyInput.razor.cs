using CatchException.Tagging.Blazor.Models;
using CatchException.Tagging.Blazor.Services;
using CatchException.Tagging.Tagging;
using CatchException.Tagging.Tagging.Dtos;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using Volo.Abp.ObjectMapping;

namespace CatchException.Tagging.Blazor.Components;

public partial class TagifyInput
{
    [Parameter] public ICollection<TagifyItemModel> Value { get; set; } = default!;
    [Parameter] public EventCallback<ICollection<TagifyItemModel>> ValueChanged { get; set; }
    [Parameter] public ITagLookupAppService TagLookupAppService { get; set; } = default!;

    [Inject] public ITagAppService TagAppService { get; set; } = default!;
    [Inject] public IObjectMapper ObjectMapper { get; set; } = default!;
    [Inject] public TagifyInputJsInterop JsInterop { get; set; } = default!;

    private static CancellationTokenSource? _cancellationToken;

    private DotNetObjectReference<TagifyInput>? _tagsInput;
    private readonly Guid _elementId = Guid.NewGuid();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            _tagsInput ??= DotNetObjectReference.Create(this);
            await JsInterop.InitialAsync(_tagsInput, _elementId);
        }
    }

    [JSInvokable]
    public async Task<List<TagifyItemModel>> GetWhitelistAsync(string keyword)
    {
        _cancellationToken?.Cancel();
        _cancellationToken = new CancellationTokenSource();

        var tags = (await TagLookupAppService.SearchAsync(
            keyword,
            20,
            _cancellationToken.Token))
            .ToList();
        _cancellationToken = null;

        return ObjectMapper.Map<List<TagData>, List<TagifyItemModel>>(tags);
    }

    [JSInvokable]
    public async Task OnValueChangedAsync(TagifyItemModel[]? values)
    {
        Value = values == null ? new List<TagifyItemModel>() : values.ToList();
        await ValueChanged.InvokeAsync(Value);
    }
}