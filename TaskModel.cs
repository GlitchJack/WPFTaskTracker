using System;
using System.Collections.Generic;
using System.Text;

namespace WPFWorkTracker
{
    public class TaskModel
    {
        private string Title;
        private bool Completed;
        private string Description;

        public TaskModel()
        {
            Title = "";
            Completed = false;
            Description = null;
        }

        public TaskModel(string title)
        {
            Title = title;
            Completed = false;
            Description = null;
        }

        public TaskModel(string title, string desc)
        {
            Title = title;
            Completed = false;
            Description = desc;
        }

        public string GetTitle()
        {
            return Title;
        }

        public void SetTitle(string str)
        {
            Title = str;
        }

        public bool IsCompleted()
        {
            return Completed;
        }

        public void SetCompleted(bool val)
        {
            Completed = val;
        }

        public string GetDescription()
        {
            return Description;
        }

        public void SetDescription(string str)
        {
            Description = str;
        }
    }
}
