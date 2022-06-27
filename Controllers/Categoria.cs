using System;
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
            ValidateInsert(Nome, Descricao);

            return new Categoria(Nome, Descricao);
        }

        public static Categoria AlterarCategoria(
            int Id,
            string Nome,
            string Descricao
        )
        {
            Categoria categoria = GetCategoria(Id);

            if(String.IsNullOrEmpty(Nome))
            {
                Nome = categoria.Nome;
            }
            if(String.IsNullOrEmpty(Descricao))
            {
                Descricao = categoria.Descricao;
            }

            Categoria.AlterarCategoria(
                Id,
                Nome,
                Descricao
            );

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
            return Categoria.GetCategoria(Id);
        }

        public static IEnumerable<Categoria> VisualizarCategoria()
        {
            return Categoria.GetCategorias();
        }

        public static void ValidateInsert(string Nome, string Descricao)
        {
            if(String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome da categoria não pode ser vazio.");
            }
            if(String.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Descrição da categoria não pode ser vazia.");
            }
        }
    }
}