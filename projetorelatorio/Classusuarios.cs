using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projetorelatorio
{
    public class ListaUsuarios : List<Classusuarios> { } //lista
    public class Classusuarios //objeto
    {
        int ID = 0;

        public int ID1
        {
            get { return ID; }
            set { ID = value; }
        }
        string login = "";

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        string senha = "";

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
    }
}
