using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class MyModel
    {
        public int DoujinID { get; set; }
        public string DoujinName { get; set; }
        public string DoujinGenre { get; set; }

        public static List<MyModel> GetMyModels()
        {
            var doujinList = new List<MyModel>()
            {
                new MyModel {DoujinName = "i'll cum in my littler sister and her friends too!",
                            DoujinGenre = "incest, rape", DoujinID = 1},
                new MyModel {DoujinName = "witch anal gangbang",
                            DoujinGenre = "ahegao, rape", DoujinID = 69},
                new MyModel {DoujinName = "patchouli and alice beach fuck",
                            DoujinGenre = "hairy, armpits", DoujinID = 101}
            };
            return doujinList;
        }


        /*
        public static List<Tag> GetTags()
        {
            List<Tag> tags = new List<Tag>
            {
                new Tag {TagName = "rape"},
                new Tag {TagName = "ahegao"},
                new Tag {TagName = "loli"}
            };
            return tags;
        }
        */
    }

    /*
    public class Doujin
    {
        public int DoujinID { get; set; }
        public string DoujinName { get; set; }
        public string DoujinGenre { get; set; }
    }
    */

    /*
    public class Tag
    {
        public string TagName { get; set; }
    }
    */

}