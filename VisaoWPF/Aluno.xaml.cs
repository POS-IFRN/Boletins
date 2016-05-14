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
    /// Interaction logic for CRUDAluno.xaml
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
            listBox.ItemsSource = new Negocio.Curso().Select();
            listBox.DisplayMemberPath = "Descricao";
            listBox.SelectedValuePath = "Id";
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            new Negocio.Aluno().Insert(new Modelo.Aluno
            {
                Id = int.Parse(txtId.Text),
                Nome = txtNome.Text,
                email = txtEmail.Text,
                fone = txtFone.Text,
                nascimento = Convert.ToDateTime(dtNascimento.SelectedDate),
                IdCurso = Convert.ToInt16(listBox.SelectedValue)
            });
        }
    }
}
