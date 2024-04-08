using Nito.AsyncEx;
using ReactiveUI;
using Serilog;
using System;

namespace Equipments.AvaloniaUI.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public event EventHandler<string>? OnError;
    public void OnErrorHandler(string? error)
    {
        Log.Information(error ?? "[null]");
        OnError?.Invoke(this, error ?? "[null]");
    }

    public INotifyTaskCompletion? Notify { get; set; }

}
