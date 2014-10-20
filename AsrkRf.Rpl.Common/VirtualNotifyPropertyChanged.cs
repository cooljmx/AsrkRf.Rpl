using System.ComponentModel;

namespace AsrkRf.Rpl.Common
{
    public class VirtualNotifyPropertyChanged : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
