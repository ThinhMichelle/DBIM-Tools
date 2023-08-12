using MEP_Tools.Hanger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace MEP_Tools.Rebar
{
    /// <summary>
    /// Interaction logic for Main_Rebar.xaml
    /// </summary>
    public partial class Main_Rebar : Window
    {
        public Create_Rebar MainViewModel { get; set; }
        public Main_Rebar()
        {
            InitializeComponent();
            this.DataContext = MainViewModel = new Create_Rebar();
        }

        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in ClsData_Rebar.List_Hook)
            {
                cbb_hook_start.Items.Add(item.Name);
                cbb_hook_end.Items.Add(item.Name);

            }
            if (ClsData_Rebar.List_Linkcad.Count != 0)
            {
                foreach (var item in ClsData_Rebar.List_Linkcad)
                {
                    CheckBox chk = new CheckBox();
                    chk.Content = item.Category.Name;
                    list_box_linkcad.Items.Add(chk);
                }
            }
            else list_box_linkcad.Items.Add("No find linkcad in project");
           
        }
    }
}
