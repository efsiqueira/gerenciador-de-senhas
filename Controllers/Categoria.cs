using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Models;
using lib;

namespace Controllers
{
    public class CategoriaController
    {
        public static Categoria IncluirCategoria(
            string Nome,
            string Descricao
        )
        {
            CategoriaController.ValidaInclusao(Nome, Descricao);

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

        public static void ValidaInclusao(string PrimeiroValor, string SegundoValor)
        {
            if(String.IsNullOrEmpty(PrimeiroValor))
            {
                ErrorMessage.Show("Erro!");
            }
            if(String.IsNullOrEmpty(SegundoValor))
            {
                ErrorMessage.Show("Erro!");
            }
        }
    }
}