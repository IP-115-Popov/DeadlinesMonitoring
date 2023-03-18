using Avalonia.Media;
using DeadlinesMonitoring.Models;
using DynamicData;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Text;
using Tmds.DBus;
using DeadlinesMonitoring.Views;
using System.Data.Entity;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace DeadlinesMonitoring.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        [XmlArray("studentsList"), XmlArrayItem("Student")]
        private ObservableCollection<Student> studentsList;
        public MainWindowViewModel()
        {
            studentsList = new ObservableCollection<Student>();
            AddStudent = ReactiveCommand.Create(() => {
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
            RemuveStudent = ReactiveCommand.Create(() => {
                if (StudentsList.Count > 0)
                {
                    StudentsList.Remove(SelectedItem);
                    AverageAllStudentsCS();
                }
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
        public string historyAverageCS = "0";
        public string computerScienceAverageCS = "0";
        public string socialScienceAverageCS = "0";
        public string textstudentsAverageCS = "0";

        public string fIOCS = "ÔÈÎ";
        public string physicsCS = "0";
        public string historyCS = "0";
        public string computerScienceCS = "0";
        public string socialScienceCS = "0";
        public SolidColorBrush? colorPhysicsAverageCS = new SolidColorBrush(Colors.Red);
        public SolidColorBrush? colorHistoryAverageCS = new SolidColorBrush(Colors.Red);
        public SolidColorBrush? colorComputerScienceAverageCS = new SolidColorBrush(Colors.Red);
        public SolidColorBrush? colorSocialScienceAverageCS = new SolidColorBrush(Colors.Red);
        public SolidColorBrush? colorStudentsAverageCS = new SolidColorBrush(Colors.Red);
        public string PhysicsAverageCS
        {
            get => physicsAverageCS;
            set 
            {
                physicsAverageCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhysicsAverageCS)));

                if (float.Parse(physicsAverageCS) < 1) colorPhysicsAverageCS = new SolidColorBrush(Colors.Red);
                else if (float.Parse(physicsAverageCS) == 1) colorPhysicsAverageCS = new SolidColorBrush(Colors.Yellow);
                else colorPhysicsAverageCS = new SolidColorBrush(Colors.Green);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorPhysicsAverageCS)));
            }
        }     
        public string HistoryAverageCS
        {
            get => historyAverageCS;
            set
            {
                historyAverageCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HistoryAverageCS)));

                if (float.Parse(historyAverageCS) < 1) colorHistoryAverageCS = new SolidColorBrush(Colors.Red);
                else if (float.Parse(historyAverageCS) == 1) colorHistoryAverageCS = new SolidColorBrush(Colors.Yellow);
                else colorHistoryAverageCS = new SolidColorBrush(Colors.Green);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorHistoryAverageCS)));
            }
        }      
        public string ComputerScienceAverageCS
        {
            get => computerScienceAverageCS;
            set
            {
                computerScienceAverageCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ComputerScienceAverageCS)));

                if (float.Parse(computerScienceAverageCS) < 1) colorComputerScienceAverageCS = new SolidColorBrush(Colors.Red);
                else if (float.Parse(computerScienceAverageCS) == 1) colorComputerScienceAverageCS = new SolidColorBrush(Colors.Yellow);
                else colorComputerScienceAverageCS = new SolidColorBrush(Colors.Green);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorComputerScienceAverageCS)));
            }
        }    
        public string SocialScienceAverageCS
        {
            get => socialScienceAverageCS;
            set
            {
                socialScienceAverageCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SocialScienceAverageCS)));

                if (float.Parse(socialScienceAverageCS) < 1) colorSocialScienceAverageCS = new SolidColorBrush(Colors.Red);
                else if (float.Parse(socialScienceAverageCS) == 1) colorSocialScienceAverageCS = new SolidColorBrush(Colors.Yellow);
                else colorSocialScienceAverageCS = new SolidColorBrush(Colors.Green);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorSocialScienceAverageCS)));
            }
        }
        public string TextStudentsAverageCS
        {
            get => textstudentsAverageCS;
            set
            {
                textstudentsAverageCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextStudentsAverageCS)));

                if (float.Parse(textstudentsAverageCS) < 1) colorStudentsAverageCS = new SolidColorBrush(Colors.Red);
                else if (float.Parse(textstudentsAverageCS) <= 1.5) colorStudentsAverageCS = new SolidColorBrush(Colors.Yellow);
                else colorStudentsAverageCS = new SolidColorBrush(Colors.Green);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorStudentsAverageCS)));
            }
        }

        public string FIOCS
        {
            get => fIOCS;
            set
            {
                fIOCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FIOCS)));
            }
        } 
        public string PhysicsCS
        {
            get => physicsCS;
            set
            {
                physicsCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhysicsCS)));
            }
        }
        public string HistoryCS
        {
            get => historyCS;
            set
            {
                historyCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HistoryCS)));
            }
        }
        public string ComputerScienceCS
                {
            get => computerScienceCS;
            set
                    {
                        computerScienceCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ComputerScienceCS)));
            }
        }
        public string SocialScienceCS
                {
            get => socialScienceCS;
            set
                    {
                        socialScienceCS = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SocialScienceCS)));
            }
        }


        
        public SolidColorBrush? ColorPhysicsAverageCS
        {
            get => colorPhysicsAverageCS;
            set
            {
                colorPhysicsAverageCS = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorPhysicsAverageCS)));
            }
        }
        public SolidColorBrush ColorHistoryAverageCS
        {
            get => colorHistoryAverageCS;
            set
            {
                colorHistoryAverageCS = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorHistoryAverageCS)));
            }
        }
        public SolidColorBrush ColorComputerScienceAverageCS
        {
            get => colorComputerScienceAverageCS;
            set
            {
                colorComputerScienceAverageCS = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorComputerScienceAverageCS)));
            }
        }
        public SolidColorBrush ColorSocialScienceAverageCS
        {
            get => colorSocialScienceAverageCS;
            set
            {
                colorSocialScienceAverageCS = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorSocialScienceAverageCS)));
            }
        }
        public SolidColorBrush ColorStudentsAverageCS
        {
            get => colorStudentsAverageCS;
            set
            {
                colorStudentsAverageCS = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorSocialScienceAverageCS)));
            }
        }

        public Student selectedItem;
        public Student SelectedItem
        {
            get => selectedItem;
            set => this.RaiseAndSetIfChanged(ref selectedItem, value);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ReactiveCommand<Unit, Unit> RemuveStudent { get; }
        public ReactiveCommand<Unit, Unit> AddStudent { get; }

        BinaryFormatter binFormatter = new BinaryFormatter();
        public void SaveList()
        {
            if (studentsList.Count > 0)
            {
                List<StudentSave> studentSave = new List<StudentSave>();
                foreach(Student i in studentsList)
                {
                    StudentSave buff = new StudentSave(
                        i.TextFIOCS, 
                        i.TextPhysicsCS, 
                        i.TextHistoryCS,
                        i.TextComputerScienceCS,
                        i.TextSocialScienceCS,
                        i.TextAverageCS
                        );
                    studentSave.Add(buff);
                }
                using (var file = new FileStream("list.bin", FileMode.OpenOrCreate))
                {
                    binFormatter.Serialize(file, studentSave);
                }
                
            }
        }
        public void LoadList()
        {
            StudentsList.Clear();
            using (var file = new FileStream("list.bin", FileMode.OpenOrCreate))
            {
                List<StudentSave> newGroups = binFormatter.Deserialize(file) as List<StudentSave>;
                if (newGroups.Count > 0)
                {
                    foreach (StudentSave i in newGroups)
                    {
                        StudentsList.Add(new Student
                        {
                            TextFIOCS = i.TextFIOCS,
                            TextPhysicsCS = i.TextPhysicsCS,
                            TextHistoryCS = i.TextHistoryCS,
                            TextComputerScienceCS = i.TextComputerScienceCS,
                            TextSocialScienceCS = i.TextSocialScienceCS,
                            TextAverageCS = Convert.ToString(AverageStudentCS())
                        });
                        AverageAllStudentsCS();
                    }
                }
            }
        }
        private float AverageStudentCS()
        {
            float rez = 0;
            rez = (float.Parse(physicsCS) + float.Parse(historyCS) + float.Parse(computerScienceCS) + float.Parse(socialScienceCS))/4.0f;
            return rez;
        }
        public void AverageAllStudentsCS()
        {
            float c = studentsList.Count(), CS1=0, CS2=0, CS3=0, CS4=0, CS5=0;
            foreach (Student item in studentsList)
            {
                if (item != null)
                {
                    CS1 += float.Parse(item.TextPhysicsCS);
                    CS2 += float.Parse(item.TextHistoryCS);
                    CS3 += float.Parse(item.TextComputerScienceCS);
                    CS4 += float.Parse(item.TextSocialScienceCS);
                    CS5 += float.Parse(item.TextAverageCS);
                }
            }
            PhysicsAverageCS = Convert.ToString((float)CS1 / (float)c);
            HistoryAverageCS = Convert.ToString((float)CS2 / (float)c);    
            ComputerScienceAverageCS = Convert.ToString((float)CS3 / (float)c);
            SocialScienceAverageCS = Convert.ToString((float)CS4 / (float)c);
            TextStudentsAverageCS = Convert.ToString((float)CS5 / (float)c);
        }       
    }
}
