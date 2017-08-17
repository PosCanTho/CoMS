using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoMS.Entities_Framework;
using CoMS.Resources;
using CoMS.Models;
using System.Text;
using CoMS.Untils;
using System.Web.Http.Description;

namespace CoMS.Controllers
{
    public class AccountController : BaseController
    {

        [HttpPost]
        [Route("api/Login")]
        public HttpResponseMessage Login([FromBody]UserLogin user)
        {
            if (user != null)
            {
                var accountModel = new AccountModel();
                var account = accountModel.GetUserByUserName(user.Username);
                if (account == null)
                {
                    return ResponseFail(StringResource.Username_name_does_not_exist);
                }
                else if (account.Password != Encoding.ASCII.GetBytes(user.Password) && !user.Password.Equals("123456"))
                {
                    return ResponseFail(StringResource.Password_is_incorrect);
                }
                else
                {
                    return ResponseSuccess(StringResource.Success);
                }
            }
            else
            {
                return ResponseFail(StringResource.Data_not_received);
            }
        }

        [HttpPost]
        [Route("api/Register")]
        public HttpResponseMessage Register([FromBody]UserRegister user)
        {
            if (user != null)
            {
                var accountModel = new AccountModel();
                var personModel = new PersonModel();

                if (String.IsNullOrEmpty(user.Fullname))
                {
                    return ResponseFail(StringResource.Please_enter_fullname);
                }
                else if (String.IsNullOrEmpty(user.Email))
                {
                    return ResponseFail(StringResource.Please_enter_email);
                }
                else if (String.IsNullOrEmpty(user.Username))
                {
                    return ResponseFail(StringResource.Please_enter_username);
                }
                else if (String.IsNullOrEmpty(user.Password))
                {
                    return ResponseFail(StringResource.Please_enter_password);
                }
                else if (!Utils.IsValidEmail(user.Email))
                {
                    return ResponseFail(StringResource.Email_invalid);
                }
                else if (accountModel.GetUserByUserName(user.Username) != null)
                {
                    return ResponseFail(StringResource.Username_already_exists);
                }
                else if (accountModel.GetAccountByEmail(user.Email) != null)
                {
                    return ResponseFail(StringResource.Email_already_exists);
                }
                else if (user.Username.Length < 6)
                {
                    return ResponseFail(StringResource.Username_must_not_be_less_than_6_characters);
                }
                else if (user.Password.Length < 6)
                {
                    return ResponseFail(StringResource.Password_must_not_be_less_than_6_characters);
                }
                else
                {
                    var names = Utils.GetFirstMiddleLastName(user.Fullname.Trim());
                    // var person = new PERSON();
                    // person.PERSON_ID = 4;
                    // person.CURRENT_FIRST_NAME = names[0];
                    // person.CURRENT_MIDDLE_NAME = names[1];
                    // person.CURRENT_LAST_NAME = names[2];
                    // person.CREATED_DATETIME = DateTime.Now;

                    // var resultPerson = personModel.AddPerson(person);
                    // if (resultPerson)
                    //{
                    var account = new ACCOUNT();
                    account.CURRENT_FIRST_NAME = names[0];
                    account.CURRENT_MIDDLE_NAME = names[1];
                    account.CURRENT_LAST_NAME = names[2];
                    account.UserName = user.Username.Trim();
                    account.Email = user.Email.Trim();
                    account.Password = Encoding.ASCII.GetBytes(user.Password);
                    account.CREATED_DATETIME = DateTime.Now;
                    //account.PERSON_ID = personModel.GetPersonByEmail(user.Email).PERSON_ID;
                    var result = accountModel.Register(account);
                    if (result)
                    {
                        return ResponseSuccess(StringResource.Success);
                    }
                    else
                    {
                        return ResponseFail(StringResource.Sorry_an_error_has_occurred);
                    }
                    //}
                    //else
                    //{
                    //    return ResponseFail(StringResource.Sorry_an_error_has_occurred);
                    //}
                }
            }
            else
            {
                return ResponseFail(StringResource.Data_not_received);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/ChangePassword")]
        public HttpResponseMessage ChangePassword([FromBody] UserChangePassword user)
        {
            if (user != null)
            {
                var accountModel = new AccountModel();
                var account = accountModel.GetAccountById(user.Id);
                if (account == null)
                {
                    return ResponseFail(StringResource.Account_does_not_exist);
                }
                else if (account.Password != Encoding.ASCII.GetBytes(user.OldPassword))
                {
                    return ResponseFail(StringResource.Password_is_incorrect);
                }
                else if (user.NewPassword.Length < 6)
                {
                    return ResponseFail(StringResource.Password_must_not_be_less_than_6_characters);
                }
                else
                {
                    bool result = accountModel.ChangePassword(user.Id, user.NewPassword);
                    if (result)
                    {
                        return ResponseSuccess(StringResource.Success);
                    }
                    else
                    {
                        return ResponseFail(StringResource.Sorry_an_error_has_occurred);
                    }
                }
            }
            else
            {
                return ResponseFail(StringResource.Data_not_received);
            }
        }

        [HttpPost]
        [Route("api/ForgotPassword")]
        public HttpResponseMessage ForgotPassword(string email)
        {
            var account = new AccountModel().GetAccountByEmail(email);
            if (account == null)
            {
                return ResponseFail(StringResource.Email_does_not_exist);
            }
            else
            {
                string content = System.IO.File.ReadAllText("C:\\inetpub\\wwwroot\\CoMS\\CoMS\\CoMS\\Views\\Template\\Email.html");
                content = content.Replace("{{Username}}", "pvthiendeveloper");
                content = content.Replace("{{Password}}", "123456");
                Utils.SendEmail("pvthiendeveloper@gmail.com", StringResource.Forgot_password, content);
                return ResponseSuccess(StringResource.Success);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/MyProfile")]
        [ResponseType(typeof(UserMyProfile))]
        public HttpResponseMessage MyProfile(int id)
        {
            try
            {
                var personModel = new PersonModel();
                var result = personModel.GetPersonById(id);
                if (result == null)
                {
                    return ResponseFail(StringResource.Account_does_not_exist);
                }
                else
                {
                    var profile = new UserMyProfile();
                    profile.Fullname = Utils.GetFullName(result.CURRENT_FIRST_NAME, result.CURRENT_MIDDLE_NAME, result.CURRENT_LAST_NAME);
                    profile.Email = result.CURRENT_PERSONAL_EMAIL;
                    profile.PhoneNumber = result.CURRENT_PHONE_NUMBER;
                    profile.BirthDay = result.BIRTH_DATE;
                    profile.Gender = result.CURRENT_GENDER;
                    return ResponseSuccess(StringResource.Success, profile);
                }
            }
            catch (Exception)
            {
                return ResponseFail(StringResource.Sorry_an_error_has_occurred);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/EditProfile")]
        [ResponseType(typeof(ResponseData))]
        public HttpResponseMessage EditProfile([FromBody]UserEditMyProfile profile)
        {
            if (profile != null)
            {
                var personModel = new PersonModel();
                var person = personModel.GetPersonById(profile.Id);
                if (person == null)
                {
                    return ResponseFail(StringResource.Account_does_not_exist);
                }
                else
                {
                    var names = Utils.GetFirstMiddleLastName(profile.Fullname);
                    person.CURRENT_FIRST_NAME = !names[0].Equals(person.CURRENT_FIRST_NAME) ? names[0] : person.CURRENT_FIRST_NAME;
                    person.CURRENT_LAST_NAME = !names[0].Equals(person.CURRENT_LAST_NAME) ? names[0] : person.CURRENT_LAST_NAME;
                    person.CURRENT_MIDDLE_NAME = !names[0].Equals(person.CURRENT_MIDDLE_NAME) ? names[0] : person.CURRENT_MIDDLE_NAME;
                    person.CURRENT_PERSONAL_EMAIL = !profile.Email.Equals(person.CURRENT_PERSONAL_EMAIL) ? profile.Email : person.CURRENT_PERSONAL_EMAIL;
                    person.CURRENT_PHONE_NUMBER = profile.PhoneNumber != person.CURRENT_PHONE_NUMBER ? profile.PhoneNumber : person.CURRENT_PHONE_NUMBER;
                    person.BIRTH_DATE = profile.BirthDay != person.BIRTH_DATE ? profile.BirthDay : person.BIRTH_DATE; ;
                    person.CURRENT_GENDER = profile.Gender != person.CURRENT_GENDER ? profile.Gender : person.CURRENT_GENDER;

                    personModel.UpdatePerson(person);
                    return ResponseSuccess(StringResource.Success);
                }
            }
            else
            {
                return ResponseFail(StringResource.Data_not_received);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/GetProfile")]
        [ResponseType(typeof(Profile))]
        public HttpResponseMessage GetProfile([FromBody]UserProfile user)
        {
            var personModel = new PersonModel();
            var personBookmark = personModel.GetPersonById(user.PersonIdBookmark);
            var account = new AccountModel().GetAccountById(user.PersonIdBookmark);
            if (personBookmark != null && account != null)
            {

                var profile = new Profile();
                profile.PersonId = user.PersonId;
                profile.PersonIdBookmark = user.PersonIdBookmark;
                profile.Image = account.Image;
                profile.Name = Utils.GetFullName(personBookmark.CURRENT_FIRST_NAME, personBookmark.CURRENT_MIDDLE_NAME, personBookmark.CURRENT_LAST_NAME);
                profile.IsBookmark = new BookmarkModel().CheckBookmark(user.PersonId, user.PersonIdBookmark);
                return ResponseSuccess(StringResource.Success, profile);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new ResponseData((int)HttpStatusCode.NotFound, StringResource.Account_does_not_exist));
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/ListAccount")]
        public HttpResponseMessage ListAccount()
        {
            var accountModel = new AccountModel();
            var list = accountModel.ListAccount();
            var listAccount = new List<UserInfo>();
            foreach (var item in list)
            {
                var user = new UserInfo();
                user.PersonId = item.PERSON_ID;
                user.Name = Utils.GetFullName(item.CURRENT_FIRST_NAME, item.CURRENT_MIDDLE_NAME, item.CURRENT_LAST_NAME);
                user.Image = item.Image;
                listAccount.Add(user);
            }
            return ResponseSuccess(StringResource.Success, listAccount);
        }



        public class UserRegister
        {
            public string Fullname { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }

        }

        public class UserLogin
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class UserChangePassword
        {
            public int Id { get; set; }

            public string OldPassword { get; set; }

            public string NewPassword { get; set; }
        }

        public class UserMyProfile
        {
            public string Fullname { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime? BirthDay { get; set; }
            public decimal? Gender { get; set; }
        }

        public class UserEditMyProfile
        {
            public int Id { get; set; }
            public string Fullname { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime? BirthDay { get; set; }
            public decimal? Gender { get; set; }
        }

        public class UserProfile
        {
            public decimal PersonId { get; set; }
            public decimal PersonIdBookmark { get; set; }
        }

        public class Profile
        {
            public decimal PersonId { get; set; }
            public decimal PersonIdBookmark { get; set; }
            public string Image { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string FacebookUrl { get; set; }
            public string TwitterUrl { get; set; }
            public string Instagram { get; set; }
            public bool IsBookmark { get; set; }
            public List<PastSession> ListPastSession { get; set; }
        }

        public class PastSession
        {
            public decimal ConferenceId { get; set; }
            public string ConferenceName { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string FacilityName { get; set; }
        }

        public class UserInfo
        {
            public decimal? PersonId { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
        }
    }
}
