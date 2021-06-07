using AutoMapper;
using Merchandising.Application.Common.Mappings;
using Merchandising.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merchandising.Application.Products.Queries
{
    public class ProductDto : IMapFrom<Product>
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }

        public Category Category { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>()
                .ForMember(t => t.ProductId, opt => opt.MapFrom(t => t.Id))
                .ForMember(t => t.Category, opt => opt.MapFrom(t => t.Category));
        }
    }
}
