using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;
using LlmTornado.Models;

namespace LlmTornado.Chat.Models;

/// <summary>
/// Known chat models from Anthropic.
/// </summary>
public class ChatModelAnthropic : BaseVendorModelProvider
{
    /// <summary>
    /// Claude 3 models.
    /// </summary>
    public readonly ChatModelAnthropicClaude3 Claude3 = new ChatModelAnthropicClaude3();
    
    /// <summary>
    /// Claude 3.5 models.
    /// </summary>
    public readonly ChatModelAnthropicClaude35 Claude35 = new ChatModelAnthropicClaude35();
    
    /// <summary>
    /// Claude 3.7 models.
    /// </summary>
    public readonly ChatModelAnthropicClaude37 Claude37 = new ChatModelAnthropicClaude37();
    
    /// <summary>
    /// Claude 4 models.
    /// </summary>
    public readonly ChatModelAnthropicClaude4 Claude4 = new ChatModelAnthropicClaude4();
    
    /// <summary>
    /// Claude 4.1 models.
    /// </summary>
    public readonly ChatModelAnthropicClaude41 Claude41 = new ChatModelAnthropicClaude41();
    
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Anthropic;

    /// <summary>
    /// All known chat models from Anthropic.
    /// </summary>
    public override List<IModel> AllModels => ModelsAll;
    
    /// <summary>
    /// Checks whether the model is owned by the provider.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public override bool OwnsModel(string model)
    {
        return AllModelsMap.Contains(model);
    }

    /// <summary>
    /// Map of models owned by the provider.
    /// </summary>
    public static HashSet<string> AllModelsMap => LazyAllModelsMap.Value;
    
    private static readonly Lazy<HashSet<string>> LazyAllModelsMap = new Lazy<HashSet<string>>(() =>
    {
        HashSet<string> map = [];

        ModelsAll.ForEach(x => { map.Add(x.Name); });

        return map;
    });

    /// <summary>
    /// <inheritdoc cref="AllModels"/>
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [..ChatModelAnthropicClaude3.ModelsAll, ..ChatModelAnthropicClaude35.ModelsAll, ..ChatModelAnthropicClaude37.ModelsAll, ..ChatModelAnthropicClaude4.ModelsAll, ..ChatModelAnthropicClaude41.ModelsAll]);
    
    internal ChatModelAnthropic()
    {
      
    }
}