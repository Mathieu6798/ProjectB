using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class AdminLogic : BasicLogic<AdminAccountModel>
{
    
    static public AdminAccountModel? CurrentAccount { get; private set; }

    public AdminLogic()
    {
        _items = AdminAccountsAccess.LoadAll();
    }


    public AdminAccountModel CheckLogin(string email, string password)
    {
        if (email == null || password == null)
        {
            return null;
        }
        CurrentAccount = _items.Find(i => i.EmailAddress == email && i.Password == password);
        return CurrentAccount;
    }


    public void AddAccount(string name, string email, string password)
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
        int index = _items.FindIndex(s => s.Id == acc.Id);

        if (index != -1)
        {
            _items[index] = acc;
        }
        else
        {
            _items.Add(acc);
        }
        AdminAccountsAccess.WriteAll(_items);
    }
}