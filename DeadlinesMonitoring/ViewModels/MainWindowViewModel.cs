using DeadlinesMonitoring.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Text;
using Tmds.DBus;

namespace DeadlinesMonitoring.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<Student> studentsList;
        public MainWindowViewModel()
        {
            studentsList = new ObservableCollection<Student>();
            RemuveStudent = ReactiveCommand.Create(() => {
                StudentsList.Add(new Student
                {
                    TextFIOCS = fIOCS,
                    TextPhysicsCS = physicsCS,
                    TextHistoryCS = historyCS,
                    TextComputerScienceCS = computerScienceCS,
                    TextSocialScienceCS = socialScienceCS,
                    TextAverageCS = Convert.ToString(AverageStudentCS())
                });
                AverageAllStudentsCS();
            });
        }
        public ObservableCollection<Student> StudentsList
        {
            get { return studentsList; }
            set 
            { 
                studentsList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StudentsList)));           
            }
        }
        public string physicsAverageCS = "0";
        public string PhysicsAverageCS
        {
            get => physicsAverageCS;
            set 
            {
                physicsAverageCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhysicsAverageCS)));
            }
        }

        public string historyAverageCS = "0";
        public string HistoryAverageCS
        {
            get => historyAverageCS;
            set
            {
                historyAverageCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HistoryAverageCS)));
            }
        }
        public string computerScienceAverageCS = "0";
        public string ComputerScienceAverageCS
        {
            get => computerScienceAverageCS;
            set
            {
                computerScienceAverageCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ComputerScienceAverageCS)));
            }
        }

        public string socialScienceAverageCS = "0";
        public string SocialScienceAverageCS
        {
            get => socialScienceAverageCS;
            set
            {
                socialScienceAverageCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SocialScienceAverageCS)));
            }
        }


        public string fIOCS = "ÔÈÎ";
        public string FIOCS
        {
            get => fIOCS;
            set
            {
                fIOCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FIOCS)));
            }
        }
        public string physicsCS = "0";
        public string PhysicsCS
        {
            get => physicsCS;
            set
                    {
                        physicsCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhysicsCS)));
            }
        }
        public string historyCS = "0";
        public string HistoryCS
        {
            get => historyCS;
            set
                    {
                        historyCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HistoryCS)));
            }
        }
        public string computerScienceCS = "0";
        public string ComputerScienceCS
                {
            get => computerScienceCS;
            set
                    {
                        computerScienceCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ComputerScienceCS)));
            }
        }
        public string socialScienceCS = "0";
        public string SocialScienceCS
                {
            get => socialScienceCS;
            set
                    {
                        socialScienceCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SocialScienceCS)));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public ReactiveCommand<Unit, Unit> RemuveStudent { get; }
        private float AverageStudentCS()
        {
            float rez = 0;
            rez = (float.Parse(physicsCS) + float.Parse(historyCS) + float.Parse(computerScienceCS) + float.Parse(socialScienceCS))/4.0f;
            return rez;
        }
        public void AverageAllStudentsCS()
        {
            int c = studentsList.Count(), CS1=0, CS2=0, CS3=0, CS4=0;
            foreach (Student item in studentsList)
            {
                if (item != null)
                {
                    CS1 += int.Parse(item.TextPhysicsCS);
                    CS2 += int.Parse(item.TextHistoryCS);
                    CS3 += int.Parse(item.TextComputerScienceCS);
                    CS4 += int.Parse(item.TextSocialScienceCS);
                }
            }
            PhysicsAverageCS = Convert.ToString((float)CS1 / (float)c);
            HistoryAverageCS = Convert.ToString((float)CS2 / (float)c);    
            ComputerScienceAverageCS = Convert.ToString((float)CS3 / (float)c);
            SocialScienceAverageCS = Convert.ToString((float)CS4 / (float)c);
        }
    }
}
