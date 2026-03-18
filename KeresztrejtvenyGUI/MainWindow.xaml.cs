using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeresztrejtvenyGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /// 
    /// 
    /// 
    /// elnezest hogy nem commiteltem a nagyreszet az xaml.cs-nek, minden dologhoz amit csinaltam a grafikus reszen elkezdtem csinalni a megoldasat es a mentesnel jottem ra hogy commitelgetni kellett volna
    public partial class MainWindow : Window
    {
        int sorok;
        int oszlopok;
        //A
        public MainWindow()
        {
            InitializeComponent();        
            for (int i = 6; i <= 15; i++)
            {
                cbSor.Items.Add(i);
                cbOszlop.Items.Add(i);
            }
            cbSor.SelectedItem = 15;
            cbOszlop.SelectedItem = 15;

            for (int i = 1; i <= 10; i++)
                cbIndex.Items.Add(i);

            cbIndex.SelectedItem = 3;
        }
        //b
        //a letrehoz click kb felet kiadta a visual studio magatol ez valszeg ainak szamit meg akkor is ha veletlen
        private void Letrehoz_Click(object sender, RoutedEventArgs e)
        {
            gridRacs.Children.Clear();

            oszlopok = (int)cbOszlop.SelectedItem;
            sorok = (int)cbSor.SelectedItem;
            gridRacs.Rows = sorok;
            gridRacs.Columns = oszlopok;

            for (int i = 0; i < sorok * oszlopok; i++)
            {
                TextBox tb = new TextBox();
                tb.MaxLength = 1;
                tb.Width = 25;
                tb.Height = 25;
                tb.Margin = new Thickness(1);
                tb.Text = "-";
                tb.TextAlignment = TextAlignment.Center;

                tb.MouseDoubleClick += MezoDuplaKlikk;

                gridRacs.Children.Add(tb);
            }
        }//c
        private void MezoDuplaKlikk(object sender, MouseButtonEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb.Text == "-")
                tb.Text = "#";
            else
                tb.Text = "-";
        }


        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string index = cbIndex.SelectedItem.ToString();
                string fajl = $"kr{index}.txt";

                using (StreamWriter sw = new StreamWriter(fajl))
                {
                    for (int i = 0; i < sorok; i++)
                    {
                        string sor = "";

                        for (int j = 0; j < oszlopok; j++)
                        {
                            TextBox tb = (TextBox)gridRacs.Children[i * oszlopok + j];
                            sor += tb.Text;
                        }

                        sw.WriteLine(sor);
                    }
                }

                MessageBox.Show("a keresztrejtveny mentese sikeres!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}