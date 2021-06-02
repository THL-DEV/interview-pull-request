using System;
using System.Collections.Generic;


namespace Interview.PullRequest.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Code;
        public string Category { get; set; }
        public IEnumerable<Product> ProductPack { get; set; }
        public decimal? price { get; set; }
    }
}
