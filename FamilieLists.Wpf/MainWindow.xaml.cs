using System.Collections.Generic;
using System.Windows;

namespace FamilieLists.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Declareren list
        List<string> familie = new List<string>();

        //Methoden
        void VulListbox()
        {
            lstFamilieLijst.Items.Refresh();
            lstFamilieLijst.ItemsSource = familie;
        }


        //EventHandelers
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VulListbox();
        }

        private void btnVoegFamilielidToe_Click(object sender, RoutedEventArgs e)
        {
            if (txtVoornaam.Text== "" || txtAchternaam.Text == "") MessageBox.Show("Gelieve alle gegevens in te vullen");
            else
            {
                
                string familieLid;
                familieLid = $"{txtVoornaam.Text} {txtAchternaam.Text}";
                familie.Add(familieLid);
                VulListbox();
                txtAchternaam.Clear();
                txtVoornaam.Clear();
            }
        }

        private void btnVerwijderGansDeFamilie_Click(object sender, RoutedEventArgs e)
        {
            familie.Clear();
            VulListbox();
        }

        private void lstFamilieLijst_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lstFamilieLijst.SelectedItem != null)
            {

            }
            else
            {
                txtVoornaam.Clear();
                txtAchternaam.Clear();
            }
        }

        private void btnVerwijderGeselecteerdFamilielidIndex_Click(object sender, RoutedEventArgs e)
        {
            if (lstFamilieLijst.SelectedItem != null)
            {
                int index = lstFamilieLijst.SelectedIndex;
                familie.RemoveAt(index);
                VulListbox();
            }
            else  MessageBox.Show("gelieve een familie lid te selecteren"); 
        }

        private void btnVerwijderGeselecteerdFamilielidValue_Click(object sender, RoutedEventArgs e)
        {
            if (lstFamilieLijst.SelectedItem != null)
            {
                familie.Remove(lstFamilieLijst.SelectedItem.ToString());
                VulListbox();
            }
            else MessageBox.Show("gelieve een familie lid te selecteren"); 
        }
    }
}
