using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExcelToDB.Models
{
    public class Userlist
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]        
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
    }
}