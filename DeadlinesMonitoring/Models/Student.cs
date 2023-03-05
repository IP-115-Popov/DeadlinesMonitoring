using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DeadlinesMonitoring.Models
{
    public class Student
    {
        public Student() {}
        public string TextFIOCS { get; set; }
        public string TextPhysicsCS { get; set; }
        public string TextHistoryCS { get; set; }
        public string TextComputerScienceCS { get; set; }
        public string TextSocialScienceCS { get; set; }
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
