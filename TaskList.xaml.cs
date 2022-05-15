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
    /// Interaction logic for TaskList.xaml
    /// </summary>
    public partial class TaskList : Page
    {
        private List<TaskModel> taskList = new List<TaskModel>();
        private NavigationService ns;

        public TaskList()
        {
            InitializeComponent();
            RefreshTasks();
        }

        private void RefreshTasks()
        {
            //listBoxItemColor = Brushes.Black;
            tasks.Items.Clear();
            taskList = SQLiteDataAccess.LoadTasks();
            foreach (TaskModel task in taskList)
            {
                ListBoxItem lbi = new ListBoxItem
                {
                    Content = task.GetTitle()
                };

                if (task.IsCompleted())
                {
                    lbi.Foreground = Brushes.Green;
                }

                tasks.Items.Add(lbi);
            }
        }

        private void ButtonRefreshTasks_Click(object sender, RoutedEventArgs e)
        {
            RefreshTasks();
        }

        private void ButtonDelTask_Click(object sender, RoutedEventArgs e)
        {
            //If item is selected then uses that item's index in taskList to delete object from database
            if(tasks.SelectedIndex > -1)
            {
                SQLiteDataAccess.DelTask(taskList[tasks.SelectedIndex]);

                //Clear preview
                taskTitle.Clear();
                taskDesc.Clear();

                RefreshTasks();
            }
        }

        private void ButtonNewTask_Click(object sender, RoutedEventArgs e)
        {
            //Instantiate NewTask page
            NewTask page = new NewTask();
            ns = NavigationService.GetNavigationService(this);
            ns.Navigate(page);

        }

        private void ButtonSaveTask_Click(object sender, RoutedEventArgs e)
        {
            //Make changes to TaskModel object
            taskList[tasks.SelectedIndex].SetTitle(taskTitle.Text);
            taskList[tasks.SelectedIndex].SetDescription(taskDesc.Text);

            //Clear textboxes
            taskTitle.Clear();
            taskDesc.Clear();

            //Update object in db
            SQLiteDataAccess.UpdateTask(taskList[tasks.SelectedIndex]);

            RefreshTasks();
        }

        private void ButtonCompleteTask_Click(object sender, RoutedEventArgs e)
        {
            //Make changes to TaskModel object
            taskList[tasks.SelectedIndex].SetCompleted(true);

            //Update object in db
            SQLiteDataAccess.UpdateTask(taskList[tasks.SelectedIndex]);

            RefreshTasks();
        }

        private void TaskPreview(object sender, SelectionChangedEventArgs e)
        {
            //ListBoxItem lbi = (sender as ListBox).SelectedItem as ListBoxItem;
            if(tasks.SelectedIndex > -1)
            {
                taskTitle.Text = taskList[tasks.SelectedIndex].GetTitle();
                taskDesc.Text = taskList[tasks.SelectedIndex].GetDescription();
            }
        }

        private void ButtonResetTask_Click(object sender, RoutedEventArgs e)
        {
            if(tasks.SelectedIndex > -1)
            {
                taskTitle.Text = taskList[tasks.SelectedIndex].GetTitle();
                taskDesc.Text = taskList[tasks.SelectedIndex].GetDescription();
            }
        }
    }
}
