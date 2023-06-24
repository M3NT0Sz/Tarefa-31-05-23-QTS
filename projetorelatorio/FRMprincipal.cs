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
    public partial class FRMprincipal : Form
    {
        string cnsql = "";
        public FRMprincipal(string cn)
        {
            cnsql = cn;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRMconsultausuarios consulta = new FRMconsultausuarios(cnsql);
            consulta.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRMconsultaalunos alunos = new FRMconsultaalunos(cnsql);
            alunos.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FRMbackup backup = new FRMbackup(cnsql);
            backup.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRMconsultausuarios consulta = new FRMconsultausuarios(cnsql);
            consulta.ShowDialog();
        }

        private void alunosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRMconsultaalunos alunos = new FRMconsultaalunos(cnsql);
            alunos.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void professoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FMRprofessores professores = new FMRprofessores(cnsql);
            professores.ShowDialog();
        }

        private void backupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRMbackup backup = new FRMbackup(cnsql);
            backup.ShowDialog();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AniversariantesUsuarios niver = new AniversariantesUsuarios(cnsql);
            niver.ShowDialog();
        }

        private void alunosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AniversariantesAlunos niver = new AniversariantesAlunos(cnsql);
            niver.ShowDialog();
        }

        private void finançasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Financas Financas = new Financas(cnsql);
            Financas.ShowDialog();
        }
    }
}
