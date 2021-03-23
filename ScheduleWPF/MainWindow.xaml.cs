using Syncfusion.UI.Xaml.Schedule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScheduleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        ObservableCollection<ResourceType> _resourceCollection;
        public ObservableCollection<ResourceType> ResourceCollection
        {
            get { return _resourceCollection; }
            set
            {
                _resourceCollection = value;
                OnPropertyChanged("ResourceCollection");//to listned the property changed
            }
        }

        public MainWindow()
        {
            ResourceCollection = new ObservableCollection<ResourceType>();
            ResourceCollection.Add(new ResourceType() { TypeName = "TeamA" });
            ResourceCollection.Add(new ResourceType() { TypeName = "TeamB" });
            ResourceCollection.Add(new ResourceType() { TypeName = "TeamC" });
            ResourceCollection.Add(new ResourceType() { TypeName = "TeamD" });
            ResourceCollection.Add(new ResourceType() { TypeName = "TeamE" });

            this.InitializeComponent();

            this.DataContext = this;


            ScheduleAppointmentCollection tempcollection = new ScheduleAppointmentCollection();
            ScheduleAppointment appointment1 = new ScheduleAppointment() { StartTime = DateTime.Now.Date.AddHours(4), EndTime = DateTime.Now.Date.AddHours(6), Subject = "Johny's Appointment", AppointmentBackground = new SolidColorBrush(Colors.SteelBlue) };
            appointment1.ResourceCollection.Add(new Resource() { TypeName = "TeamA", ResourceName = "Johny" });

            ScheduleAppointment appointment2 = new ScheduleAppointment() { StartTime = DateTime.Now.Date.AddHours(4), EndTime = DateTime.Now.Date.AddHours(6), Subject = "Neal's Appointment", AppointmentBackground = new SolidColorBrush(Colors.SlateBlue) };
            appointment2.ResourceCollection.Add(new Resource() { TypeName = "TeamB", ResourceName = "Neal" });

            ScheduleAppointment appointment3 = new ScheduleAppointment() { StartTime = DateTime.Now.Date.AddHours(4), EndTime = DateTime.Now.Date.AddHours(6), Subject = "Peter's Appointment", AppointmentBackground = new SolidColorBrush(Colors.MidnightBlue) };
            appointment3.ResourceCollection.Add(new Resource() { TypeName = "TeamC", ResourceName = "Peter" });

            ScheduleAppointment appointment4 = new ScheduleAppointment() { StartTime = DateTime.Now.Date.AddHours(4), EndTime = DateTime.Now.Date.AddHours(6), Subject = "Morgan's Appointment", AppointmentBackground = new SolidColorBrush(Colors.SlateGray) };
            appointment4.ResourceCollection.Add(new Resource() { TypeName = "TeamD", ResourceName = "Morgan" });

            ScheduleAppointment appointment5 = new ScheduleAppointment() { StartTime = DateTime.Now.Date.AddHours(4), EndTime = DateTime.Now.Date.AddHours(6), Subject = "Smith's Appointment", AppointmentBackground = new SolidColorBrush(Colors.OrangeRed) };
            appointment5.ResourceCollection.Add(new Resource() { TypeName = "TeamE", ResourceName = "Smith" });

            tempcollection.Add(appointment1);
            tempcollection.Add(appointment2);
            tempcollection.Add(appointment3);
            tempcollection.Add(appointment4);
            tempcollection.Add(appointment5);

            this.schedule.Appointments = tempcollection;
            this.schedule.ScheduleResourceTypeCollection = ResourceCollection;

            this.schedule.Resource = "TeamA";

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var eventHandler = PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private void one_Click(object sender, RoutedEventArgs e)
        {
            this.schedule.Resource = "TeamA";
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            this.schedule.Resource = "TeamB";
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            this.schedule.Resource = "TeamC";
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            this.schedule.Resource = "TeamD";
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            this.schedule.Resource = "TeamE"; ;
        }

        private void johny_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as CheckBox).IsChecked)
            {
                ResourceCollection[0].ResourceCollection.Insert(0, new Resource() { ResourceName = "Johny", DisplayName = "Johny" });
            }
            else
            {
                var _resourceItem = ResourceCollection[0].ResourceCollection.FirstOrDefault(item => (item as Resource).DisplayName == "Johny");
                if (_resourceItem != null)
                {
                    ResourceCollection[0].ResourceCollection.RemoveAt(ResourceCollection[0].ResourceCollection.IndexOf(_resourceItem));
                }
            }
            this.schedule.Resource = string.Empty;
            this.schedule.ScheduleResourceTypeCollection = ResourceCollection;
            this.schedule.Resource = "TeamA";
        }

        private void alex_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as CheckBox).IsChecked)
            {
                ResourceCollection[0].ResourceCollection.Add(new Resource() { ResourceName = "Alex", DisplayName = "Alex" });
            }
            else
            {
                var _resourceItem = ResourceCollection[0].ResourceCollection.FirstOrDefault(item => (item as Resource).DisplayName == "Alex");
                if (_resourceItem != null)
                {
                    ResourceCollection[0].ResourceCollection.RemoveAt(ResourceCollection[0].ResourceCollection.IndexOf(_resourceItem));
                }
            }
            this.schedule.Resource = string.Empty;
            this.schedule.ScheduleResourceTypeCollection = ResourceCollection;
            this.schedule.Resource = "TeamA";
        }

        private void neal_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as CheckBox).IsChecked)
            {
                ResourceCollection[1].ResourceCollection.Insert(0, new Resource() { ResourceName = "Neal", DisplayName = "Neal" });
            }
            else
            {
                var _resourceItem = ResourceCollection[1].ResourceCollection.FirstOrDefault(item => (item as Resource).DisplayName == "Neal");
                if (_resourceItem != null)
                {
                    ResourceCollection[1].ResourceCollection.RemoveAt(ResourceCollection[1].ResourceCollection.IndexOf(_resourceItem));
                }
            }
            this.schedule.Resource = string.Empty;
            this.schedule.ScheduleResourceTypeCollection = ResourceCollection;
            this.schedule.Resource = "TeamB";
        }

        private void robert_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as CheckBox).IsChecked)
            {
                ResourceCollection[1].ResourceCollection.Add(new Resource() { ResourceName = "Robert", DisplayName = "Robert" });
            }
            else
            {
                var _resourceItem = ResourceCollection[1].ResourceCollection.FirstOrDefault(item => (item as Resource).DisplayName == "Robert");
                if (_resourceItem != null)
                {
                    ResourceCollection[1].ResourceCollection.RemoveAt(ResourceCollection[1].ResourceCollection.IndexOf(_resourceItem));
                }
            }
            this.schedule.Resource = string.Empty;
            this.schedule.ScheduleResourceTypeCollection = ResourceCollection;
            this.schedule.Resource = "TeamB";
        }

        private void peter_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as CheckBox).IsChecked)
            {
                ResourceCollection[2].ResourceCollection.Insert(0, new Resource() { ResourceName = "Peter", DisplayName = "Peter" });
            }
            else
            {
                var _resourceItem = ResourceCollection[2].ResourceCollection.FirstOrDefault(item => (item as Resource).DisplayName == "Peter");
                if (_resourceItem != null)
                {
                    ResourceCollection[2].ResourceCollection.RemoveAt(ResourceCollection[2].ResourceCollection.IndexOf(_resourceItem));
                }
            }
            this.schedule.Resource = string.Empty;
            this.schedule.ScheduleResourceTypeCollection = ResourceCollection;
            this.schedule.Resource = "TeamC";
        }

        private void burke_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as CheckBox).IsChecked)
            {
                ResourceCollection[2].ResourceCollection.Add(new Resource() { ResourceName = "Burke", DisplayName = "Burke" });
            }
            else
            {
                var _resourceItem = ResourceCollection[2].ResourceCollection.FirstOrDefault(item => (item as Resource).DisplayName == "Burke");
                if (_resourceItem != null)
                {
                    ResourceCollection[2].ResourceCollection.RemoveAt(ResourceCollection[2].ResourceCollection.IndexOf(_resourceItem));
                }
            }
            this.schedule.Resource = string.Empty;
            this.schedule.ScheduleResourceTypeCollection = ResourceCollection;
            this.schedule.Resource = "TeamC";
        }

        private void morgan_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as CheckBox).IsChecked)
            {
                ResourceCollection[3].ResourceCollection.Insert(0, new Resource() { ResourceName = "Morgan", DisplayName = "Morgan" });
            }
            else
            {
                var _resourceItem = ResourceCollection[3].ResourceCollection.FirstOrDefault(item => (item as Resource).DisplayName == "Morgan");
                if (_resourceItem != null)
                {
                    ResourceCollection[3].ResourceCollection.RemoveAt(ResourceCollection[3].ResourceCollection.IndexOf(_resourceItem));
                }
            }
            this.schedule.Resource = string.Empty;
            this.schedule.ScheduleResourceTypeCollection = ResourceCollection;
            this.schedule.Resource = "TeamD";
        }

        private void kate_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as CheckBox).IsChecked)
            {
                ResourceCollection[3].ResourceCollection.Add(new Resource() { ResourceName = "Kate", DisplayName = "Kate" });
            }
            else
            {
                var _resourceItem = ResourceCollection[3].ResourceCollection.FirstOrDefault(item => (item as Resource).DisplayName == "Kate");
                if (_resourceItem != null)
                {
                    ResourceCollection[3].ResourceCollection.RemoveAt(ResourceCollection[3].ResourceCollection.IndexOf(_resourceItem));
                }
            }
            this.schedule.Resource = string.Empty;
            this.schedule.ScheduleResourceTypeCollection = ResourceCollection;
            this.schedule.Resource = "TeamD";
        }

        private void smith_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as CheckBox).IsChecked)
            {
                ResourceCollection[4].ResourceCollection.Insert(0, new Resource() { ResourceName = "Smith", DisplayName = "Smith" });
            }
            else
            {
                var _resourceItem = ResourceCollection[4].ResourceCollection.FirstOrDefault(item => (item as Resource).DisplayName == "Smith");
                if (_resourceItem != null)
                {
                    ResourceCollection[4].ResourceCollection.RemoveAt(ResourceCollection[4].ResourceCollection.IndexOf(_resourceItem));
                }
            }
            this.schedule.Resource = string.Empty;
            this.schedule.ScheduleResourceTypeCollection = ResourceCollection;
            this.schedule.Resource = "TeamE";
        }

        private void sachie_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as CheckBox).IsChecked)
            {
                ResourceCollection[4].ResourceCollection.Add(new Resource() { ResourceName = "Sachie", DisplayName = "Sachie" });
            }
            else
            {
                var _resourceItem = ResourceCollection[4].ResourceCollection.FirstOrDefault(item => (item as Resource).DisplayName == "Sachie");
                if (_resourceItem != null)
                {
                    ResourceCollection[4].ResourceCollection.RemoveAt(ResourceCollection[4].ResourceCollection.IndexOf(_resourceItem));
                }
            }
            this.schedule.Resource = string.Empty;
            this.schedule.ScheduleResourceTypeCollection = ResourceCollection;
            this.schedule.Resource = "TeamE";
        }
    }
}
