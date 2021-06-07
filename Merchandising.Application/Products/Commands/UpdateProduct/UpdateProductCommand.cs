using MediatR;
using Merchandising.Application.Common.Exceptions;
using Merchandising.Application.Common.Interfaces;
using Merchandising.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Merchandising.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);

            if(product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            product.Title = request.Title;
            product.Description = request.Description;
            product.StockQuantity = request.StockQuantity;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
