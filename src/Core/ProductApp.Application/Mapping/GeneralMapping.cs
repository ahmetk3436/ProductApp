using AutoMapper;
using ProductApp.Application.Features.Commands.CreateProductCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Domain.Entities.Product,Dto.ProductViewDto>().ReverseMap();
            CreateMap<Domain.Entities.Product, CreateProductCommand>().ReverseMap();
        }
    }
}
