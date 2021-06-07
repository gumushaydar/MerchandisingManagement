using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Merchandising.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Merchandising.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<ProductsVm>
    {
    }


    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ProductsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ProductsVm> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return new ProductsVm
            {
                Products = await _context.Products
                .Include(t => t.Category)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .Where(t => t.Category.MinimumStockQuantity < t.StockQuantity)
                .ToListAsync(cancellationToken)
            };
        }
    }
}
