using ASP.NET_project.Models;
using ASP.NET_project.ViewModel;
using AutoMapper;

namespace ASP.NET_project.AutoMapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Client, ClientViewModel>();
            CreateMap<ClientViewModel, Client>();

            CreateMap<Service, ServiceViewModel>();
            CreateMap<ServiceViewModel, Service>();

            CreateMap<Worker, WorkerViewModel>();
            CreateMap<WorkerViewModel, Worker>();

            CreateMap<Reservation, ReservationViewModel>();
            CreateMap<ReservationViewModel, Reservation>();
        }
    }
}
