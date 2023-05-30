using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace projetorelatorio
{
    public partial class FRMbackup : Form
    {
        string cnsql = "";
        public FRMbackup(string cn)
        {
            cnsql = cn;
            InitializeComponent();
        }


        //ROTINA QUE RESTAURA O ARQUIVO DE BANCO DE DADOS
        private void Restaurar(string Banco, string caminho)
        {
            this.Cursor = Cursors.WaitCursor;
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando o caminho onde está alocado o banco
            using (MySqlCommand comando = new MySqlCommand())//enviando o caminho e a instrução em sql para o  banco 
            {
                using (MySqlBackup bk = new MySqlBackup(comando))
                {
                    comando.Connection = conexao;
                    conexao.Open();
                    bk.ImportFromFile(caminho);
                    conexao.Close();
                }
            }
            this.Cursor = Cursors.Default;
        }

        //ROTINA QUE CRIA O ARQUIVO DE BACKUP
        private void backup(string caminho)
        {
            this.Cursor = Cursors.WaitCursor;
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando o caminho onde está alocado o banco
            using (MySqlCommand comando = new MySqlCommand())//enviando o caminho e a instrução em sql para o  banco 
            {
                using (MySqlBackup bk = new MySqlBackup(comando))
                {
                    comando.Connection = conexao;
                    conexao.Open();
                    bk.ExportInfo.AddCreateDatabase = true;
                    bk.ExportInfo.ExportTableStructure = true;
                    bk.ExportInfo.ExportRows = true;
                    bk.ExportToFile(caminho);
                    conexao.Close();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //imagem backup
            textBox1.Clear();
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dlg.SelectedPath;//receber o caminho onde será salvo o arquivo
                button1.Enabled = true;
                button2.Enabled = false;
            }
            else
            {
                textBox1.Clear();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //imagem restaurar
            textBox1.Clear();
            //FolderBrowserDialog dlg = new FolderBrowserDialog();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Backup Files(*.sql)|.sql|All Files(*.*)|*.*";
            dlg.FilterIndex = 0;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dlg.FileName;
                button1.Enabled = false;
                button2.Enabled = true;
            }
            else
            {
                textBox1.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Botão Criar Backup
            if (textBox1.Text == "")
            {
                MessageBox.Show("Por favor Clique na Imagem Acima de Criar Arquivo de BACKUP!!!");
            }
            else
            {
                backup(textBox1.Text + "\\backup.sql");
                MessageBox.Show("Arquivo de backup Criado com Sucesso!!!");
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //botão restaurar
            if (textBox1.Text == "")
            {
                MessageBox.Show("Por favor Clique na Imagem Acima de Restaurar Arquivo de BACKUP!!!");
            }
            else
            {
                Restaurar("mysql", textBox1.Text);

                MessageBox.Show("Arquivo de backup Restaurado com Sucesso!!!");
                textBox1.Clear();
            }
        }

        private void FRMbackup_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
        }
    }
}
