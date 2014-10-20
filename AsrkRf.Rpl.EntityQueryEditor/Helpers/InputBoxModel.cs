using AsrkRf.Rpl.Common;
using AsrkRf.Rpl.EntityQueryEditor.Model;

namespace AsrkRf.Rpl.EntityQueryEditor.Helpers
{
    public class InputBoxModel : VirtualNotifyPropertyChanged
    {
        private string title = "Title";
        private string caption = "Caption";
        private string text = "";

        public string Title { get { return title; } set { title = value; NotifyPropertyChanged("Title"); } }
        public string Caption { get { return caption; } set { caption = value; NotifyPropertyChanged("Caption"); } }
        public string Text { get { return text; } set { text = value; NotifyPropertyChanged("Text"); } }
    }
}
