using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.IO;
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

namespace WPFWorkTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        //List<TaskModel> taskList = new List<TaskModel>();
        //NavigationService ns;

        public MainWindow()
        {
            InitializeComponent();



            //ns = NavigationService.GetNavigationService(this);
            //RefreshTasks();
        }

        //private void RefreshTasks()
        //{
        //    tasks.Items.Clear();
        //    taskList = SQLiteDataAccess.LoadTasks();
        //    foreach (var task in taskList)
        //    {
        //        tasks.Items.Add(task.GetTitle());
        //    }
        //}

        ////private void ButtonAddTask_Click(object sender, RoutedEventArgs e)
        ////{
        ////    if(!string.IsNullOrWhiteSpace(taskTitle.Text) && !tasks.Items.Contains(taskTitle.Text))
        ////    {
        ////        SQLiteDataAccess.SaveTask(new TaskModel(taskTitle.Text));
        ////        RefreshTasks();
        ////        taskTitle.Clear();
        ////    }
        ////}

        //private void ButtonRefreshTasks_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void ButtonDelTask_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void ButtonNewTask_Click(object sender, RoutedEventArgs e)
        //{
        //    //Instantiate NewTask page
        //    NewTask page = new NewTask();
        //    ns = NavigationService.GetNavigationService(this);
        //    ns.Navigate(page);

        //}

        //private void ButtonSaveTask_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void ButtonCompleteTask_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
