using CoMS.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoMS.Entities_Framework;
using CoMS.Models;
using CoMS.Untils;

namespace CoMS.Controllers
{
    public class BookmarkController : BaseController
    {
      
        [HttpGet]
        [Route("api/ListBookmark")]
        public HttpResponseMessage ListBookmark(decimal personId)
        {
            var bookmarkModel = new BookmarkModel();
            return ResponseSuccess(StringResource.Success, bookmarkModel.ListBookmark(personId));
        }

     
        [HttpPost]
        [Route("api/AddBookmark")]
        public HttpResponseMessage AddBookmark([FromBody] Bookmark bookmark)
        {
            if (bookmark != null)
            {
                var bookmarkModel = new BookmarkModel();
                bool isBookmark = bookmarkModel.CheckBookmark(bookmark.PersonId, bookmark.PersonIdBookmark);
                if (bookmark.PersonId == bookmark.PersonIdBookmark)
                {
                    return ResponseFail(StringResource.You_have_bookmark_this_person);
                }
                else if (isBookmark)
                {
                    return ResponseFail(StringResource.You_have_bookmark_this_person);
                }
                else
                {
                    var accountModel = new AccountModel();
                    var account = accountModel.GetAccountById(bookmark.PersonIdBookmark);
                    if (account != null)
                    {
                        var book = new CoMS.Entities_Framework.Bookmark();
                        book.PERSON_ID = bookmark.PersonId;
                        book.PERSON_ID_BOOKMARK = bookmark.PersonIdBookmark;
                        book.NAME_BOOKMARK = Utils.GetFullName(account.CURRENT_FIRST_NAME, account.CURRENT_MIDDLE_NAME, account.CURRENT_LAST_NAME);
                        book.IMAGE_BOOKMARK = account.Image;
                        book.DESCRIPTION = account.Note;
                        book.CREATE_DATE = DateTime.Now;

                        bool result = bookmarkModel.AddBookmark(book);
                        if (result)
                        {
                            return ResponseSuccess(StringResource.Success);
                        }
                        else
                        {
                            return ResponseFail(StringResource.Sorry_an_error_has_occurred);
                        }
                    }
                    else
                    {
                        return ResponseFail(StringResource.Account_does_not_exist);
                    }
                }
            }
            else
            {
                return ResponseFail(StringResource.Data_not_received);
            }
        }

    
        [HttpPost]
        [Route("api/DeleteBookmark")]
        public HttpResponseMessage DeleteBookmark([FromBody] Bookmark bookmark)
        {
            var bookmarkModel = new BookmarkModel();
            var book = new CoMS.Entities_Framework.Bookmark();
            book.PERSON_ID = bookmark.PersonId;
            book.PERSON_ID_BOOKMARK = bookmark.PersonIdBookmark;
            bool result = bookmarkModel.RemoveBookmark(book);
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

    public class Bookmark
    {
        public decimal PersonId { get; set; }
        public decimal PersonIdBookmark { get; set; }
    }
}
