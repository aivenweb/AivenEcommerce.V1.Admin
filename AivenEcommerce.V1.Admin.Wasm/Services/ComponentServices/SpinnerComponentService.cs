using System;

namespace AivenEcommerce.V1.Admin.Wasm.Services.ComponentServices
{
    public class SpinnerComponentService
    {
        public event Action OnShow;
        public event Action OnHide;

        public void Show()
        {
            OnShow?.Invoke();
        }

        public void Hide()
        {
            OnHide?.Invoke();
        }
    }
}
