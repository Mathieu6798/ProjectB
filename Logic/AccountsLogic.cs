using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
public class AccountsLogic : BasicLogic<AccountModel>
{
    // private List<AccountModel> _accounts;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
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
        // CurrentAccount = Menu.loggedaccount;
        foreach (var i in _items)
        {
            if (i.EmailAddress == email)
            {
                // Console.WriteLine("\nThis email address already exists.");
                // System.Threading.Thread.Sleep(3000);
                // UserLoggedIn.Start();
                return null;
            }
        }
        foreach (var i in _items)
        {
            if (i.EmailAddress == currentAccount.EmailAddress && i.Password == currentAccount.Password)
            {
                i.EmailAddress = email;
                currentAccount.EmailAddress = email;
                // AccountsAccess.WriteAll(_accounts);
                // Console.WriteLine("\nEmail has been changed.");
                // return true;
            }
        }
        AccountsAccess.WriteAll(_items);
        return currentAccount;
        // AccountsAccess.WriteAll(_accounts);
        // System.Threading.Thread.Sleep(3000);
        // UserLoggedIn.Start();
    }
    public AccountModel ChangePassword(string password, AccountModel currentAccount)
    {
        // CurrentAccount = Menu.loggedaccount;
        foreach (var i in _items)
        {
            if (i.EmailAddress == currentAccount.EmailAddress && i.Password == currentAccount.Password)
            {
                i.Password = password;
                currentAccount.Password = password;
                // AccountsAccess.WriteAll(_accounts);
                // Console.WriteLine("\nPassword has been changed.");
                // return true;
            }
        }
        AccountsAccess.WriteAll(_items);
        return currentAccount;
        // AccountsAccess.WriteAll(_accounts);
        // System.Threading.Thread.Sleep(3000);
        // UserLoggedIn.Start();
    }
}




