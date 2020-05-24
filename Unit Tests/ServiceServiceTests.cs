using System.Collections.Generic;
using BLL.Logic;
using DAL.Models;
using DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BLL.DTO;
using DAL;
using System;

namespace Unit_Tests
{
    [TestClass]
    public class ServiceServiceTests
    {
        private IServiceActions _serviceService;

        private Mock<UnitOfWork> _unitOfWork;

        private Mock<IGenericRepository<Service>> _serviceRepository;

        private List<Service> services;

        [TestInitialize]
        public void Initialize()
        {
            _serviceRepository = new Mock<IGenericRepository<Service>>();
            var userRepository = new Mock<IGenericRepository<User>>();
            var agencyContext = new Mock<Context>();

            _unitOfWork = new Mock<UnitOfWork>(agencyContext.Object, userRepository.Object, _serviceRepository.Object);

            _serviceService = new ServiceActions(_unitOfWork.Object);
        }


        [TestMethod]
        public void GetServices_ReturnsCorrectNumberOfServices()
        {
            //Arrange
            services = new List<Service>
            {
                new Service(){Name ="First"},
                 new Service(){Name ="Second"},
                  new Service(){Name ="Third"},

            };

            _serviceRepository.Setup(x => x.Get()).Returns(services);

            //Act
            var result = _serviceService.GetServices();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void AddService_CalledCreateMethod()
        {
            //Arrange
            _serviceRepository.Setup(x => x.Create(It.IsAny<Service>()));

            //Act
            _serviceService.AddService(new ServiceDto());

            //Assert
            _serviceRepository.Verify(x => x.Create(It.IsAny<Service>()), Times.Once);
        }

        [TestMethod]
        public void UpdateService_CalledUpdateMethod()
        {
            //Arrange
            _serviceRepository.Setup(x => x.GetOne(It.IsAny<Func<Service, bool>>()))
                .Returns(new Service() { ServiceId = 1, Name = "First" });

            _serviceRepository.Setup(x => x.Update(It.IsAny<Service>()));

            //Act
            _serviceService.UpdateService(1, new ServiceDto());

            //Assert
            _serviceRepository.Verify(x => x.Update(It.IsAny<Service>()), Times.Once);
        }

        [TestMethod]
        public void GetServiceByID_ReturnsCorrectNumberOfServices()
        {
            //Arrange
            var expectedService = new Service() { ServiceId = 1, Name = "First" };
            _serviceRepository.Setup(x => x.GetOne(It.IsAny<Func<Service, bool>>()))
               .Returns(expectedService);

            //Act
            var result = _serviceService.GetServiceByID(1);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedService.ServiceId, result.ServiceId);
            Assert.AreEqual(expectedService.Name, result.Name);
        }

        [TestMethod]
        public void RemoveServiceByID_ReturnsCorrectNumberOfServices()
        {
            //Arrange
            var expectedService = new Service() { ServiceId = 1, Name = "First" };
            _serviceRepository.Setup(x => x.Remove(expectedService));

            //Act
            _serviceService.RemoveServiceByID(1);

            //Assert
            _serviceRepository.Verify(x => x.Remove(It.IsAny<Service>()), Times.Once);
        }
    }
}
