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

            CreateMap<Product, ProductDetail>()
                .ForMember(x => x.Id, o => o.MapFrom(s => s.Id))
                .ForMember(x => x.Title, o => o.MapFrom(s => s.Title))
                .ForMember(x => x.Image, o => o.MapFrom(s => s.Image))
                .ForMember(x => x.Score, o => o.MapFrom(s => s.ReviewScore))
                .ForMember(x => x.Price, o => o.MapFrom(s => s.Price))
                .ForMember(x => x.Brand, o => o.MapFrom(s => s.Brand.Name))
                .ForMember(x => x.Reviews, o => o.MapFrom(s => s.Reviews))
                .IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            CreateMap<Review, ProductReview>()
                .ForMember(x => x.CustomerId, o => o.MapFrom(s => s.Customer.Id))
                .ForMember(x => x.CustomerName, o => o.MapFrom(s => s.Customer.Name))
                .ForMember(x => x.Score, o => o.MapFrom(s => s.Score))
                .ForMember(x => x.Comment, o => o.MapFrom(s => s.Comment));
        }
    }
}
