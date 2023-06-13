using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


public class AccountsLogic : BasicLogic<AccountModel>
{
   
    static public AccountModel? CurrentAccount { get; private set; }

    public AccountsLogic()
    {
        _items = AccountsAccess.LoadAll();
    }

    public void DeleteAccount(AccountModel currentaccount)
    {
        var itemToRemove = _items.First(r => r.Id == currentaccount.Id);
        _items.Remove(itemToRemove);
        AccountsAccess.WriteAll(_items);
    }
    public override void UpdateList(AccountModel acc)
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
        AccountsAccess.WriteAll(_items);
    }

    public AccountModel GetById(int id)
    {
        return _items.Find(i => i.Id == id);
    }

    public AccountModel CheckLogin(string email, string password)
    {
        if (email == null || password == null)
        {
            return null;
        }
        CurrentAccount = _items.Find(i => i.EmailAddress == email && i.Password == password);
        return CurrentAccount;
    }
    public AccountModel CheckExistingEmail(string email)
    {
        if (email == null)
        {
            return null;
        }
        CurrentAccount = _items.Find(i => i.EmailAddress == email);
        return CurrentAccount;
    }

    public void AddAcount(string name, string email, string password)
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
        _items.Add(new AccountModel(id, email, password, name));
        AccountsAccess.WriteAll(_items);
    }
    public AccountModel ChangeEmail(string email, AccountModel currentAccount)
    {
        foreach (var i in _items)
        {
            if (i.EmailAddress == email)
            {
                return null;
            }
        }
        foreach (var i in _items)
        {
            if (i.EmailAddress == currentAccount.EmailAddress && i.Password == currentAccount.Password)
            {
                i.EmailAddress = email;
                currentAccount.EmailAddress = email;
            }
        }
        AccountsAccess.WriteAll(_items);
        return currentAccount;
    }
    public AccountModel ChangePassword(string password, AccountModel currentAccount)
    {
        foreach (var i in _items)
        {
            if (i.EmailAddress == currentAccount.EmailAddress && i.Password == currentAccount.Password)
            {
                i.Password = password;
                currentAccount.Password = password;
            }
        }
        AccountsAccess.WriteAll(_items);
        return currentAccount;
    }
}




