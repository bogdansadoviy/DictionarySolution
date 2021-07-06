using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionary.Entities
{
    public class Word
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Word on the Polish.")]
        public string PlText { get; set; }
        [DisplayName("Word on the Ukrainian")]
        public string UaText { get; set; }
        public string Transcription { get; set; }
        [DisplayName("Image path")]
        public string ImagePath { get; set; }

    }
}
