using Products.Contracts.Models;
using Products.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products.Service.DataBoundary
{
    public static class ProductComposer
    {
        public static Product ProductFromDto(ProductDto dto)
        {
            if (dto == null) return null;

            return new Product()
            {
                Name = dto.Name,
                Description = dto.Description,
                Inventory = dto.Inventory,
                ProductID = dto.ProductID,
                PurchasePrice = dto.PurchasePrice,
                SalePrice = dto.SalePrice,
                UnitQuantity = dto.UnitQuantity
            };
        }

        public static ProductDto DtoFromProduct(Product product)
        {
            if (product == null) return null;

            return new ProductDto()
            {
                Name = product.Name,
                Description = product.Description,
                Inventory = product.Inventory,
                ProductID = product.ProductID,
                PurchasePrice = product.PurchasePrice,
                SalePrice = product.SalePrice,
                UnitQuantity = product.UnitQuantity
            };
        }
    }
}