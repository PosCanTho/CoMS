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

        public bool UpdateAccount(PERSON person)
        {
            try
            {
                var result = GetAccountById(person.PERSON_ID);
                if (result == null)
                {
                    return false;
                }
                else
                {
                    result.CURRENT_FIRST_NAME = person.CURRENT_FIRST_NAME;
                    result.CURRENT_LAST_NAME = person.CURRENT_LAST_NAME;
                    result.CURRENT_MIDDLE_NAME = person.CURRENT_MIDDLE_NAME;
                    result.CURRENT_EMAIL = person.CURRENT_PERSONAL_EMAIL;
                    result.CURRENT_PHONE = person.CURRENT_PHONE_NUMBER;
                    result.CURRENT_GENDER = person.CURRENT_GENDER;
                    result.UPDATED_DATETIME = person.UPDATED_DATETIME;
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ACCOUNT GetAccountById(decimal personId)
        {
            return db.ACCOUNTs.SingleOrDefault(a => a.PERSON_ID == personId);
        }

        public ACCOUNT GetAccountByEmail(string email)
        {
            return db.ACCOUNTs.SingleOrDefault(a => a.CURRENT_EMAIL == email);
        }

        public bool ChangePassword(int id, string password)
        {
            try
            {
                var account = GetAccountById(id);
                account.Password = Encoding.ASCII.GetBytes(password);
                account.UPDATED_DATETIME = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ACCOUNT> ListAccount()
        {
            var listAccount = db.ACCOUNTs;
            return listAccount.ToList();
        }

        public object ListPastConference(decimal personId)
        {
            var result = from ca in db.CONFERENCE_ATTENDEE
                         join cf in db.CONFERENCEs on ca.CONFERENCE_ID equals cf.CONFERENCE_ID
                         where ca.PERSON_ID == personId
                         select new {
                             ca.PERSON_ID,
                             ca.CURRENT_FIRST_NAME,
                             ca.CURRENT_MIDDLE_NAME,
                             ca.CURRENT_LAST_NAME,
                             ca.CONFERENCE_ID,
                             ca.CONFERENCE_NAME,
                             ca.CONFERENCE_NAME_EN,
                             cf.FROM_DATE,
                             cf.THRU_DATE,
                         };
            return result;
        }

    }
}