using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projetorelatorio
{
    public partial class FRMrelatorioalunos : Form
    {
        public FRMrelatorioalunos()
        {
            InitializeComponent();
        }


        public void imprimir(ListaAlunos relatorio) //apontando para a lista
       {
            ClassalunosBindingSource.DataSource = relatorio;
       }


        private void FRMrelatorioalunos_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
