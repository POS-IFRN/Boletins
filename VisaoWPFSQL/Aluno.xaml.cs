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
    /// Interaction logic for Aluno.xaml
    /// </summary>
    public partial class Aluno : Window
    {
        public Aluno()
        {
            InitializeComponent();
            setItemsSource();
        }

        private void setItemsSource()
        {
            listBox.ItemsSource = new NegocioSQL.Curso().Select();
            listBox.DisplayMemberPath = "Descricao";
            listBox.SelectedValuePath = "Id";
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            new NegocioSQL.Aluno().Insert(new Modelo.Aluno
            {
                Id = int.Parse(txtId.Text),
                Nome = txtNome.Text,
                email = txtEmail.Text,
                fone = txtFone.Text,
                nascimento = Convert.ToDateTime(dtNascimento.SelectedDate),
                IdCurso = Convert.ToInt16(listBox.SelectedValue)
            });
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = new NegocioSQL.Aluno().Select();
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            new NegocioSQL.Aluno().Update(new Modelo.Aluno
            {
                Id = int.Parse(txtId.Text),
                Nome = txtNome.Text,
                email = txtEmail.Text,
                fone = txtFone.Text,
                nascimento = Convert.ToDateTime(dtNascimento.SelectedDate),
                IdCurso = Convert.ToInt16(listBox.SelectedValue)
            });
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            new NegocioSQL.Aluno().Delete(new Modelo.Aluno
            {
                Id = int.Parse(txtId.Text)
            });
        }
    }
}
