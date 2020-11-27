using System.Collections.Generic;

namespace AivenEcommerce.V1.Admin.Wasm.Domain.Paginations
{
    public class PagedResult<T> : Paged
    {
        public IEnumerable<T> Items { get; set; }

        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

    }
}
