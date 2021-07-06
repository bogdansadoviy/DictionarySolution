using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionary.Models
{
    public class WordWithImageModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Word on the Polish.")] 
        public string PlText { get; set; }
        [DisplayName("Word on the Ukrainian")]
        public string UaText { get; set; }
        public string Transcription { get; set; }
        [DisplayName("Image")]
        public IFormFile File { get; set; }

        public WordWithImageModel()
        {

        }


        public WordModel ToWordModel(string imagePath)
        {
            return new WordModel()
            {
                Id = Id,
                PlText = PlText,
                UaText = UaText,
                Transcription = Transcription,
                ImagePath = imagePath
            };
        }
    }

    
}
