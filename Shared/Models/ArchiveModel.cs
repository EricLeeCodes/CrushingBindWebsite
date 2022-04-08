﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class ArchiveModel
    {
        [Key]
        public int ArchiveId { get; set; }

        [Required]
        [MaxLength(256)]
        public string ArchiveThumbnailImagePath { get; set; }

        [Required]
        [MaxLength(128)]
        public string ArchiveChapterNumber { get; set; }

        public List<Post> Posts { get; set; }
    }
}
