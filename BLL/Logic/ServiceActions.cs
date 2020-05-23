using AutoMapper;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Logic
{
    internal class ServiceActions : IServiceActions
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _serviceMapper;

        private readonly IMapper _serviceUpdateMapper;

        public ServiceActions(IUnitOfWork unitOfWork)
        {
            _serviceMapper = new MapperConfiguration(cfg => cfg.CreateMap<Service, ServiceDto>()
            .ForMember(x => x.UsersWhoBought, y => y.Ignore())).CreateMapper();

            _serviceUpdateMapper = new MapperConfiguration(cfg => cfg.CreateMap<ServiceDto, Service>()
            .ForMember(x => x.UsersWhoBought, y => y.Ignore())).CreateMapper();

            _unitOfWork = unitOfWork;
        }

        public void AddService(ServiceDto serviceDto)
        {
            try
            {
                _unitOfWork.Services.Create(new Service { Name = serviceDto.Name, Price = serviceDto.Price, Type = serviceDto.Type });
                _unitOfWork.Save();
            }
            catch (Exception exception)
            {
                throw new Exception("Data can not be added!" + $"/n{exception.Message}");
            }
        }

        public void UpdateService(int id, ServiceDto serviceDto)
        {
            var serviceForUpdate = GetServiceByID(id);

            if (serviceForUpdate != null)
            {
                _unitOfWork.Services.Update(_serviceUpdateMapper.Map<ServiceDto, Service>(serviceDto));
            }
        }

        public bool SellService(int userId, int serviceId)
        {
            var user = _unitOfWork.Users.FindById(userId);

            var service = _unitOfWork.Services.FindById(serviceId);

            if (user != null && service != null)
            {
                user.Services.Add(service);
                service.UsersWhoBought.Add(user);
                _unitOfWork.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public ServiceDto GetServiceByID(int id)
        {
            return _serviceMapper.Map<Service, ServiceDto>(_unitOfWork.Services.GetOne(x => (x.ServiceId == id)));
        }

        public ICollection<ServiceDto> GetServices()
        {
            return _serviceMapper.Map<IEnumerable<Service>, List<ServiceDto>>(_unitOfWork.Services.Get());
        }

        public void RemoveServiceByID(int id)
        {
            try
            {
                _unitOfWork.Services.Remove(_unitOfWork.Services.FindById(id));
                _unitOfWork.Save();
            }
            catch (Exception exception)
            {
                throw new Exception("Data can not be removed!" + $"/n{exception.Message}");

            }
        }
    }
}
