using System;
using System.Collections.Generic;
using System.Linq;
using Repository;
using lib;

namespace Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Categoria() { }

        public Categoria(
            string Nome,
            string Descricao
        )
        {
            this.Nome = Nome;
            this.Descricao = Descricao;

            Context db = new Context();
            db.Categorias.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"{this.Id} - {this.Nome}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Categoria.ReferenceEquals(this, obj))
            {
                return false;
            }
            Categoria it = (Categoria) obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static Categoria AlterarCategoria(
            int Id,
            string Nome,
            string Descricao
        )
        {
            Categoria categoria = GetCategoria(Id);
            categoria.Nome = Nome;
            categoria.Descricao = Descricao;

            Context db = new Context();
            db.Categorias.Update(categoria);
            db.SaveChanges();

            return categoria;
        }


        public static IEnumerable<Categoria> GetCategorias()
        {
            Context db = new Context();
            return from Categoria in db.Categorias select Categoria;
        }

        public static Categoria GetCategoria(
            int Id
        )
        {
            try
            {
                Categoria categoria = (
                    from Categoria in Categoria.GetCategorias()
                        where Categoria.Id == Id
                        select Categoria
                ).First();
                if (categoria == null)
                {
                    ErrorMessage.Show("Categoria não encontrada");
                }

                return categoria;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public static void RemoverCategoria(Categoria categoria)
        {
            Context db = new Context();
            db.Categorias.Remove(categoria);
            db.SaveChanges();
        }
    }
}