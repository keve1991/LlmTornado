﻿using LlmTornado.Agents.ChatRuntime.Orchestration;
using LlmTornado.Agents.DataModels;
using LlmTornado.Chat;

namespace LlmTornado.Agents.ChatRuntime.RuntimeConfigurations;

/// <summary>
/// Used to create StateMachine like orchestrations for chat runtimes.
/// </summary>
public class OrchestrationRuntimeConfiguration : Orchestration<ChatMessage, ChatMessage>, IRuntimeConfiguration
{
    public ChatRuntime Runtime { get; set; }
    public CancellationTokenSource cts { get; set; } = new CancellationTokenSource();
    public Func<ChatRuntimeEvents, ValueTask>? OnRuntimeEvent { get; set; }
    private PersistedConversation _messageHistory { get;  set; } 
    public string? MessageHistoryFileLocation { get; set; }
    public Func<OrchestrationRuntimeConfiguration, ValueTask>? CustomInitialization { get; set; }

    public OrchestrationRuntimeConfiguration()
    {

    }

    private void LoadMessageHistory()
    {
        if(MessageHistoryFileLocation != null)
            _messageHistory = new PersistedConversation(MessageHistoryFileLocation);
    }

    public virtual void OnRuntimeInitialized()
    {
        OnOrchestrationEvent += (e) =>
        {
            // Forward orchestration events to runtime
            this.OnRuntimeEvent?.Invoke(new ChatRuntimeOrchestrationEvent(e, Runtime?.Id ?? string.Empty));
        };

        LoadMessageHistory();

        CustomInitialization?.Invoke(this).GetAwaiter().GetResult();
    }

    public void CancelRuntime()
    {
        cts.Cancel();
        OnRuntimeEvent?.Invoke(new ChatRuntimeCancelledEvent(Runtime.Id));
    }

    public virtual async ValueTask<ChatMessage> AddToChatAsync(ChatMessage message, CancellationToken cancellationToken = default)
    {
        // Invoke the StartingExecution event to signal the beginning of the execution process
        OnRuntimeEvent?.Invoke(new ChatRuntimeStartedEvent(Runtime.Id));

        _messageHistory.AppendMessage(message);

        await InvokeAsync(message);

        _messageHistory.AppendMessage(Results?.Last() ?? new ChatMessage(Code.ChatMessageRoles.Assistant, "Some sort of error"));

        _messageHistory.SaveChanges();

        OnRuntimeEvent?.Invoke(new ChatRuntimeCompletedEvent(Runtime.Id));

        return GetLastMessage();
    }

    public virtual void ClearMessages()
    {
        _messageHistory.Clear();
    }

    public virtual List<ChatMessage> GetMessages()
    {
        return _messageHistory.Messages;
    }

    public virtual ChatMessage GetLastMessage()
    {
        return _messageHistory.Messages.Last();
    }
}
