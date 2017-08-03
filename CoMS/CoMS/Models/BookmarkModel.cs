using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Entities_Framework;

namespace CoMS.Controllers
{
    public class BookmarkModel
    {
        private MYDB myDB = null;
        public BookmarkModel()
        {
            myDB = new MYDB();
        }

        public BOOKMARK GetBookmarkByPersonId(decimal? personId, decimal? personIdBookmark)
        {
            return myDB.BOOKMARKs.SingleOrDefault(b => b.PERSON_ID == personId && b.PERSON_ID_BOOKMARK == personIdBookmark);
        }

        public bool CheckBookmark(decimal personId, decimal personIdBookmark)
        {
            var result = myDB.BOOKMARKs.SingleOrDefault(b => b.PERSON_ID == personId && b.PERSON_ID_BOOKMARK == personIdBookmark);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public bool AddBookmark(BOOKMARK bookmark)
        {
            try
            {
                myDB.BOOKMARKs.Add(bookmark);
                myDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<BOOKMARK> ListBookmark(decimal personId)
        {
            var result = myDB.BOOKMARKs.Where(b => b.PERSON_ID == personId);
            return result.ToList();
        }

        public bool RemoveBookmark(BOOKMARK bookmark)
        {
            try
            {
                var result = GetBookmarkByPersonId(bookmark.PERSON_ID, bookmark.PERSON_ID_BOOKMARK);
                myDB.BOOKMARKs.Remove(result);
                myDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}