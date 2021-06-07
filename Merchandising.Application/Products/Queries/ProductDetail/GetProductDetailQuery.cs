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

namespace Merchandising.Application.Products.Queries.ProductDetail
{
    public class GetProductDetailQuery : IRequest<ProductDetailVm>
    {
        public int Id { get; set; }
    }

    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDetailVm> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {

            return new ProductDetailVm
            {
                Product = await _context.Products.Where(t => t.Id == request.Id)
                                             .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                                             .SingleOrDefaultAsync(cancellationToken)
            };

        }
    }
}
