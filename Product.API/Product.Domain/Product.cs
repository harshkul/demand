using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain
{
    public class Product : EntityBase
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

    }
}
