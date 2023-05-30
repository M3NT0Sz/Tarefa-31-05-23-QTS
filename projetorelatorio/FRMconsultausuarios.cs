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
    public partial class FRMconsultausuarios : Form
    {
        string cnsql = "";
        public FRMconsultausuarios(string cn)
        {
            cnsql = cn;
            InitializeComponent();
        }


        private void consultar()
        {
            dataGridView1.Rows.Clear();//limpando os dados do grid
            string sql = "select * from USUARIOS ORDER BY Login";//envniando uma instrução em sql para o banco
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando o caminho onde está alocado o banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//enviando o caminho e a instrução em sql para o  banco
            conexao.Open();//abrindo conexão



            MySqlDataReader leia = comando.ExecuteReader();//enviando uma variavel que irá realizar uma leitura dos dados



            if (leia.HasRows)//encontrou alguma coisa?
            {



                button2.Visible = true; //habilita o botÃO IMPRIMIR



                while (leia.Read())//enquanto o leia estiver encontrando dados ele vai exibir as informações no grid, registro por registro
                {
                    dataGridView1.Rows.Add(Convert.ToString(leia["id"]), Convert.ToString(leia["login"]), Convert.ToString(leia["senha"]),  Convert.ToString(leia["dn"]));
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
            string sql = "insert into usuarios (login,senha,dn) values (@login,@senha,@dn)";
            //enviando uma instrução em sql para a variavel com nome de sql

            MySqlConnection conexao = new MySqlConnection(cnsql);
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBox1.Text;
            comando.Parameters.Add("@senha", MySqlDbType.VarChar).Value = Criptografia.MD5(textBox3.Text);
            comando.Parameters.Add("@dn", MySqlDbType.Date).Value = dateTimePicker1.Value;
          

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


        private void button1_Click(object sender, EventArgs e)
        {
            consultar();
        }


        private void imprimir()
        {
            ListaUsuarios cadastro = new ListaUsuarios(); //aponta para a lista
            string sql = "select * from usuarios";
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
                    Classusuarios linha = new Classusuarios();//Aponta para objeto
                    linha.ID1 = Convert.ToInt32(leia["id"]);
                    linha.Login = Convert.ToString(leia["login"]);
                    linha.Senha = Convert.ToString(leia["senha"]);
                    cadastro.Add(linha);
                }
            }
            conexao.Close();

            FRMrelatoriousuarios relatorio = new FRMrelatoriousuarios();
            relatorio.imprimir(cadastro);
            relatorio.ShowDialog();
            relatorio.Dispose();
        }

        private void excluir()
        {
            string sql = "delete from usuarios where id = '" + textBox5.Text + "'";
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
            string sql = "update  usuarios set login=@login,senha=@senha where id='" + textBox5.Text + "'";
            //enviando uma instrução em sql para a variavel com nome de sql

            MySqlConnection conexao = new MySqlConnection(cnsql);
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBox1.Text;
            comando.Parameters.Add("@senha", MySqlDbType.VarChar).Value = textBox3.Text;
          

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

      

        //criptografia MD5  
        public static class Criptografia
        {
            // Calcula MD5 saida de uma determinada string passada como parametro  
            // <parametro name="Senha">String contendo a senha que deve ser criptografada para MD5 Hash</param>  
            // retorna string com 32 caracteres com a senha criptografada  
            public static string MD5(string Senha)
            {
                try
                {
                    System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(Senha);
                    byte[] hash = md5.ComputeHash(inputBytes);//calcula a saída!  
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                    {
                        sb.Append(hash[i].ToString("X2"));
                    }
                    return sb.ToString(); // Retorna senha criptografada  
                }
                catch (Exception)
                {
                    return null; // Caso encontre erro retorna nulo  
                }
            }
        }

        //função verifica cadastro igual
        private void verificacadastroigual()
        {
            string sql = "select * from usuarios where login=@login";//envniando uma instrução em sql para o banco
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando o caminho onde está alocado o banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//enviando o caminho e a instrução em sql para o banco
            comando.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBox1.Text;

            conexao.Open();//abrindo conexão

            MySqlDataReader leia = comando.ExecuteReader();//enviando uma variavel que irá realizar uma leitura dos dados

            if (leia.HasRows)//encontrou alguma coisa?
            {
                MessageBox.Show("login já existe: " + textBox1.Text + ", Por favor, Verifique o login", "Ajuda do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();//limpando
            }


            conexao.Close();
        }



        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void FRMconsultausuarios_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            consultar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
     
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                verificacadastroigual();//chamando a função verifica cadastro igual
            }
        }

        private void FRMconsultausuarios_MouseMove(object sender, MouseEventArgs e)
        {
            if (textBox5.Text == "")
            {
                verificacadastroigual();//chamando a função verifica cadastro igual
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            imprimir();
        }
    }
}
