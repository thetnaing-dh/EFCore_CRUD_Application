using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CRUD.Models
{
    [Table ("Tbl_Blog")]
    public class BlogDataModel
    {
        [Key]
        [Column ("BlogId")]
        public int BlogId { get; set; }

        [Column("BlogTitle")]
        public string BlogTitle { get; set; } = string.Empty;

        [Column("BlogAuthor")]
        public string BlogAuthor { get; set; } = string.Empty;

        [Column("BlogContent")]
        public string BlogContent { get; set; } = string.Empty;

        [Column("DeleteFlag")]
        public bool DeleteFlag { get; set; } = false;

    }
}
