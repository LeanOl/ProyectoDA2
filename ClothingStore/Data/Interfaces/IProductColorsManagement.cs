using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IProductColorsManagement
    {

        IEnumerable<ProductColor> GetAllProductsColors();
        ProductColor GetColorById(Guid id);
        IEnumerable<string> GetColorByProductId(Guid productId);
        void InsertColor(ProductColor color);
        void UpdateColor(ProductColor color);
        void DeleteColor(Guid id);

    }
}
