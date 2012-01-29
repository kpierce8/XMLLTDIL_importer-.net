using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;

namespace XMLImportLTDILWPF
{
    class XMLgetter
    {
 


        public List<annoLine> theQuestionsXML { get; set; }
        public List<annoLine> theLandsXML { get; set; }
        public List<annoLine> theRidesXML { get; set; }
        public List<annoLine> theAnswersXML { get; set; }
        public FileStream questionsFile;// = new FileStream("C:\\Users\\ken\\Dropbox\\ltdil\\DatabaseScrub\\output\\cleaned\\theQuestions4.xml", FileMode.OpenOrCreate);
        public FileStream landsFile;// = new FileStream("C:\\Users\\ken\\Dropbox\\ltdil\\DatabaseScrub\\output\\cleaned\\theLands2.xml", FileMode.OpenOrCreate);
        public FileStream ridesFile;// = new FileStream("C:\\Users\\ken\\Dropbox\\ltdil\\DatabaseScrub\\output\\cleaned\\theRides2.xml", FileMode.OpenOrCreate);
        public FileStream answersFile;// = new FileStream("C:\\Users\\ken\\Dropbox\\ltdil\\DatabaseScrub\\output\\cleaned\\theAnswers3.xml", FileMode.OpenOrCreate);


        public LTDILContext context { get; set; }
        public ObservableCollection<annoLine> observeableQuestions { get; set; }
        public ObservableCollection<annoLine> observeableLands { get; set; }
        public ObservableCollection<annoLine> observeableRides { get; set; }
        public ObservableCollection<annoLine> observeableAnswers { get; set; }

        public void InitializeXMLData()
        {
            string rootString = "C:\\Users\\ken\\Documents\\My Dropbox";

            questionsFile = new FileStream(rootString + "\\ltdil\\DatabaseScrub\\output\\cleaned\\theQuestions4.xml", FileMode.OpenOrCreate);
            landsFile = new FileStream(rootString + "\\ltdil\\DatabaseScrub\\output\\cleaned\\theLands2.xml", FileMode.OpenOrCreate);
            ridesFile = new FileStream(rootString + "\\ltdil\\DatabaseScrub\\output\\cleaned\\theRides2.xml", FileMode.OpenOrCreate);
            answersFile = new FileStream(rootString + "\\ltdil\\DatabaseScrub\\output\\cleaned\\theAnswers3.xml", FileMode.OpenOrCreate);
            theQuestionsXML = getAnswers(questionsFile);
            theLandsXML = getAnswers(landsFile);
            theRidesXML = getAnswers(ridesFile);
            theAnswersXML = getAnswers(answersFile);
            Debug.Write(String.Format("\nquestionCount is {0} \n", theQuestionsXML.Count.ToString()));
            Debug.Write(String.Format("landCount is {0} \n", theLandsXML.Count.ToString()));
            Debug.Write(String.Format("rideCount is {0} \n", theRidesXML.Count.ToString()));
            Debug.Write(String.Format("answerCount is {0} \n", theAnswersXML.Count.ToString()));
            var theQuestions = theQuestionsXML.Where(p => p.questionID < 4);
            observeableQuestions = new ObservableCollection<annoLine>();

           // LTDILContext context;
            try
            {
                context = new LTDILContext();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                
            }
           
            
                foreach (var item in theQuestions)
                {
                    var question = new question
                    {
                        fastPass = item.fastPass,
                        landID = item.landID,
                        rideID = item.rideID,
                        lineValue = item.lineValue,
                        questionID = item.questionID,
                        questionType = item.questionType
                    };

                    context.questions.Add(question);
                    context.SaveChanges();
                    observeableQuestions.Add(item);
                }
            
           
        }


        public List<annoLine> getAnswers(FileStream sourceFile)
        {
            XmlSerializer xmlQuestions = new XmlSerializer(typeof(List<annoLine>));
            List<annoLine> currentQuestions = (List<annoLine>)xmlQuestions.Deserialize(sourceFile);

            //Console.Write(currentQuestions.Count.ToString());
            //Console.Write(currentQuestions[3].lineValue);

            return currentQuestions;

        }


    }
}
