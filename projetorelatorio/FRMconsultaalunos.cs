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
    public partial class FRMconsultaalunos : Form
    {
        string cnsql = "";
        public FRMconsultaalunos(string cn)
        {
            cnsql = cn;
            InitializeComponent();
        }

        private void consultar()
        {
            dataGridView1.Rows.Clear();//limpando os dados do grid
            string sql = "select * from ALUNOS ORDER BY NOME";//envniando uma instrução em sql para o banco
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando o caminho onde está alocado o banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//enviando o caminho e a instrução em sql para o  banco
            conexao.Open();//abrindo conexão



            MySqlDataReader leia = comando.ExecuteReader();//enviando uma variavel que irá realizar uma leitura dos dados



            if (leia.HasRows)//encontrou alguma coisa?
            {



                button2.Visible = true; //habilita o botÃO IMPRIMIR



                while (leia.Read())//enquanto o leia estiver encontrando dados ele vai exibir as informações no grid, registro por registro
                {
                    dataGridView1.Rows.Add(Convert.ToString(leia["codigo"]), Convert.ToString(leia["NOME"]), Convert.ToString(leia["cpf"]), Convert.ToString(leia["rg"]), Convert.ToString(leia["dn"]));
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
            string sql = "insert into alunos (nome,cpf,rg,dn) values (@nome,@cpf,@rg,@dn)";
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
            string sql = "delete from alunos where codigo = '" + textBox5.Text + "'";
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
            string sql = "update  alunos set nome=@nome,cpf=@cpf,rg=@rg where codigo='" + textBox5.Text + "'";
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

        //função verifica cadastro igual
        private void verificacadastroigual()
        {
            string sql = "select * from alunos where cpf=@cpf";//envniando uma instrução em sql para o banco
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando o caminho onde está alocado o banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//enviando o caminho e a instrução em sql para o banco
            comando.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = textBox3.Text;

            conexao.Open();//abrindo conexão

            MySqlDataReader leia = comando.ExecuteReader();//enviando uma variavel que irá realizar uma leitura dos dados

            if (leia.HasRows)//encontrou alguma coisa?
            {
                MessageBox.Show("CPF já existe: " + textBox3.Text + ", Por favor, Verifique o CPF", "Ajuda do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Clear();//limpando
            }


            conexao.Close();
        }

        private void imprimir()
        {
            ListaAlunos alunos = new ListaAlunos(); //aponta para a lista
            string sql = "select * from alunos";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando o caminho onde está alocado o banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//enviando o caminho e a instrução em sql para o  banco
            conexao.Open();//abrindo conexão
            MySqlDataReader leia = comando.ExecuteReader();//enviando uma variavel que irá realizar uma leitura dos dados
            if (leia.HasRows)
            {
                //int x = 0;
                while (leia.Read())
                {
                    //  x++;
                    Classalunos linha = new Classalunos();//Aponta para objeto
                    linha.Codigo = Convert.ToInt32(leia["codigo"]);
                    linha.Nome = Convert.ToString(leia["nome"]);
                    linha.Cpf = Convert.ToString(leia["cpf"]);
                    linha.Rg = Convert.ToString(leia["rg"]);
                    alunos.Add(linha);
                }
            }
            conexao.Close();

            FRMrelatorioalunos relatorio = new FRMrelatorioalunos();
            relatorio.imprimir(alunos);
            relatorio.ShowDialog();
            relatorio.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consultar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        private void FRMconsultaalunos_Load(object sender, EventArgs e)
        {

        }

        //BOTAO INSERIR
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
        private void label2_Click(object sender, EventArgs e)
        {

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

        private void FRMconsultaalunos_DoubleClick(object sender, EventArgs e)
        {
         
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                verificacadastroigual();//chamando a função verifica cadastro igual
            }

        }

        private void FRMconsultaalunos_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox5.Text == "")
            {
                verificacadastroigual();//chamando a função verifica cadastro igual
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
