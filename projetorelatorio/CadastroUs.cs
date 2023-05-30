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
    public partial class CadastroUs : Form
    {
        string cnsql = "";
        public CadastroUs(string cn)
        {
            cnsql = cn;
            InitializeComponent();
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
                button1_Click(null, null);

               
            }
            else
            {
                MessageBox.Show("Erro!");
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


        private void CadastroUs_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            inserir();
        }
    }
}
