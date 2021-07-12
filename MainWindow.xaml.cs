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
using P4_projekt_nr_2.DBservice;

namespace P4_projekt_nr_2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int ID_Facility = 0;

        public MainWindow()
        {
            InitializeComponent();
            myDB getObjects = new myDB();
            DGFacilityList.DataContext = getObjects.GetFacilities();

        }

        public void TB_GetFocus_FacilityName(object sender, RoutedEventArgs e)
        {
            if (tbFacilityName.Text == "Podaj nazwę obektu!")
            {
                TextBox tbFacilityName = (TextBox)sender;
                tbFacilityName.Text = string.Empty;
                tbFacilityName.GotFocus -= TB_GetFocus_FacilityName;
            }
        }

        public void TB_GetFocus_FacilityDescription(object sender, RoutedEventArgs e)
        {
            if (tbFacilityDescription.Text == "Podaj krótki opis obiektu!")
            {
                TextBox tbFacilityDescription = (TextBox)sender;
                tbFacilityDescription.Text = string.Empty;
                tbFacilityDescription.GotFocus -= TB_GetFocus_FacilityDescription;
            }
        }

        public void TB_GetFocus_SAP(object sender, RoutedEventArgs e)
        {
            if (tbSAP.Text == "Podaj kod identyfikacyjny SAP kontraktu!")
            {
                TextBox tbSAP = (TextBox)sender;
                tbSAP.Text = string.Empty;
                tbSAP.GotFocus -= TB_GetFocus_SAP;
            }
        }

        private void tbFacilityDescription_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (tbFacilityName.Text == "Podaj krótki opis obiektu!")
            {
                TextBox tbFacilityDescription = (TextBox)sender;
                tbFacilityDescription.Text = string.Empty;
                tbFacilityDescription.GotFocus -= TB_GetFocus_FacilityDescription;
            }
        }
    }
}
