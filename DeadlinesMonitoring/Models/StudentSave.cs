using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DeadlinesMonitoring.Models
{
    [Serializable]
    internal class StudentSave
    {
        public StudentSave(string textFIOCS, string textPhysicsCS, string textHistoryCS, string textComputerScienceCS, string textSocialScienceCS, string textAverageCS)
        {
            TextFIOCS = textFIOCS;
            TextPhysicsCS = textPhysicsCS;
            TextHistoryCS = textHistoryCS;
            TextComputerScienceCS = textComputerScienceCS;
            TextSocialScienceCS = textSocialScienceCS;
            TextAverageCS = textAverageCS;
        }

        //[XmlElement("TextFIOCS")]
        public string TextFIOCS { get; set; }
        //[XmlElement("TextPhysicsCS")]
        public string TextPhysicsCS { get; set; }
        //[XmlElement("TextHistoryCS")]
        public string TextHistoryCS { get; set; }
        //[XmlElement("TextComputerScienceCS")]
        public string TextComputerScienceCS { get; set; }
        //[XmlElement("TextSocialScienceCS")]
        public string TextSocialScienceCS { get; set; }
        //[XmlElement("TextAverageCS")]
        public string TextAverageCS { get; set; }
    }
}
