using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    #region Enumerado
    public enum ELibro
    {
        Manual,
        Novela,
        Ambos
    }
    #endregion

    public class Biblioteca
    {
        #region Atributos
        private int _capacidad;
        private List<Libro> _libros;
        #endregion

        #region Properties//Los get son diferentes para ver cual funciona y cual no
        public double PrecioDeManuales
        {
            get
            {
                double precios = 0;

                foreach (Libro item in this._libros)
                {
                    if (item is Manual)
                    {
                        precios += (Manual)item;
                    }
                }

                return precios;
            }
        }

        public double PrecioDeNovelas
        {
            get
            {
                double precios = 0;

                foreach (Libro item in this._libros)
                {
                    if (item is Novela)
                    {
                        precios += (Novela)item;
                    }
                }

                return precios;
            }
        }

        public double PrecioTotal
        {
            get
            {
                double precios = 0;

                precios += PrecioDeManuales;
                precios += PrecioDeNovelas;

                return precios;
            }
        }
        #endregion

        #region Metodos
        private double ObtenerPrecio(ELibro tipoLibro)
        {
            double precio = 0;

            if (tipoLibro == ELibro.Manual)
            {
                precio = this.PrecioDeManuales;
            }

            else if (tipoLibro == ELibro.Novela)
            {
                precio = this.PrecioDeNovelas;
            }

            else
            {
                precio = this.PrecioTotal;
            }

            return precio;
        }

        public static string Mostrar(Biblioteca estante)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Capacidad de la biblioteca: {0}\n",estante._capacidad);
            sb.AppendFormat("Total por manuales: {0}\n", estante.ObtenerPrecio(ELibro.Manual));
            sb.AppendFormat("Total por Novelas: {0}\n", estante.ObtenerPrecio(ELibro.Novela));
            sb.AppendFormat("Total por todo: {0}\n", estante.ObtenerPrecio(ELibro.Ambos));

            sb.AppendLine("************************\nListado de libros\n************************");

            foreach (Libro item in estante._libros)
            {
                if (item is Manual)
                {
                    sb.AppendLine((string)item);
                }

                if (item is Novela)
                {
                    sb.AppendLine((string)item);
                }
            }

            return sb.ToString();
        }
        #endregion

        #region Constructores
        private Biblioteca()
        {
            this._libros = new List<Libro>();
        }

        private Biblioteca(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }
        #endregion

        #region Operadores
        public static implicit operator Biblioteca(int capacidad)
        {
            return new Biblioteca(capacidad);
        }

        public static bool operator ==(Biblioteca estante, Libro lib)
        {
            bool retorno = false;
            foreach (Libro item in estante._libros)
            {
                if (item == lib)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Biblioteca estante, Libro lib)
        {
            return !(estante == lib);
        }

        public static Biblioteca operator +(Biblioteca estante, Libro lib)
        {
            if (estante._capacidad > estante._libros.Count)
            {
                if (estante != lib)
                {
                    estante._libros.Add(lib);
                    Console.WriteLine("El libro ya esta en la biblioteca!!!");
                }
            }

            else
            {
                Console.WriteLine("No hay mas lugar en la biblioteca");
            }

            return estante;
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
