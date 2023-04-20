﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
class AccountsLogic
{
    private List<AccountModel> _accounts;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself
    static public AccountModel? CurrentAccount { get; private set; }

    public AccountsLogic()
    {
        _accounts = AccountsAccess.LoadAll();
    }


    public void UpdateList(AccountModel acc)
    {
        //Find if there is already an model with the same id
        int index = _accounts.FindIndex(s => s.Id == acc.Id);

        if (index != -1)
        {
            //update existing model
            _accounts[index] = acc;
        }
        else
        {
            //add new model
            _accounts.Add(acc);
        }
        AccountsAccess.WriteAll(_accounts);

    }

    public AccountModel GetById(int id)
    {
        return _accounts.Find(i => i.Id == id);
    }

    public AccountModel CheckLogin(string email, string password)
    {
        if (email == null || password == null)
        {
            return null;
        }
        CurrentAccount = _accounts.Find(i => i.EmailAddress == email && i.Password == password);
        return CurrentAccount;
    }
    public AccountModel CheckExistingEmail(string email)
    {
        if (email == null)
        {
            return null;
        }
        CurrentAccount = _accounts.Find(i => i.EmailAddress == email);
        return CurrentAccount;
    }

    public void AddAcount(string name, string email, string password)
    {
        int id = _accounts.Count + 1;
        _accounts.Add(new AccountModel(id, email, password, name));
        AccountsAccess.WriteAll(_accounts);
    }
    public void ChangeEmail(string email)
    {
        CurrentAccount = Menu.loggedaccount;
        foreach (var i in _accounts)
        {
            if (i.EmailAddress == email)
            {
                Console.WriteLine("\nThe is email number already exists.");
                System.Threading.Thread.Sleep(3000);
                Menu.Start();
            }
        }
        foreach (var i in _accounts)
        {
            if (i.EmailAddress == CurrentAccount.EmailAddress && i.Password == CurrentAccount.Password)
            {
                i.EmailAddress = email;
                CurrentAccount.EmailAddress = email;
                Console.WriteLine("\nEmail has been changed.");
            }
        }
        AccountsAccess.WriteAll(_accounts);
        System.Threading.Thread.Sleep(3000);
        Menu.Start();
    }
    public void ChangePassword(string password)
    {
        CurrentAccount = Menu.loggedaccount;
        foreach (var i in _accounts)
        {
            if (i.EmailAddress == CurrentAccount.EmailAddress && i.Password == CurrentAccount.Password)
            {
                i.Password = password;
                CurrentAccount.Password = password;
                Console.WriteLine("\nPassword has been changed.");
            }
        }
        AccountsAccess.WriteAll(_accounts);
        System.Threading.Thread.Sleep(3000);
        Menu.Start();
    }
}




