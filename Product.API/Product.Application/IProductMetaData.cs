using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Application
{
    public interface IProductMetaData
    {
        void AddProductMetaData(int ProductID, string key, string value);

        void UpdateProductMetaDat(int ID, string key, string value);

        void DeleteProductMetaData(int ProductID, string key);
    }
}
