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


    public string AddAccount(string name, string email, string password)
    {
        try
        {
            var lastaccount = _adminAccounts.LastOrDefault();
            int id = 0;
            if (lastaccount == null)
            {
                id = 1;
            }
            else
            {
                id = lastaccount.Id + 1;
            }
            _adminAccounts.Add(new AdminAccountModel(id, email, password, name));
            AdminAccountsAccess.WriteAll(_adminAccounts);
            return $"The new account has been added";
        }
        catch (Exception)
        {
            return $"An error has occurred";
        }
    }


    public string DeleteAdmin(int ID, string email)
    {
        var targetAccount = _adminAccounts.FirstOrDefault(x => x.Id == ID && x.EmailAddress == email);

        if (targetAccount != null)
        {
            if (_adminAccounts.Count() > 1)
            {
                _adminAccounts.Remove(targetAccount);
                AdminAccountsAccess.WriteAll(_adminAccounts);
                return $"The account with ID: {ID} and email: {email} has been deleted";
            }
        }
        else
        {
            return $"The account with ID: {ID} and email: {email} does not exist";
        }
        return "";
    }
}