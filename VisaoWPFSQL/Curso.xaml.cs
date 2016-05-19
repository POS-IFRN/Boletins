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

namespace VisaoWPFSQL
{
    /// <summary>
    /// Interaction logic for Curso.xaml
    /// </summary>
    public partial class Curso : Window
    {
        public Curso()
        {
            InitializeComponent();
        }
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            /*Modelo.Curso c = new Modelo.Curso();
            c.Id = int.Parse(txtID.Text);
            c.Descricao = txtDesc.Text;
            Negocio.Curso cu = new Negocio.Curso();
            cu.Insert(c);*/
            new NegocioSQL.Curso().Insert(new Modelo.Curso
            {
                Id = int.Parse(txtID.Text),
                Descricao = txtDesc.Text
            });
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = new NegocioSQL.Curso().Select();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            new NegocioSQL.Curso().Update(new Modelo.Curso
            {
                Id = int.Parse(txtID.Text),
                Descricao = txtDesc.Text
            });
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            new NegocioSQL.Curso().Delete(new Modelo.Curso
            {
                Id = int.Parse(txtID.Text)
            });
        }
    }
}
