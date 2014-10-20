using System.Windows;

namespace AsrkRf.Rpl.EntityQueryEditor.Helpers
{
    /// <summary>
    /// Interaction logic for InputBox.xaml
    /// </summary>
    public partial class InputBox
    {
        private readonly InputBoxModel model = new InputBoxModel();
        public InputBoxModel Model { get { return model; } }
        public InputBox()
        {
            InitializeComponent();
            //DataContext = Model;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (Model.Text == string.Empty)
            {
                MessageBox.Show("Введите значение!", Model.Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DialogResult = true;
                Close();
            }
        }

        public static InputBox InputBoxDialog(string title, string caption, string defaultText = "")
        {
            var inputBox = new InputBox();
            inputBox.Model.Title = title;
            inputBox.Model.Caption = caption;
            inputBox.Model.Text = defaultText;
            return inputBox;
        }
    }
}
