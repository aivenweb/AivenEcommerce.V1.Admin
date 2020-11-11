using System;

namespace AivenEcommerce.V1.Admin.Wasm.Services.ComponentServices
{
    public class AlertComponentService
    {
        public event Action<string, string, string> OnShow;
        public event Action OnHide;

        public void Show(string title, string message, string color)
        {
            OnShow?.Invoke(title, message, color);
        }

        public void Hide()
        {
            OnHide?.Invoke();
        }
    }
}
