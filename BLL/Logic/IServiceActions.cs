using DAL.Models;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Logic
{
    public interface IServiceActions
    {
        ICollection<ServiceDto> GetServices();

        ServiceDto GetServiceByID(int id);

        void AddService(ServiceDto serviceDto);

        void UpdateService(int id, ServiceDto serviceDto);

        void RemoveServiceByID(int id);

        bool SellService(int userId, int serviceId);
    }
}
