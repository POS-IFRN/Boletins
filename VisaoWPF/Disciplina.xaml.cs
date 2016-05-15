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

namespace VisaoWPF
{
    /// <summary>
    /// Interaction logic for Disciplina.xaml
    /// </summary>
    public partial class Disciplina : Window
    {
        public Disciplina()
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
            new Negocio.Disciplina().Insert(new Modelo.Disciplina
            {
                Id = int.Parse(txtID.Text),
                Descricao = txtDesc.Text
            });
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = new Negocio.Disciplina().Select();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            new Negocio.Disciplina().Update(new Modelo.Disciplina
            {
                Id = int.Parse(txtID.Text),
                Descricao = txtDesc.Text
            });
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            new Negocio.Disciplina().Delete(new Modelo.Disciplina
            {
                Id = int.Parse(txtID.Text),
            });
        }
    }
}
