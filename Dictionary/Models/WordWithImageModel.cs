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
        [DisplayName("Слово на польському")]
        public string PlText { get; set; }
        public string UaText { get; set; }
        public string Transcription { get; set; }
        [DisplayName("Зображення")]
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
