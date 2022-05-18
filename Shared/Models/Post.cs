using Shared.Models.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        [MaxLength(128)]
        [NoPeriods(ErrorMessage = "The Archive Chapter Label field contains one or more period character (.). Please remove all periods.")]
        [NoThreeOrMoreSpacesInARow(ErrorMessage = "The Archive Chapter Label field contains three or more spaces in a row. Please remove them. ")]
        public string Title { get; set; }

        [Required]
        [MaxLength(256)]
        public string IntroBorder { get; set; }

        [Required]
        [MaxLength(256)]
        public string ArchiveThumbnailImagePath { get; set; }

        [Required]
        [MaxLength(512)]
        public string Excerpt { get; set; }

        [Required]
        [MaxLength(65536)]
        public string Content { get; set; }

        [Required]
        [MaxLength(32)]
        public string PublishDate { get; set; }

        [Required] 
        public bool Published { get; set; }


        [Required]
        [MaxLength(256)]
        public int ArchiveId { get; set; }

        public ArchiveModel ArchiveModel { get; set; }

    }
}
