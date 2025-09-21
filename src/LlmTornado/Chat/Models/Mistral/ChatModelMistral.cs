using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models.Mistral;

/// <summary>
/// Known chat models from Mistral.
/// </summary>
public class ChatModelMistral: BaseVendorModelProvider
{
    /// <inheritdoc cref="BaseVendorModelProvider.Provider"/>
    public override LLmProviders Provider => LLmProviders.Mistral;
    
    /// <summary>
    /// All Premier (closed-weights) models.
    /// </summary>
    public readonly ChatModelMistralPremier Premier = new ChatModelMistralPremier();
    
    /// <summary>
    /// All Free (open-weights) models.
    /// </summary>
    public readonly ChatModelMistralFree Free = new ChatModelMistralFree();
    
    /// <summary>
    /// All Research (open-weights) models.
    /// </summary>
    public readonly ChatModelMistralResearch Research = new ChatModelMistralResearch();
    
    /// <summary>
    /// All known chat models from Mistral.
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

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [..ChatModelMistralPremier.ModelsAll, ..ChatModelMistralFree.ModelsAll, ..ChatModelMistralResearch.ModelsAll]);
    
    internal ChatModelMistral()
    {
        
    }
}