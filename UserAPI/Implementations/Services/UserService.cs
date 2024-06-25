using AutoMapper;
using UserAPI.Abstractions;
using UserAPI.Abstractions.UnitOfWork;
using UserAPI.DTOs;
using UserAPI.Entities;
using UserAPI.Models;

namespace UserAPI.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public ResponseModel<IEnumerable<User>> Get()
        {
            ResponseModel<IEnumerable<User>> rm = new ResponseModel<IEnumerable<User>>();
            try
            {
                //rm.Data = _repository.GetAll();
                rm.Data = _unitOfWork.UserR.GetAll();
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }
        public ResponseModel<User> Post(UserDTO model)
        {
            ResponseModel<User> rm = new ResponseModel<User>();
            try
            {
                User user = _mapper.Map<User>(model);
                rm.Data = user;
                _unitOfWork.UserR.Add(user);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }
        public ResponseModel<User> Delete(int id)
        {
            ResponseModel<User> rm = new ResponseModel<User>();
            try
            {
                var data = _unitOfWork.UserR.GetById(id);
                //_repository.Delete(data);
                _unitOfWork.UserR.Delete(data);
                rm.Data = data;
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }
        public ResponseModel<User> Update(int id, UserDTO model)
        {
            ResponseModel<User> rm = new ResponseModel<User>();
            try
            {
                var data = _unitOfWork.UserR.GetById(id);
                _mapper.Map(model, data);
                //_repository.Update(data);
                _unitOfWork.UserR.Update(data);
                rm.Data = data;
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }

        public User GetById(int id)
        {
            var data = _unitOfWork.UserR.GetById(id);
            return data;
        }
    }
}
