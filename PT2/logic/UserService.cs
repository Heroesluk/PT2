using System;
using PT2.data.interfaces;
using PT2.data.model;

namespace PT2.logic
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User FindUser(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        public void RegisterUser(String username, String password, String email)
        {
            throw new System.NotImplementedException();
            // TODO: add somevalidation logic
        }
        public void LoginUser(String username, String password)
        {
            throw new System.NotImplementedException();
            // TODO: add somevalidation logic
        }
        
        public void RemoveUser(String username)
        {
            throw new System.NotImplementedException();
            // TODO: add somevalidation logic
        }
        
        
        

    }
}
