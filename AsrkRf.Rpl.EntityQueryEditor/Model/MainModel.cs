using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using AsrkRf.Rpl.Common;
using Microsoft.Win32;

namespace AsrkRf.Rpl.EntityQueryEditor.Model
{
    public class MainModel : VirtualNotifyPropertyChanged
    {
        private const string DefTitle = "AsrkRf.Rpl.EntityQueryEditor";
        private string fileName = string.Empty;
        private bool modified;
        private readonly ObservableCollection<EntityModel> entities = new ObservableCollection<EntityModel>();
        private EntityModel selectedEntity;


        public string FileName { 
            get { return fileName; }
            set
            {
                fileName = value; 
                NotifyPropertyChanged("FileName"); 
                NotifyPropertyChanged("Title");
            } 
        }

        public bool Modified
        {
            get { return modified; }
            set
            {
                modified = value;
                NotifyPropertyChanged("Modified");
                NotifyPropertyChanged("Title");
            }
        }

        public ObservableCollection<EntityModel> Entities { get { return entities; } }
        public EntityModel SelectedEntity { get { return selectedEntity; } set { selectedEntity = value; NotifyPropertyChanged("selectedEntity"); } }

        public string Title
        {
            get
            {
                var result = DefTitle;
                if (FileName != string.Empty) result += string.Format(" - [{0}]", FileName);
                if (Modified) result += " *";
                return result;
            }
        }

        public void NewFile()
        {
            if (Modified)
            {
                switch (
                    MessageBox.Show("Документ не сохранен! Сохранить?", "Asrk.Rpl.Query.Editor",
                        MessageBoxButton.YesNoCancel))
                {
                    case MessageBoxResult.Yes:
                        Save();
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        return;
                }
            }
        }

        public void Open()
        {
            if (Modified)
            {
                switch (
                    MessageBox.Show("Документ не сохранен! Сохранить?", "Asrk.Rpl.Query.Editor",
                        MessageBoxButton.YesNoCancel))
                {
                    case MessageBoxResult.Yes:
                        Save();
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        return;
                }
            }
            var openDialog = new OpenFileDialog {Filter = "Query file|*.xml"};
            var openDialogResult = openDialog.ShowDialog();
            if (openDialogResult != null && openDialogResult == true)
            {
                FileName = openDialog.FileName;

                Entities.Clear();
                var queryFile = EntityFile.LoadFromFile(FileName);
                foreach (var queryModel in queryFile)
                {
                    Entities.Add(queryModel);
                }
                Modified = false;
            }
        }

        public void Save()
        {
            if (FileName == string.Empty)
            {
                var saveDialog = new SaveFileDialog {Filter = "Query file|*.xml"};
                var saveDialogResult = saveDialog.ShowDialog();
                if (saveDialogResult != null && saveDialogResult == true)
                    FileName = saveDialog.FileName;
                else
                    return;
            }
            var queryFile = new EntityFile();
            foreach (var queryModel in Entities)
            {
                queryFile.Add(queryModel);
            }
            queryFile.SaveToFile(fileName);
            modified = false;
        }

        public void SaveAs()
        {
            var saveDialog = new SaveFileDialog
            {
                Filter = "Query file|*.xml",
                FileName = Path.GetFileName(FileName),
                InitialDirectory = Path.GetDirectoryName(FileName)
            };
            var saveDialogResult = saveDialog.ShowDialog();
            if (saveDialogResult != null && saveDialogResult == true)
                FileName = saveDialog.FileName;
            else
                return;

            var queryFile = new EntityFile();
            foreach (var queryModel in Entities)
            {
                queryFile.Add(queryModel);
            }
            queryFile.SaveToFile(fileName);
            modified = false;
        }

        public void AddQuery(string name)
        {
            Entities.Add(new EntityModel {ClassName = name});
            modified = true;
        }

        public bool Close()
        {
            return false;
        }
    }
}
