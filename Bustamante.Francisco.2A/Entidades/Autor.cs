using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Autor
    {
        #region Atributos
        private string _nombre;
        private string _apellido;
        #endregion

        #region Constructor
        public Autor(string nombre, string apellido)
        {
            this._nombre = nombre;
            this._apellido = apellido;
        }
        #endregion

        #region Operadores
        public static bool operator ==(Autor a1, Autor a2)
        {
            bool flag=false;

            if (a1._nombre == a2._nombre && a1._apellido == a2._apellido)
            {
                flag = true;
            }

            return flag;
        }

        public static bool operator !=(Autor a1, Autor a2)
        {
            return !(a1 == a2);
        }

        public static implicit operator string(Autor escritor)
        {
            return string.Format("{0} {1}", escritor._nombre, escritor._apellido);
        }
        #endregion

        #region Sobrecargas//not functional
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this._nombre, this._apellido);
        }
        #endregion

    }
}
