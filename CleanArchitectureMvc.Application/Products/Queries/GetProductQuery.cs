using CleanArchitectureMvc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureMvc.Application.Products.Queries
{
    public class GetProductQuery : IRequest<IEnumerable<Product>>
    {
    }
}
