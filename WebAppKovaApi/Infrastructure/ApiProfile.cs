using AutoMapper;
using WebAppKovaApi.Contracts;
using WebAppKovaApi.Models;
using WebAppKovaApi.PackingListServises.Contracts.Models;

namespace WebAppKovaApi.Infrastructure
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<SupplierModel, SupplierApiModel>(MemberList.Destination);

            CreateMap<AddSupplierApiModel, AddSupplierModel>(MemberList.Destination);

            CreateMap<AddSupplierApiModel, AddSupplierModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.)
        }
    }
}
