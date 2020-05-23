using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL.Repository;

namespace BLL.Logic
{
    internal class UserActions : IUserActions
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _userMapper;

        private readonly IMapper _userUpdateMapper;

        public UserActions(IUnitOfWork unitOfWork)
        {
            _userMapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>()).CreateMapper();

            _userUpdateMapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDto, User>()).CreateMapper();

            _unitOfWork = unitOfWork;
        }

        public void AddUser(UserDto userDto)
        {
            _unitOfWork.Users.Create(new User { Name = userDto.Name, Login = userDto.Login, Pass = userDto.Pass, RoleName = userDto.RoleName });
            _unitOfWork.Save();
        }

        public UserDto GetUserByID(int id)
        {
            return _userMapper.Map<User, UserDto>(_unitOfWork.Users.GetOne(x => (x.UserId == id)));
        }

        public ICollection<UserDto> GetUsers()
        {
            return _userMapper.Map<IEnumerable<User>, List<UserDto>>(_unitOfWork.Users.Get());
        }

        public void RemoveUserByID(int id)
        {
            _unitOfWork.Users.Remove(_unitOfWork.Users.FindById(id));
            _unitOfWork.Save();
        }

        public void Updateuser(int id, UserDto userDto)
        {
            var userForUpdate = GetUserByID(id);

            if (userForUpdate != null)
            {
                _unitOfWork.Users.Update(_userUpdateMapper.Map<UserDto, User>(userDto));
            }
        }
    }
}
