using Dictionary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionary.Models
{
    public class WordModel
    {
        public int Id { get; set; }
        public string PlText { get; set; }
        public string UaText { get; set; }
        public string Transcription { get; set; }
        public string ImagePath { get; set; }

        public WordModel(Word word)
        {
            Id = word.Id;
            PlText = word.PlText;
            UaText = word.UaText;
            Transcription = word.Transcription;
            ImagePath = word.ImagePath;
        }

        public WordModel()
        {
        }

        public Word ToEntity()
        {
            return new Word()
            {
                Id = Id,
                PlText = PlText,
                UaText = UaText,
                Transcription = Transcription,
                ImagePath = ImagePath
            };
        }
    }

}
