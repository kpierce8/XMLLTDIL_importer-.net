using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLImportLTDILWPF
{
    public class annoLine
    {
        public int landID { get; set; }
        public int rideID { get; set; }
        public int questionID { get; set; }
        public int answerID { get; set; }
        public int questionType { get; set; }
        public bool isCorrect { get; set; }
        public string lineValue { get; set; }
        public int fastPass { get; set; }
        public int targetDB { get; set; }
        public string section { get; set; }
    }
}
