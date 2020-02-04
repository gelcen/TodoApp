using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace TodoApp.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FormsApplicationPage
    {
        public MainWindow()
        {
            InitializeComponent();

            Forms.Init();
            LoadApplication(new TodoApp.App(new Setup()));
        }
    }
}
