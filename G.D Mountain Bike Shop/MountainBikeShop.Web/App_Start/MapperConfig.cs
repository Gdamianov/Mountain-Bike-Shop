using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MounrainBikeShop.Models;
using MountainBikeShop.Web.Models.ViewModels;
using MountainBikeShop.Web.Models.BindingModels;

namespace MountainBikeShop.Web.App_Start
{
    public  static class MapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.CreateMap<MountainBikeAdd, BikeViewModel>()
                .ForMember(vm => vm.Email, m => m.MapFrom(b => b.User.Email))
                .ForMember(vm => vm.Phone, m => m.MapFrom(b => b.User.Phone))
                .ForMember(vm => vm.Username, m => m.MapFrom(b => b.User.UserName));
            Mapper.CreateMap<ForkAdd, ForkViewModel>()
                .ForMember(vm => vm.Email, m => m.MapFrom(b => b.User.Email))
                .ForMember(vm => vm.Phone, m => m.MapFrom(b => b.User.Phone))
                .ForMember(vm => vm.Username, m => m.MapFrom(b => b.User.UserName));
            Mapper.CreateMap<FrameAdd, FrameViewModel>()
                .ForMember(vm => vm.Email, m => m.MapFrom(b => b.User.Email))
                .ForMember(vm => vm.Phone, m => m.MapFrom(b => b.User.Phone))
                .ForMember(vm => vm.Username, m => m.MapFrom(b => b.User.UserName));


            Mapper.CreateMap<BikeBindingModel, MountainBikeAdd>();
            Mapper.CreateMap<ForkBindingModel, ForkAdd>();
            Mapper.CreateMap<FrameBindingModel, FrameAdd>();

            Mapper.CreateMap<MountainBikeAdd, BikeBindingModel>();
       }
    }
}