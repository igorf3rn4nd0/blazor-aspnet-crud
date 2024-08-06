namespace ClientApp.Services;

public class NotificationService
{
    public event Action<string, string>? OnShow;
    public event Action? OnHide;

    public void ShowNotification(string message, string color = "text-bg-danger")
    {
        OnShow?.Invoke(message, color);
    }

    public void HideNotification()
    {
        OnHide?.Invoke();
    }
}