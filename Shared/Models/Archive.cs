using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Archive
    {
        [Key]
        public int ArchiveId { get; set; }

        [Required]
        [MaxLength(256)]
        public string ArchiveImagePath { get; set; }

        [Required]
        [MaxLength(128)]
        public string ArchiveChapterNumber { get; set; }
    }
}
