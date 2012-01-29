using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace XMLImportLTDILWPF
{
    public class question
    {
        public int landID { get; set; }
        public int rideID { get; set; }
        public int questionID { get; set; }
        public int questionType { get; set; }
        public string lineValue { get; set; }
        public int fastPass { get; set; }
    }

    public class ride
    {
        public int landID { get; set; }
        public int rideID { get; set; }
        public int questionID { get; set; }
        public int questionType { get; set; }
        public string lineValue { get; set; }
       
    }
}
