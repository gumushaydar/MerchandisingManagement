using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Merchandising.Application.Common.Interfaces;
using Merchandising.Application.Products.Queries.ProductDetail;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Merchandising.Application.Products.Queries
{
    public class SearchProductQuery : IRequest<ProductsVm> 
    {
        public string Keyword { get; set; }
    }

    public class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, ProductsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SearchProductQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductsVm> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            
                return new ProductsVm
            {
                Products = await _context.Products
                                    .Include(t => t.Category)
                                    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                                    .Where(t => t.Description.Contains(request.Keyword) || t.Category.Name.Contains(request.Keyword) || t.Title.Contains(request.Keyword))
                                    .Where(t => t.StockQuantity > t.Category.MinimumStockQuantity)
                                    .ToListAsync(cancellationToken)
            };

        }
    }
}
 