using System;
using System.Linq;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class CategoriaController
    {
        public static Categoria IncluirCategoria(
            string Nome,
            string Descricao
        )
        {
            if(String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome inválido");
            }
            if(String.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Descrição inválida");
            }

            return new Categoria(Nome, Descricao);
        }

        public static Categoria AlterarCategoria(
            int Id,
            string Nome,
            string Descricao
        )
        {
            Categoria categoria = GetCategoria(Id);

            if(!String.IsNullOrEmpty(Nome))
            {
                Nome = Nome;
            }
            if(!String.IsNullOrEmpty(Descricao))
            {
                Descricao = Descricao;
            }

            return categoria;
        }

        public static Categoria RemoverItem(
            int Id
        )
        {
            Categoria categoria = GetCategoria(Id);
            Categoria.RemoverCategoria(categoria);
            return categoria;
        }

        public static Categoria GetCategoria(
            int Id
        )
        {
            Categoria categoria = (
                from Categoria in Categoria.GetCategorias()
                    where Categoria.Id == Id
                    select Categoria
            ).First();

            if(categoria == null)
            {
                throw new Exception("Categoria não encontrada");
            }

            return categoria;
        }

        public static IEnumerable<Categoria> VisualizarCategoria()
        {
            return Categoria.GetCategorias();
        }
    }
}