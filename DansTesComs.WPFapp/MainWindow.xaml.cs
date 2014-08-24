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

namespace DansTesComs.WPFapp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var objA = new { name = "objA", num = 1 };
            var objB = new { name = "objB", num = 2 };
            var objC = new { name = "objC", num = 3 };
            var list = new []
            {
                objA,
                objB,
                objC,
                objA,
                objC
            }.ToList();
            
            list.Sort((o,o1)=>{
                                  if (o.num > o1.num)
                                      return 1;
                                  if (o.num < o1.num)
                                      return -1;
                                  return 0;
            });
            list.Distinct();
            ListBox.ItemsSource = list;
        }
    }
}
