using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    #region Enumerado
    public enum EGenero
    {
        Accion,
        Romantica,
        CienciaFiccion
    }
    #endregion

    public class Novela : Libro
    {
        #region Atributos
        public EGenero genero;
        #endregion

        #region Metodos
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine((string)this);
            sb.AppendFormat("Novela de: {0}\n", this.genero);

            return sb.ToString();
        }
        #endregion

        #region Constructor
        public Novela(string titulo, float precio,Autor escritor,EGenero genero) : base(precio,titulo,escritor)
        {
            this.genero = genero;
        }
        #endregion

        #region Operadores//reutilizar codigo in operators bool
        public static bool operator ==(Novela n1, Novela n2)
        {
            bool flag = false;

            if (n1._autor == n2._autor && n1._titulo == n2._titulo)
            {
                flag = true;
            }

            return flag;
        }

        public static bool operator !=(Novela n1, Novela n2)
        {
            return !(n1 == n2);
        }

        public static implicit operator double(Novela nov)
        {
            return ((double)nov._precio);
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
            return this.Mostrar();
        }
        #endregion
    }
}
