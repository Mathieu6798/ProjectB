using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

//This class is not static so later on we can use inheritance and interfaces
class AdminLogic
{
    private List<AdminAccountModel> _adminAccounts;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
    static public AdminAccountModel? CurrentAccount { get; private set; }

    public AdminLogic()
    {
        _adminAccounts = AdminAccountsAccess.LoadAll();
    }

    public AdminAccountModel GetById(int id)
    {
        return _adminAccounts.Find(i => i.Id == id);
    }

    public AdminAccountModel CheckLogin(string email, string password)
    {
        if (email == null || password == null)
        {
            return null;
        }
        CurrentAccount = _adminAccounts.Find(i => i.EmailAddress == email && i.Password == password);
        return CurrentAccount;
    }
}