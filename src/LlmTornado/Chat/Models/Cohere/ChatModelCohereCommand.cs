using System;
using System.Collections.Generic;
using LlmTornado.Code;
using LlmTornado.Code.Models;

namespace LlmTornado.Chat.Models;

/// <summary>
/// Command class models from Anthropic.
/// </summary>
public class ChatModelCohereCommand : IVendorModelClassProvider
{
    /// <summary>
    /// Command A Translate is Cohere’s state of the art machine translation model, excelling at a variety of translation tasks on 23 languages: English, French, Spanish, Italian, German, Portuguese, Japanese, Korean, Chinese, Arabic, Russian, Polish, Turkish, Vietnamese, Dutch, Czech, Indonesian, Ukrainian, Romanian, Greek, Hindi, Hebrew, Persian.
    /// </summary>
    public static readonly ChatModel ModelATranslate2508 = new ChatModel("command-a-translate-08-2025", LLmProviders.Cohere, 8_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelATranslate2508"/>
    /// </summary>
    public readonly ChatModel ATranslate2508 = ModelATranslate2508;
    
    /// <summary>
    /// A hybrid reasoning model designed to excel at complex agentic tasks, in English and 22 other languages. With 111 billion parameters and a 256K context length, this model brings advanced reasoning capabilities.
    /// </summary>
    public static readonly ChatModel ModelAReasoning2508 = new ChatModel("command-a-reasoning-08-2025", LLmProviders.Cohere, 256_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelAReasoning2508"/>
    /// </summary>
    public readonly ChatModel AReasoning2508 = ModelAReasoning2508;
    
    /// <summary>
    /// Command A Vision is our first model capable of processing images, excelling in enterprise use cases such as analyzing charts, graphs, and diagrams, table understanding, OCR, document Q&A, and scene analysis. It officially supports English, Portuguese, Italian, French, German, and Spanish.
    /// </summary>
    public static readonly ChatModel ModelAVision2507 = new ChatModel("command-a-vision-07-2025", LLmProviders.Cohere, 128_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelAVision2507"/>
    /// </summary>
    public readonly ChatModel AVision2507 = ModelAVision2507;
    
    /// <summary>
    /// Command A is Cohere’s most performant model to date, excelling at real world enterprise tasks including tool use, retrieval augmented generation (RAG), agents, and multilingual use cases. With 111B parameters and a context length of 256K, Command A boasts a considerable increase in inference-time efficiency — 150% higher throughput compared to its predecessor Command R+ 08-2024 — and only requires two GPUs (A100s / H100s) to run.
    /// </summary>
    public static readonly ChatModel ModelA0325 = new ChatModel("command-a-03-2025", LLmProviders.Cohere, 256_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelA0325"/>
    /// </summary>
    public readonly ChatModel A0325 = ModelA0325;
    
    /// <summary>
    /// 7B open-weights model optimized for Arabic language (MSA dialect), in addition to English.
    /// </summary>
    public static readonly ChatModel ModelR7BArabic2412 = new ChatModel("command-r7b-arabic-02-2025", LLmProviders.Cohere, 128_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelR7BArabic2412"/>
    /// </summary>
    public readonly ChatModel R7BArabic2412 = ModelR7BArabic2412;
    
    /// <summary>
    /// Newest model from 24/08. Command R+ is an instruction-following conversational model that performs language tasks at a higher quality, more reliably, and with a longer context than previous models. It is best suited for complex RAG workflows and multi-step tool use.
    /// </summary>
    public static readonly ChatModel ModelRPlus2408 = new ChatModel("command-r-plus-08-2024", LLmProviders.Cohere, 128_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelRPlus2408"/>
    /// </summary>
    public readonly ChatModel RPlus2408 = ModelRPlus2408;
    
    /// <summary>
    /// Be advised that command-nightly is the latest, most experimental, and (possibly) unstable version of its default counterpart. Nightly releases are updated regularly, without warning, and are not recommended for production use.
    /// </summary>
    public static readonly ChatModel ModelNightly = new ChatModel("command-nightly", LLmProviders.Cohere, 128_000);
    
    /// <summary>
    /// <inheritdoc cref="ModelNightly"/>
    /// </summary>
    public readonly ChatModel CommandNightly = ModelNightly;
    
    /// <summary>
    /// An instruction-following conversational model that performs language tasks with high quality, more reliably and with a longer context than our base generative models.
    /// </summary>
    public static readonly ChatModel ModelDefault = new ChatModel("command", LLmProviders.Cohere, 4_000);

    /// <summary>
    /// <inheritdoc cref="ModelDefault"/>
    /// </summary>
    public readonly ChatModel Default = ModelDefault;
    
    /// <summary>
    /// Newest model from 24/08. An instruction-following conversational model that performs language tasks with high quality, more reliably and with a longer context than our base generative models.
    /// </summary>
    public static readonly ChatModel ModelDefault2408 = new ChatModel("command-r-08-2024", LLmProviders.Cohere, 4_000);

    /// <summary>
    /// <inheritdoc cref="ModelDefault2408"/>
    /// </summary>
    public readonly ChatModel Default2408 = ModelDefault2408;
    
    /// <summary>
    /// Smallest, fastest, and final model in R family. Note this model ignores system prompt when server from official API.
    /// </summary>
    public static readonly ChatModel ModelR7B = new ChatModel("command-r7b-12-2024", LLmProviders.Cohere, 128_000);

    /// <summary>
    /// <inheritdoc cref="ModelDefault2408"/>
    /// </summary>
    public readonly ChatModel R7B = ModelR7B;
    
    /// <summary>
    /// Be advised that command-light-nightly is the latest, most experimental, and (possibly) unstable version of its default counterpart. Nightly releases are updated regularly, without warning, and are not recommended for production use.
    /// </summary>
    public static readonly ChatModel ModelLightNightly = new ChatModel("command-light-nightly", LLmProviders.Cohere, 4_000);

    /// <summary>
    /// <inheritdoc cref="ModelLightNightly"/>
    /// </summary>
    public readonly ChatModel CommandLightNightly = ModelLightNightly;
    
    /// <summary>
    /// All known Coral models from Cohere.
    /// </summary>
    public static List<IModel> ModelsAll => LazyModelsAll.Value;

    private static readonly Lazy<List<IModel>> LazyModelsAll = new Lazy<List<IModel>>(() => [ModelRPlus2408, ModelNightly, ModelDefault, ModelDefault2408, ModelLightNightly, ModelR7B, ModelR7BArabic2412, ModelA0325, ModelAVision2507, ModelAReasoning2508, ModelATranslate2508]);

    /// <summary>
    /// <inheritdoc cref="ModelsAll"/>
    /// </summary>
    public List<IModel> AllModels => ModelsAll;

    internal ChatModelCohereCommand()
    {

    }
}