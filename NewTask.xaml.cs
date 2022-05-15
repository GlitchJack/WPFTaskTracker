using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFWorkTracker
{
    /// <summary>
    /// Interaction logic for NewTask.xaml
    /// </summary>
    public partial class NewTask : Page
    {
        List<TaskModel> taskList = new List<TaskModel>();
        NavigationService ns;

        public NewTask()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            //Instantiate TaskList page
            TaskList page = new TaskList();
            ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);
        }

        private void BtnFinish_Click(object sender, RoutedEventArgs e)
        {
            //Load tasks to be able to check against
            taskList = SQLiteDataAccess.LoadTasks();

            //Create task object
            TaskModel task = null;
            if(!string.IsNullOrWhiteSpace(taskTitle.Text))
            {
                task = new TaskModel(taskTitle.Text);

                //Only add description to db if filled out
                if(!string.IsNullOrWhiteSpace(taskDesc.Text))
                {
                    task.SetDescription(taskDesc.Text);
                }
            }

            //Save info to db
            if (task != null && !taskList.Contains(task))
            {
                SQLiteDataAccess.SaveTask(task);
            }

            //Instantiate TaskList page
            TaskList page = new TaskList();
            ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);
        }
    }
}
