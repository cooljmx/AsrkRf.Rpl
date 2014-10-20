using System.Windows;
using AsrkRf.Rpl.EntityQueryEditor.Helpers;
using AsrkRf.Rpl.EntityQueryEditor.Model;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Editors;

namespace AsrkRf.Rpl.EntityQueryEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private const string DefTitle = "AsrkRf.Rpl.EntityQueryEditor";
        private readonly MainModel model = new MainModel();
        public MainModel Model { get { return model; } }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewFile_OnItemClick(object sender, ItemClickEventArgs e)
        {
            Model.NewFile();
        }

        private void OpenFile_OnItemClick(object sender, ItemClickEventArgs e)
        {
            Model.Open();
        }

        private void SaveFile_OnItemClick(object sender, ItemClickEventArgs e)
        {
            Model.Save();
        }

        private void SaveAsFile_OnItemClick(object sender, ItemClickEventArgs e)
        {
            Model.SaveAs();
        }

        private void Close_OnItemClick(object sender, ItemClickEventArgs e)
        {
            if (Model.Close())
                Close();
        }

        private void AddQuery_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var inputBox = InputBox.InputBoxDialog(DefTitle, "Имя сущности");
            var dialogResult = inputBox.ShowDialog();
            if (dialogResult == true)
            {
                Model.AddQuery(inputBox.Model.Text);
            }
        }

        private void RenameQuery_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var inputBox = InputBox.InputBoxDialog(DefTitle, "Укажите новое имя сущности", Model.SelectedEntity.ClassName);
            var inputBoxResult = inputBox.ShowDialog();
            if (inputBoxResult != null && inputBoxResult == true)
                Model.SelectedEntity.ClassName = inputBox.Model.Text;
        }

        private void RemoveQuery_OnItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Удалить сущность?", DefTitle, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Model.Entities.Remove(Model.SelectedEntity);
            }
        }

        private void BaseEdit_OnEditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            Model.Modified = true;
        }
    }
}
