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
        public string Title { get; set; }

        [Required]
        [MaxLength(256)]
        public string ArchiveThumbnailImagePath { get; set; }

        [Required]
        [MaxLength(65536)]
        public string Content { get; set; }

        [Required]
        [MaxLength(256)]
        public bool Published { get; set; }


        [Required]
        [MaxLength(256)]
        public int ArchiveId { get; set; }

        [Required]
        [MaxLength(256)]
        public ArchiveModel ArchiveModel { get; set; }

    }
}
