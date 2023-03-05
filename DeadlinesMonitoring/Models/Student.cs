using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadlinesMonitoring.Models
{
    public class Student : INotifyPropertyChanged
    {
        public Student() {}
        public string TextFIOCS { get; set; }
        public string TextPhysicsCS { get; set; }
        public string TextHistoryCS { get; set; }
        public string TextComputerScienceCS { get; set; }
        public string TextSocialScienceCS { get; set; }
        public string TextAverageCS { get; set; }


        public SolidColorBrush colorPhysicsCS = new SolidColorBrush(Colors.Red);
        public SolidColorBrush ColorPhysicsCS
        {
            get => colorPhysicsCS;
            set
            {
                colorPhysicsCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorPhysicsCS)));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
