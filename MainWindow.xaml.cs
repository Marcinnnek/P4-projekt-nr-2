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
        private static int FacilityID = 0;


        public MainWindow()
        {
            InitializeComponent();
            RefreshDataBase();

            IDCheckButtonEnabled();

        }


        private void IDCheckButtonEnabled()
        {
            if (FacilityID == 0)
            {
                btDeleteContent.IsEnabled = false;
                btUpdateContent.IsEnabled = false;
                btSelectObject.IsEnabled = false;
            }
            else
            {
                btDeleteContent.IsEnabled = true;
                btUpdateContent.IsEnabled = true;
                btSelectObject.IsEnabled = true;
            }
        }

        private void RefreshDataBase()
        {
            myDB getObjects = new myDB();
            DGFacilityList.DataContext = getObjects.GetFacilities();
        }

        private void DGFacilityList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Facility FC = DGFacilityList.SelectedItem as Facility;
            if (FC == null)
            {
                RefreshDataBase();
            }
            else
            {
                FacilityID = FC.ID_Facility;
                tbFacilityName.Text = FC.Facility_Name;
                tbFacilityDescription.Text = FC.FacilityDescription;
                tbSAP.Text = FC.SAP;
                Console.WriteLine(FacilityID + "  " + FC.Facility_Name + "  " + FC.FacilityDescription + "  " + FC.SAP);
            }

            IDCheckButtonEnabled();
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

        private void Button_ClickInsertContent(object sender, RoutedEventArgs e)
        {
            if (DataCheckFacility() == true)
            {
                IDCheckButtonEnabled();
                Facility myNUDFacility = new Facility()
                {
                    ID_Facility = FacilityID,
                    Facility_Name = tbFacilityName.Text,
                    FacilityDescription = tbFacilityDescription.Text,
                    SAP = tbSAP.Text
                };

                myDB getObjects = new myDB();
                getObjects.InsterFacility(myNUDFacility);
                MessageBox.Show("Dodano nowy obiekt!", "Dodawanie");
                RefreshDataBase();
            }
            else
                MessageBox.Show("Sprawdź poprawność danych!");
        }

        private void Button_Click_DeleteContent(object sender, RoutedEventArgs e)
        {
            IDCheckButtonEnabled();
            myDB getObjects = new myDB();
            getObjects.DeleteFacility(FacilityID);
            MessageBox.Show("Usunięto obiekt!", "Usuwanie");
            RefreshDataBase();
        }

        private void btUpdateContent_Click(object sender, RoutedEventArgs e)
        {
            if (DataCheckFacility() == true)
            {
                IDCheckButtonEnabled();
                Facility myNUDFacility = new Facility()
                {
                    ID_Facility = FacilityID,
                    Facility_Name = tbFacilityName.Text,
                    FacilityDescription = tbFacilityDescription.Text,
                    SAP = tbSAP.Text
                };
                myDB getObjects = new myDB();
                getObjects.UpdateFacility(myNUDFacility);
            }
            else
                MessageBox.Show("Uaktualniono obiekt!", "Aktualizacja");
            RefreshDataBase();
        }

        private bool DataCheckFacility()
        {
            if (tbFacilityName.Text.Length <= 3)
            {
                MessageBox.Show("Za krótka nazwa obiektu (min 3 znaki)", "Dane");
                return false;
            }
            else if (tbSAP.Text.Length != 8)
            {
                MessageBox.Show("Niepoprawny kod SAP (8 znaków)", "Dane");
                return false;
            }
            return true;
        }

        private void btSelectObject_Click(object sender, RoutedEventArgs e)
        {
            DataTransfer.IDFacilityDT = FacilityID;
            WindowBillOfMaterials newWindowBOM = new WindowBillOfMaterials();
            this.Visibility = Visibility.Hidden;
            Console.WriteLine(FacilityID);
            newWindowBOM.Show();

        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
