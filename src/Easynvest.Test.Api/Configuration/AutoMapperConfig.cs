using AutoMapper;
using Easynvest.Test.Api.ViewModel;
using Easynvest.Test.Domain.Entities;

namespace Easynvest.Test.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<OrdemCompra, OrdemCompraViewModel>().ReverseMap();
        }
    }
}