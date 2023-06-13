using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

//This class is not static so later on we can use inheritance and interfaces
public class AdminLogic : BasicLogic<AdminAccountModel>
{
    // private List<AdminAccountModel> _adminAccounts;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
    static public AdminAccountModel? CurrentAccount { get; private set; }

    public AdminLogic()
    {
        _items = AdminAccountsAccess.LoadAll();
    }

    // public AdminAccountModel GetById(int id)
    // {
    //     return _adminAccounts.Find(i => i.Id == id);
    // }

    public AdminAccountModel CheckLogin(string email, string password)
    {
        if (email == null || password == null)
        {
            return null;
        }
        CurrentAccount = _items.Find(i => i.EmailAddress == email && i.Password == password);
        return CurrentAccount;
    }


    public string AddAccount(string name, string email, string password)
    {
        try
        {
            var lastaccount = _items.LastOrDefault();
            int id = 0;
            if (lastaccount == null)
            {
                id = 1;
            }
            else
            {
                id = lastaccount.Id + 1;
            }
            _items.Add(new AdminAccountModel(id, email, password, name));
            AdminAccountsAccess.WriteAll(_items);
            return $"\nThe new account has been added";
        }
        catch (Exception)
        {
            return $"\nAn error has occurred";
        }
    }


    public string DeleteAdmin(int ID, string email)
    {
        var targetAccount = _items.FirstOrDefault(x => x.Id == ID && x.EmailAddress == email);

        if (targetAccount != null)
        {
            if (_items.Count() > 1)
            {
                _items.Remove(targetAccount);
                AdminAccountsAccess.WriteAll(_items);
                return $"The account with ID: {ID} and email: {email} has been deleted";
            }
            else
            {
                return $"There is only one account left, you can't delete it.";
            }
        }
        else
        {
            return $"The account with ID: {ID} and email: {email} does not exist";
        }
    }

    public AdminAccountModel CheckExistingEmail(string email)
    {
        if (email == null)
        {
            return null;
        }
        CurrentAccount = _items.Find(i => i.EmailAddress == email);
        return CurrentAccount;
    }
    public override void UpdateList(AdminAccountModel acc)
    {
        //Find if there is already an model with the same id
        int index = _items.FindIndex(s => s.Id == acc.Id);

        if (index != -1)
        {
            //update existing model
            _items[index] = acc;
        }
        else
        {
            //add new model
            _items.Add(acc);
        }
        AdminAccountsAccess.WriteAll(_items);
    }
}