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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string cnsql = @"SERVER=172.16.0.123;DATABASE=escola;UID=sa;PASSWORD=123456";


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

        //criando a função de acesso ao sistema
        private void acesso()
        {
            string sql = "select * from usuarios where login=@login";
            MySqlConnection conexao = new MySqlConnection(cnsql);//enviando o caminho onde está alocado o banco
            MySqlCommand comando = new MySqlCommand(sql, conexao);//enviando o caminho e a instrução em sql para o banco
            comando.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBox1.Text;
            conexao.Open();//abrindo conexão
            MySqlDataReader leia = comando.ExecuteReader();
            if (leia.Read()) //se achou o login no banco
            {

               
                if (Convert.ToString(leia["senha"]) == Criptografia.MD5((textBox2.Text)))
                {
                    FRMprincipal form2 = new FRMprincipal(cnsql);
                    MessageBox.Show("Bem Vindo ao Sistema " + Convert.ToString(leia["login"]), "Sistema Inicial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Visible = false;//esconder o formulário
                    form2.Show();
                }
                else //se achou o login mas a senha está errada
                {
                    MessageBox.Show("Dados Inválidos!", "Ajuda do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            else //não achou o login
            {
                MessageBox.Show("Dados Inválidos!", "Ajuda do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
            }


        }
      private void niver()
{
    string sql = "SELECT * FROM usuarios WHERE EXTRACT(MONTH FROM dn) = @mes AND EXTRACT(DAY FROM dn) = @dia and login=@login";
    MySqlConnection conexao = new MySqlConnection(cnsql);
    MySqlCommand comando = new MySqlCommand(sql, conexao);
    comando.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBox1.Text;
    comando.Parameters.AddWithValue("@mes", DateTime.Today.Month);
    comando.Parameters.AddWithValue("@dia", DateTime.Today.Day);
    conexao.Open();

    MySqlDataReader leia = comando.ExecuteReader();

    while (leia.Read())
    {
        string nome = leia.GetString("login");
        MessageBox.Show("Parabéns Hoje é Seu Aniversario " + Convert.ToString(leia["login"]), "Sistema Inicial", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    conexao.Close();
}





        private void button1_Click(object sender, EventArgs e)
        {
            FRMprincipal principal = new FRMprincipal(cnsql);
            principal.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Por favor informe Login de acesso");
                textBox1.Focus();
            }
            else
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Por favor informe a senha");
                    textBox2.Focus();
                }
                else
                {
                    niver();
                    acesso();
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CadastroUs cad = new CadastroUs(cnsql);
            cad.ShowDialog();
        }
    }
}
