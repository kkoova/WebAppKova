﻿using AutoMapper;
using WebAppKovaApi.Contracts;
using WebAppKovaApi.PackingListServises.Contracts.Models;

namespace WebAppKovaApi.PackingListServises.Infrastructure
{
    public class SupplierSeviseProfile : Profile
    {
        public SupplierSeviseProfile()
        {
            CreateMap<AddSupplierModel, Supplier>(MemberList.Destination)
                .ForMember(x => x.Id, _ => Guid.NewGuid())
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(_ => DateTimeOffset.Now))
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(_ => DateTimeOffset.Now))
                .ForMember(x => x.Deleted, opt => opt.Ignore());

            CreateMap<Supplier, SupplierModel>(MemberList.Destination);
        }
    }
}