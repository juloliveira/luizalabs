using AutoMapper;
using Luizalabs.Challenge.Contracts.v1.Responses;
using Luizalabs.Challenge.Core;

namespace Luizalabs.Challenge.Api.MappingProfiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Customer, CustomerResponse>()
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
        }
    }
}
