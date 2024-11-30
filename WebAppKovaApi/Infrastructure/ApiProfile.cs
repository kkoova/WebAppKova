using AutoMapper;
using WebAppKovaApi.Contracts;
using WebAppKovaApi.Models;

namespace WebAppKovaApi.Infrastructure
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<Supplier, SupplierApiModel>(MemberList.Destination);

            CreateMap<AddSupplierApiModel, Supplier>(MemberList.Destination)
                .ForMember(x => x.Id, _ => Guid.NewGuid())
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(_ => DateTimeOffset.Now))
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(_ => DateTimeOffset.Now))
                .ForMember(x => x.Deleted, opt => opt.Ignore());
        }
    }
}
