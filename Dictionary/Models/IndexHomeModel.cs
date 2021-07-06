using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionary.Models
{
    public class IndexHomeModel
    {
        public List<WordModel> UserWords { get; set; }
        public List<WordModel> WordsToLearn { get; set; }
        public bool IsTestAvaible { get; set; }
        public int RateOfTest { get; set; }
        public bool WordWasAdded { get; set; }
        public bool WordWasRemoved { get; set; }
    }
}
