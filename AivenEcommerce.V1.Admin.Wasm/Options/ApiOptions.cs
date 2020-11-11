namespace AivenEcommerce.V1.Admin.Wasm.Options
{
    public interface IApiOptions
    {
        string BaseAddress { get; set; }
    }

    public class ApiOptions : IApiOptions
    {
        public string BaseAddress { get; set; }
    }
}
