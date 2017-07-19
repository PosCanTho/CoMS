using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Entities_Framework;
using CoMS.Resources;
using CoMS.Untils;
using System.Text;

namespace CoMS.Models
{
    public class AccountModel
    {
        private DB db;

        public AccountModel()
        {
            db = new DB();
        }

        public ACCOUNT GetUserByUserName(string username)
        {
            return db.ACCOUNTs.SingleOrDefault(a => a.UserName == username);
        }


        public bool Register(ACCOUNT account)
        {
            try
            {
                db.ACCOUNTs.Add(account);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ACCOUNT GetAccountById(int id)
        {
            return db.ACCOUNTs.Find(id);
        }

        public ACCOUNT GetAccountByEmail(string email)
        {
            return db.ACCOUNTs.SingleOrDefault(a => a.Email == email);
        }

        public bool ChangePassword(int id, string password)
        {
            try
            {
                var account = GetAccountById(id);
                account.Password = Encoding.ASCII.GetBytes(password);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}