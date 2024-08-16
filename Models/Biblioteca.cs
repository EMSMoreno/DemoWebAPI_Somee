using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebAPIDemo.Models
{
    public class Biblioteca
    {
        private static List<Livro> livros;

        public static List<Livro> Livros
        {
            get
            {
                if (livros == null)
                {
                    GerarLivros();
                }

                return livros;
            }

            set { livros = value; }
        }

        private static void GerarLivros()
        {
            livros = new List<Livro>();

            livros.Add(new Livro
            {
                Id = 1,
                Titulo = "Eu e as minhas irmas",
                Autor = "Rui Mendes"
            });

            livros.Add(new Livro
            {
                Id = 2,
                Titulo = "Eu e as meus irmaos",
                Autor = "Rui Jota"
            });

            livros.Add(new Livro
            {
                Id = 3,
                Titulo = "As minhas irmas e eu",
                Autor = "Jota Rui"
            });
        }
    }
}