using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACME.Models
{
    [MetadataType(typeof(Table.Metadata))]
    public partial class Table
    {
        sealed class Metadata
        {
            [Key]
            public System.Guid ProductId { get; set; }           
            [Required(ErrorMessage = "this is a custown messawge plz put in pwoduct OwO")]
            [Display(Name="Product Name yo")]
            [StringLength(25)]
            public string Name { get; set; }

            [Required(ErrorMessage = "dis pwice is wequiwed > _ <")]
            [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
            //[Range(0.01, 1000.0)]
            public decimal Price { get; set; }

            
        }
    }
}