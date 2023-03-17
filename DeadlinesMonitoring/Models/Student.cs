using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace DeadlinesMonitoring.Models
{
    [Serializable]
    public class Student
    {
        public Student() {}
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

        public SolidColorBrush? colorPhysicsCS = null;
        public SolidColorBrush? ColorPhysicsCS
        {
            get
            {
                if (float.Parse(TextPhysicsCS) < 1) return new SolidColorBrush(Colors.Red);
                else if (float.Parse(TextPhysicsCS) == 1) return new SolidColorBrush(Colors.Yellow);
                else if (float.Parse(TextPhysicsCS) >= 1) return new SolidColorBrush(Colors.Green);
                return null;
            }
            set
            {
                colorPhysicsCS = value;
            }
        }
        public SolidColorBrush colorHistoryCS = new SolidColorBrush(Colors.Red);
        public SolidColorBrush ColorHistoryCS
        {
            get
            {
                if (float.Parse(TextHistoryCS) < 1) return new SolidColorBrush(Colors.Red);
                else if (float.Parse(TextHistoryCS) == 1) return new SolidColorBrush(Colors.Yellow);
                else if (float.Parse(TextHistoryCS) >= 1) return new SolidColorBrush(Colors.Green);
                return null;
            }
            set
            {
                colorHistoryCS = value;
                
            }
        }
        public SolidColorBrush colorComputerScienceCS = new SolidColorBrush(Colors.Red);
        public SolidColorBrush ColorComputerScienceCS
        {
            get
            {
                if (float.Parse(TextComputerScienceCS) < 1) return new SolidColorBrush(Colors.Red);
                else if (float.Parse(TextComputerScienceCS) == 1) return new SolidColorBrush(Colors.Yellow);
                else if (float.Parse(TextComputerScienceCS) >= 1) return new SolidColorBrush(Colors.Green);
                return null;
            }
            set
            {
                colorComputerScienceCS = value;

            }
        }
        public SolidColorBrush colorSocialScienceCS = new SolidColorBrush(Colors.Red);
        public SolidColorBrush ColorSocialScienceCS
        {
            get
            {
                if (float.Parse(TextSocialScienceCS) < 1) return new SolidColorBrush(Colors.Red);
                else if (float.Parse(TextSocialScienceCS) == 1) return new SolidColorBrush(Colors.Yellow);
                else if (float.Parse(TextSocialScienceCS) >= 1) return new SolidColorBrush(Colors.Green);
                return null;
            }
            set
            {
                colorSocialScienceCS = value;

            }
        }
        public SolidColorBrush colorAverageCS = new SolidColorBrush(Colors.Red);
        public SolidColorBrush ColorAverageCS
        {
            get
            {
                if (float.Parse(TextAverageCS) < 1) return new SolidColorBrush(Colors.Red);
                else if (float.Parse(TextAverageCS) <= 1.5) return new SolidColorBrush(Colors.Yellow);
                else return new SolidColorBrush(Colors.Green);
            }
            set
            {
                colorAverageCS = value;

            }
        }
    }
}
