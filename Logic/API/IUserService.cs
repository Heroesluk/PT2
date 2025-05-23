﻿using PT2.data.API;

namespace PT2.logic.API
{
    public interface IUserService
    {
        void RegisterUser(string username, string password, string email);
        void LoginUser(String username, String password);
        void RemoveUser(string username);
        bool IsUserRegistered(string username);
        IUser FindUser(string username);

    }
}
