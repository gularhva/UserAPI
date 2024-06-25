using UserAPI.DTOs;
using UserAPI.Entities;
using UserAPI.Models;

namespace UserAPI.Abstractions
{
    public interface IUserService
    {
        public ResponseModel<IEnumerable<User>> Get();
        public ResponseModel<User> Post(UserDTO model);
        public ResponseModel<User> Delete(int id);
        public ResponseModel<User> Update(int id, UserDTO model);
        public User GetById(int id);
    }
}
