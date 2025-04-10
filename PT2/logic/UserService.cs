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

    }
}
