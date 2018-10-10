using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro
    {
        #region Atributos
        protected Autor _autor;
        protected int _cantDePaginas;
        protected Random _generadorDePaginas;
        protected float _precio;
        protected string _titulo;
        #endregion

        #region Properties
        public int Paginas
        {
            get
            {
                _generadorDePaginas = new Random();
                _generadorDePaginas.Next(10, 580);
                return this._cantDePaginas;
            }
        }
        #endregion

        #region Metodos
        private static string Mostrar(Libro lib)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Titulo: {0}\nAutor: {1}\nCantidad de Paginas: {2}\nPrecio: {3}",lib._titulo,lib._autor,lib._cantDePaginas,lib._precio);

            return sb.ToString();
        }
        #endregion

        #region Constructor
        protected  Libro()
        {
            this._cantDePaginas = Paginas;
        }

        public Libro(float precio, string titulo,string nombre,string apellido) : this()
        {
            Autor escritor = new Autor(nombre, apellido);
            this._precio = precio;
            this._titulo = titulo;
            this._autor = escritor;
        }

        public Libro(float precio, string titulo, Autor escritor) :this()
        {
            this._precio = precio;
            this._titulo = titulo;
            this._autor = escritor;
        }
        #endregion //constructor static incomplete

        #region Operadores
        public static bool operator ==(Libro lib1, Libro lib2)
        {
            bool flag = false;

            if (lib1._titulo == lib2._titulo && lib1._autor == lib2._autor)
            {
                flag = true;
            }

            return flag;
        }

        public static bool operator !=(Libro lib1, Libro lib2)
        {
            return !(lib1 == lib2);
        }

        public static explicit operator string(Libro lib)
        {
            return Mostrar(lib);
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
        #endregion
    }
}
