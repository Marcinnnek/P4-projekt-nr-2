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
        private int SelectedIDSteelJoint = 0;
        public WindowBillOfMaterials()
        {
            InitializeComponent();

            IDCheckButtonEnabled();

            RefreshPosition();

            LoadBoltTypes();
            LoadDiameterTypes();
            LoadLenghtTypes();
            LoadNutType();
            LoadWasherType();
        }

        private void IDCheckButtonEnabled()
        {
            if (SelectedIDSteelJoint == 0)
            {
                btDeletePosition.IsEnabled = false;
                btUpdatePosition.IsEnabled = false;
            }
            else
            {
                btDeletePosition.IsEnabled = true;
                btUpdatePosition.IsEnabled = true;
            }
        }

        private void LoadBoltTypes()
        {
            myDB getMaterials = new myDB();
            cbBoltType.DataContext = getMaterials.GetBoltType();
        }

        private void LoadDiameterTypes()
        {
            myDB getMaterials = new myDB();
            cbDiameterType.DataContext = getMaterials.GetDiameterType();
        }
        private void LoadLenghtTypes()
        {
            myDB getMaterials = new myDB();
            cbLenghtType.ItemsSource = getMaterials.GetLenghtType();
        }

        private void LoadNutType()
        {
            myDB getMaterials = new myDB();
            cbNutType.ItemsSource = getMaterials.GetNutType();
        }

        private void LoadWasherType()
        {
            myDB getMaterials = new myDB();
            cbWasherThirdType.ItemsSource = cbWasherSecondType.ItemsSource = cbWasherFirstType.ItemsSource = getMaterials.GetWasherType();
        }

        private void RefreshPosition()
        {
            myDB getPosition = new myDB();
            DGPositionList.DataContext = getPosition.GetBillOfMaterials(DataTransfer.IDFacilityDT);
        }
        private void DGPositionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BillOfMaterialsCombo BOMc = DGPositionList.SelectedItem as BillOfMaterialsCombo;
            if (BOMc == null)
            {
                RefreshPosition();
            }
            else
            {
                SelectedIDSteelJoint = BOMc.ID_SteelJoint;
                tbJointName.Text = BOMc.JointName;
                tbNumberOFSteelJoints.Text = BOMc.NumberOfSteelJoint.ToString();
                tbPiecesOfSteelJoints.Text = BOMc.PiecesOfSteelJoint.ToString();

                cbBoltType.SelectedValue = BOMc.ID_Bolt;
                cbDiameterType.SelectedValue = BOMc.ID_Diameter;
                cbLenghtType.SelectedValue = BOMc.ID_Lenght;
                cbWasherFirstType.SelectedValue = BOMc.BoltWasherFirst;
                cbWasherSecondType.SelectedValue = BOMc.BoltWasherSecond;
                cbWasherThirdType.SelectedValue = BOMc.BoltWasherThird;
                cbNutType.SelectedValue = BOMc.ID_Nut;

                Console.WriteLine(SelectedIDSteelJoint);
            }

            IDCheckButtonEnabled();
        }

        private void btAddPosition_Click(object sender, RoutedEventArgs e)
        {
            if (DataCheckPosition() == true)
            {
                IDCheckButtonEnabled();
                BillOfMaterials newPositionBOM = new BillOfMaterials()
                {
                    ID_Facility = DataTransfer.IDFacilityDT,

                    JointName = tbJointName.Text,

                    ID_Bolt = int.Parse(cbBoltType.SelectedValue.ToString()),
                    ID_Diameter = int.Parse(cbDiameterType.SelectedValue.ToString()),
                    ID_Lenght = int.Parse(cbLenghtType.SelectedValue.ToString()),
                    BoltWasherFirst = int.Parse(cbWasherFirstType.SelectedValue.ToString()),
                    BoltWasherSecond = int.Parse(cbWasherSecondType.SelectedValue.ToString()),
                    BoltWasherThird = int.Parse(cbWasherThirdType.SelectedValue.ToString()),
                    ID_Nut = int.Parse(cbNutType.SelectedValue.ToString()),

                    NumberOfSteelJoint = int.Parse(tbNumberOFSteelJoints.Text),
                    PiecesOfSteelJoint = int.Parse(tbPiecesOfSteelJoints.Text)

                };

                myDB getPositions = new myDB();
                getPositions.InsterPosition(newPositionBOM);
                MessageBox.Show("Dodano nową pozycje!", "Pozycja");
                RefreshPosition();
            }
            else
                MessageBox.Show("Sprawdź poprawność danych!");
        }

        private bool DataCheckPosition()
        {
            if (tbJointName.Text.Length <= 3)
            {
                MessageBox.Show("Za krótka nazwa obiektu (min 3 znaki)", "Dane");
                return false;
            }
            else if (int.Parse(tbNumberOFSteelJoints.Text) > 0)
            {
                MessageBox.Show("Liczba zestawów nie może wynosić 0!", "Dane");
                return false;
            }
            else if (int.Parse(tbPiecesOfSteelJoints.Text) > 0)
            {
                MessageBox.Show("Liczba połączeń nie może wynosić 0!", "Dane");
                return false;
            }
            return true;
        }

        private void cbBoltType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(cbBoltType.SelectedValue.ToString());
        }
    }
}
