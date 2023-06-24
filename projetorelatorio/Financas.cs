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
    public partial class Financas : Form
    {
        string cnsql = "";
        public Financas(string cn)
        {
            cnsql = cn;
            InitializeComponent();
        }

        private void consultar()
        {
            dataGridView1.Rows.Clear();//limpando os dados do grid
            string sql = "SELECT * FROM financas ORDER BY fin_nome;";//envniando uma instrução em sql para o banco
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando o caminho onde está alocado o banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//enviando o caminho e a instrução em sql para o  banco
            conexao.Open();//abrindo conexão

            MySqlDataReader leia = comando.ExecuteReader();//enviando uma variavel que irá realizar uma leitura dos dados

            if (leia.HasRows)//encontrou alguma coisa?
            {
                while (leia.Read())//enquanto o leia estiver encontrando dados ele vai exibir as informações no grid, registro por registro
                {
                    string finPag = Convert.ToString(leia["fin_pag"]);
                    DateTime finDt = Convert.ToDateTime(leia["fin_data"]);
                    DateTime dataAtual = DateTime.Today;

                    if (finPag == "Sim")
                    {
                        dataGridView1.Rows.Add(Convert.ToString(leia["fin_cod"]), Convert.ToString(leia["fin_nome"]), Convert.ToString(leia["fin_valor"]), Convert.ToString(leia["fin_pag"]), Convert.ToString(leia["fin_data"]));
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Green;
                    }
                    else if (finDt < dataAtual)
                    {
                        dataGridView1.Rows.Add(Convert.ToString(leia["fin_cod"]), Convert.ToString(leia["fin_nome"]), Convert.ToString(leia["fin_valor"]), Convert.ToString(leia["fin_pag"]), Convert.ToString(leia["fin_data"]));
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else if (finPag == "Não" || finDt > dataAtual)
                    {
                        dataGridView1.Rows.Add(Convert.ToString(leia["fin_cod"]), Convert.ToString(leia["fin_nome"]), Convert.ToString(leia["fin_valor"]), Convert.ToString(leia["fin_pag"]), Convert.ToString(leia["fin_data"]));
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }

            else
            {
                MessageBox.Show("Nenhum Registro Encontrado!", "Ajuda do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexao.Close();
        }
        //CRIANDO A FUNÇÃO INSERIR (GLOBAL)
        private void inserir()
        {
            string sql = "insert into financas (fin_nome,fin_valor,fin_pag,fin_data) values (@nome,@cpf,@rg,@dn)";
            //enviando uma instrução em sql para a variavel com nome de sql

            MySqlConnection conexao = new MySqlConnection(cnsql);
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.Add("@nome", MySqlDbType.VarChar).Value = textBox1.Text;
            comando.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = textBox3.Text;
            comando.Parameters.Add("@rg", MySqlDbType.VarChar).Value = textBox2.Text;
            comando.Parameters.Add("dn", MySqlDbType.Date).Value = dateTimePicker1.Value;

            conexao.Open();//abrindo conexão com o banco


            int result = comando.ExecuteNonQuery();
            //criando uma variavel do tipo inteiro que vai verificar se o banco existe,
            //se existe a tabela
            //se existe os campos e se os campos são do especificados

            if (result > 0)
            {
                MessageBox.Show("Dados inseridos com sucesso!");

                //chamando a função do CLICK do botão limpar
                button4_Click(null, null);

                consultar();//CHAMANDO A FUNÇÃO CONSULTAR dentro da função INSERIR
            }
            else
            {
                MessageBox.Show("Erro!");
            }
        }

        private void excluir()
        {
            string sql = "delete from financas where fin_cod = '" + textBox5.Text + "'";
            //enviando uma instrução em sql para a variavel com nome de sql
            MySqlConnection conexao = new MySqlConnection(cnsql);
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            conexao.Open();//abrindo conexão com o banco
            int result = comando.ExecuteNonQuery();
            //criando uma variavel do tipo inteiro que vai verificar se o banco existe,
            //se existe a tabela
            //se existe os campos e se os campos são do especificados
            if (result > 0)
            {
                MessageBox.Show(result + " Registro Excluido com Sucesso!");
                //chamando a função limpar
                button4_Click(null, null);
                consultar();//CHAMANDO A FUNÇÃO CONSULTAR dentro da função INSERIR
            }
            else
            {
                MessageBox.Show("Erro! Registro não Excluido!");
            }
        }

        private void alterar()
        {
            string sql = "update financas set fin_nome=@nome,fin_valor=@cpf,fin_pag=@rg where fin_cod='" + textBox5.Text + "'";
            //enviando uma instrução em sql para a variavel com nome de sql

            MySqlConnection conexao = new MySqlConnection(cnsql);
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.Add("@nome", MySqlDbType.VarChar).Value = textBox1.Text;
            comando.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = textBox3.Text;
            comando.Parameters.Add("@rg", MySqlDbType.VarChar).Value = textBox2.Text;

            conexao.Open();//abrindo conexão com o banco


            int result = comando.ExecuteNonQuery();
            //criando uma variavel do tipo inteiro que vai verificar se o banco existe,
            //se existe a tabela
            //se existe os campos e se os campos são do especificados

            if (result > 0)
            {
                MessageBox.Show(result + " Registro alterado com sucesso!");

                //chamando a função do CLICK do botão limpar
                button4_Click(null, null);

                consultar();//CHAMANDO A FUNÇÃO CONSULTAR dentro da função INSERIR
            }
            else
            {
                MessageBox.Show("Erro! - Dados não alterados");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consultar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Preencha o nome!");
                textBox1.Focus();
            }
            else
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Preencha o CPF!");
                    textBox3.Focus();
                }
                else
                    if (textBox2.Text == "")
                    {
                        MessageBox.Show("Preencha o RG!");
                        textBox2.Focus();
                    }
                    else
                        if (textBox5.Text == "")
                        {
                            inserir(); //chamando a função inserir
                        }
                        else
                        {
                            alterar();
                        }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //botão excluir
            DialogResult Excluir = MessageBox.Show("Deseja Realmente Excluir o Registro? Essa Operação é IRREVERSÍVEL?", "EXCLUIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Excluir == DialogResult.Yes)
            {
                excluir();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
        }
    }
}
