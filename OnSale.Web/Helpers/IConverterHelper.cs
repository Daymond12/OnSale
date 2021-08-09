using OnSale.Common.Entities;
using OnSale.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnSale.Web.Helpers
{
    public interface IConverterHelper
    {
        Category ToCategory(CategoryViewModel model, Guid imageId, bool isNew);

        CategoryViewModel ToCategoryViewModel(Category category);

        //recibe un  ProductViewModel y retorna un producto
        //este metodo se recomienda que sea asincrono, porque al usuario
        //seleccionar una categoria hay que consultar la BD
        Task<Product> ToProductAsync(ProductViewModel model, bool isNew);

        //recibe un producto y retorna  ProductViewModel
        ProductViewModel ToProductViewModel(Product product);

    }

}
