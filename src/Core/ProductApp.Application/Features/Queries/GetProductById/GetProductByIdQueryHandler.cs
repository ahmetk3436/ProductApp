using AutoMapper;
using MediatR;
using ProductApp.Application.Dto;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery,ServiceResponse<ProductViewDto>>
    {
        IProductRepository repository;
        private readonly IMapper mapper;

        public GetProductByIdQueryHandler(IProductRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<ProductViewDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await repository.GetByIdAsync(request.Id);
            var dto = mapper.Map<ProductViewDto>(product);
            return new ServiceResponse<ProductViewDto>(dto);
        }
    }
}
