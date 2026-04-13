using Microsoft.AspNetCore.Components;

namespace team7slottetfrontend.Services;

public class ModalService
{

    public bool IsOpen { get; private set; }
    public EventCallback<bool> OnAuthResult { get; private set; }
    public event Action OnChange;

    public void Show(EventCallback<bool> onAuthResult)
    {
        OnAuthResult = onAuthResult;
        IsOpen = true;
        OnChange?.Invoke();
    }

    public void Show()
    {
        Console.WriteLine("Show called");
        IsOpen = true;
        OnChange?.Invoke();
        Console.WriteLine($"OnChange is null: {OnChange == null}");
    }

    public void Close()
    {
        IsOpen = false;
        OnChange?.Invoke();
    }
}
