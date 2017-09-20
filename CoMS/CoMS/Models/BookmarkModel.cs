using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Entities_Framework;

namespace CoMS.Models
{
    public class BookmarkModel
    {
        private MYDB myDB = null;
        public BookmarkModel()
        {
            myDB = new MYDB();
        }

        public Bookmark GetBookmarkByPersonId(decimal? personId, decimal? personIdBookmark)
        {
            return myDB.Bookmarks.SingleOrDefault(b => b.PERSON_ID == personId && b.PERSON_ID_BOOKMARK == personIdBookmark);
        }

        public bool CheckBookmark(decimal personId, decimal personIdBookmark)
        {
            var result = myDB.Bookmarks.SingleOrDefault(b => b.PERSON_ID == personId && b.PERSON_ID_BOOKMARK == personIdBookmark);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public bool AddBookmark(Bookmark bookmark)
        {
            try
            {
                myDB.Bookmarks.Add(bookmark);
                myDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Bookmark> ListBookmark(decimal personId)
        {
            var result = myDB.Bookmarks.Where(b => b.PERSON_ID == personId);
            return result.ToList();
        }

        public bool RemoveBookmark(Bookmark bookmark)
        {
            try
            {
                var result = GetBookmarkByPersonId(bookmark.PERSON_ID, bookmark.PERSON_ID_BOOKMARK);
                myDB.Bookmarks.Remove(result);
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