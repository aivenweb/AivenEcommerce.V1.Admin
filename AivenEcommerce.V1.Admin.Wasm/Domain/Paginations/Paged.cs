namespace AivenEcommerce.V1.Admin.Wasm.Domain.Paginations
{
    public class Paged
    {
        public int CurrentPage { get; set; }
        public long TotalCount { get; set; }
        public long TotalPages { get; set; }
        public int PageSize { get; set; }
    }
}
