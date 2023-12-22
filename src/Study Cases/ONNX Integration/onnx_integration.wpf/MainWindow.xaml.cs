using onnx_integration.wpf.ViewModels;

using System.Windows;

namespace onnx_integration.wpf
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel ViewModel => (MainWindowViewModel)DataContext;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();

            var (success, exception) = ViewModel.Initialize();

            if (success)
            {
                return;
            }

            MessageBox.Show($"Failed to initialize model - {exception}");

            Application.Current.Shutdown();
        }

        private void btnSelectFile_Click(object sender, RoutedEventArgs e) => ViewModel.SelectFile();
    }
}