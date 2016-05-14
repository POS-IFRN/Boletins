﻿using System;
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
    /// Interaction logic for NOTAAluno.xaml
    /// </summary>
    public partial class Nota : Window
    {
        public Nota()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            Modelo.Boletim b = new Modelo.Boletim();
            b.Ano = int.Parse(txtAno.Text);
            b.Nota1 = int.Parse(txtNota1.Text);
            b.Nota2 = int.Parse(txtNota2.Text);
            b.Nota3 = int.Parse(txtNota3.Text);
            b.Nota4 = int.Parse(txtNota3.Text);
            b.IdAluno = Convert.ToInt16(listAlunos.SelectedValue);
            b.IdDisciplina = Convert.ToInt16(listDisciplina.SelectedValue);
            b.MediaParcial = (int.Parse(txtNota1.Text) + int.Parse(txtNota2.Text) + int.Parse(txtNota3.Text) + int.Parse(txtNota4.Text)) / 4;
            if (b.MediaParcial < 6)
            {
                b.NotaFinal = int.Parse(txtNotaFinal.Text);
                b.MediaFinal = b.MediaParcial + b.NotaFinal / 2;
            }
            else
            {
                b.NotaFinal = 0;
                b.MediaFinal = b.MediaParcial;
            }
            new Negocio.Boletim().Insert(b);
        }
    }
}