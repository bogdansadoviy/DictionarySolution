using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dictionary.Models
{
    public class EditWordModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Word on the Polish.")] 
        public string PlText { get; set; }
        [DisplayName("Word on the Ukrainian")]
        public string UaText { get; set; }
        public string Transcription { get; set; }
        [DisplayName("Image")]
        public string IMagePath { get; set; }

        public EditWordModel() { }

        public WordModel ToWordModel()
        {
            return new WordModel()
            {
                Id = Id,
                PlText = PlText,
                UaText = UaText,
                Transcription = Transcription,
                ImagePath = IMagePath
            };
        }
    }
}
