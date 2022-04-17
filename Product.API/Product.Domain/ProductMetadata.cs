using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain
{
    public class ProductMetadata: EntityBase
    {
        public int ProductId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
