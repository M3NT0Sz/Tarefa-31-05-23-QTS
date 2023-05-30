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
    public partial class AniversariantesAlunos : Form
    {
        string cnsql = "";
        public AniversariantesAlunos(string cn)
        {
            cnsql = cn;
            InitializeComponent();
        }

        private void consultar()
        {
            dataGridView1.Rows.Clear();//limpando os dados do grid
            string sql = "select * from alunos where dn between'" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'and'" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' order by login";//envniando uma instrução em sql para o banco
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando o caminho onde está alocado o banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//enviando o caminho e a instrução em sql para o  banco
            conexao.Open();//abrindo conexão

            MySqlDataReader leia = comando.ExecuteReader();//enviando uma variavel que irá realizar uma leitura dos dados

            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto o leia estiver encontrando dados ele vai exibir as informações no grid, registro por registro
                {
                    dataGridView1.Rows.Add(Convert.ToString(leia["id"]), Convert.ToString(leia["nome"]), Convert.ToString(leia["cpf"]), Convert.ToString(leia["rg"]) , Convert.ToString(leia["dn"]));
                }
            }
            else
            {
                MessageBox.Show("Nenhum registro encontrado!");
            }
            conexao.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            consultar();
        }
    }
}
