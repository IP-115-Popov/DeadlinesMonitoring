using DeadlinesMonitoring.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System.Text;
using Tmds.DBus;

namespace DeadlinesMonitoring.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private Student student;
        private ObservableCollection<Student> studentsList;
        public MainWindowViewModel()
        {
            studentsList = new ObservableCollection<Student>();
            RemuveStudent = ReactiveCommand.Create(() => StudentsList.Add(new Student { TextFIOCS = "1", TextAverageCS = "1", TextComputerScienceCS = "1", TextHistoryCS = "1", TextPhysicsCS = "1", TextSocialScienceCS = "1" }));
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
        public string physicsAverageCS;
        public string PhysicsAverageCS
        {
            get => physicsAverageCS;
            set 
            {
                physicsAverageCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhysicsAverageCS)));
            }
        }

        public string historyAverageCS;
        public string HistoryAverageCS
        {
            get => historyAverageCS;
            set
            {
                historyAverageCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HistoryAverageCS)));
            }
        }
        public string computerScienceAverageCS;
        public string ComputerScienceAverageCS
        {
            get => computerScienceAverageCS;
            set
            {
                computerScienceAverageCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ComputerScienceAverageCS)));
            }
        }
        public string socialScienceAverageCS;
        public string SocialScienceAverageCS
        {
            get => socialScienceAverageCS;
            set
            {
                socialScienceAverageCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SocialScienceAverageCS)));
            }
        }
        public string physicsCS;
        public string PhysicsCS
        {
            get => physicsCS;
            set
                    {
                        physicsCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhysicsCS)));
            }
        }
        public string historyCS;
        public string HistoryCS
        {
            get => historyCS;
            set
                    {
                        historyCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HistoryCS)));
            }
        }
        public string computerScienceCS;
        public string ComputerScienceCS
                {
            get => computerScienceCS;
            set
                    {
                        computerScienceCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ComputerScienceCS)));
            }
        }
        public string socialScienceCS;
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
    }
}
