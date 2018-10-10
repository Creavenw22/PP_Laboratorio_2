using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    #region Enumerado
    public enum ETipo
    {
        Tecnico,
        Escolar,
        Finanzas
    }
    #endregion

    public class Manual : Libro
    {
        #region Atributos
        public ETipo tipo;
        #endregion

        #region Metodos
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine((string)this);
            sb.AppendFormat("Manual de: {0}\n", this.tipo);

            return sb.ToString();
        }
        #endregion

        #region Constructor
        public Manual(string titulo, float precio, string nombre, string apellido, ETipo tipo) : base(precio, titulo, nombre, apellido)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Operadores//reutilizar codigo in operators bool
        public static bool operator ==(Manual m1, Manual m2)
        {
            bool flag = false;

            if (m1._autor == m2._autor && m1._titulo == m2._titulo)
            {
                flag = true;
            }

            return flag;
        }

        public static bool operator !=(Manual m1, Manual m2)
        {
            return !(m1 == m2);
        }

        public static implicit operator double(Manual man)
        {
            return ((double)man._precio);
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
