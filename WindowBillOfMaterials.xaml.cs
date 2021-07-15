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
using System.Windows.Shapes;
using P4_projekt_nr_2.DBservice;

namespace P4_projekt_nr_2
{
    /// <summary>
    /// Logika interakcji dla klasy WindowBillOfMaterials.xaml
    /// </summary>
    public partial class WindowBillOfMaterials : Window
    {
        public WindowBillOfMaterials()
        {
            InitializeComponent();
            RefreshDataBasePosition();
            myDB getMaterials = new myDB();
            //cbBoltType.DataContext = getMaterials.GetBoltType();
            cbDiameterType.DataContext = getMaterials.GetDiameterType();
        }

        private void RefreshDataBasePosition()
        {

            //cbLenghtType.ItemsSource = getMaterials.GetLenghtType();
            //cbNutType.ItemsSource = getMaterials.GetNutType();
            //cbWasherThirdType.ItemsSource = cbWasherSecondType.ItemsSource = cbWasherFirstType.ItemsSource = getMaterials.GetWasherType();


        }
    }
}
