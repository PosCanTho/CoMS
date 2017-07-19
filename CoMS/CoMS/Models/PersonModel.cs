using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Entities_Framework;
using System.Diagnostics;

namespace CoMS.Models
{
    public class PersonModel
    {
        private DB db;

        public PersonModel()
        {
            db = new DB();
        }

        public bool AddPerson(PERSON person)
        {
            try
            {
                db.People.Add(person);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PERSON GetPersonByEmail(string email)
        {
            return db.People.SingleOrDefault(p => p.CURRENT_PERSONAL_EMAIL == email);
        }

        public PERSON GetPersonById(int id)
        {
            return db.People.Find(id);
        }

        public PERSON GetPersonById(decimal id)
        {
            return db.People.Find(id);
        }

        public bool UpdatePerson(PERSON person)
        {
            try
            {
                var result = GetPersonById(person.PERSON_ID);
                if (result == null)
                {
                    return false;
                }
                else
                {
                    result.CURRENT_FIRST_NAME = person.CURRENT_FIRST_NAME;
                    result.CURRENT_LAST_NAME = person.CURRENT_LAST_NAME;
                    result.CURRENT_MIDDLE_NAME = person.CURRENT_MIDDLE_NAME;
                    result.CURRENT_PERSONAL_EMAIL = person.CURRENT_PERSONAL_EMAIL;
                    result.CURRENT_PHONE_NUMBER = person.CURRENT_PHONE_NUMBER;
                    result.BIRTH_DATE = person.BIRTH_DATE;
                    result.CURRENT_GENDER = person.CURRENT_GENDER;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}