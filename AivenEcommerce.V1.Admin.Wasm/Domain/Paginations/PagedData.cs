using System.Collections.Generic;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Paginations
{
    public class PagedData<T>
    {
        public IEnumerable<T> Items { get; set; }
        public long TotalCount { get; set; }
    }
}
