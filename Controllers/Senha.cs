using System;
using System.Linq;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class SenhaController
    {
        public static Senha IncluirSenha(
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario,
            string SenhaEncrypt,
            string Procedimento
        )
        {
            if(String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome inválido");
            }
            if(String.IsNullOrEmpty(Url))
            {
                throw new Exception("Url inválido");
            }
            if(String.IsNullOrEmpty(Usuario))
            {
                throw new Exception("Usuário inválido");
            }
            if(String.IsNullOrEmpty(SenhaEncrypt))
            {
                throw new Exception("Senha inválida");
            }
            if(String.IsNullOrEmpty(Procedimento))
            {
                throw new Exception("Procedimento inválido");
            }

            return new Senha(Nome, CategoriaId, Url, Usuario, SenhaEncrypt, Procedimento);
        }

        public static Senha AlterarSenha(
            int Id,
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario,
            string SenhaEncrypt,
            string Procedimento
        )
        {
            Senha senha = GetSenha(Id);
            Categoria categoria = CategoriaController.GetCategoria(CategoriaId);

            if(String.IsNullOrEmpty(Nome))
            {
                Nome = senha.Nome;
            }
            if(String.IsNullOrEmpty(categoria.Nome.ToString()))
            {
                categoria.Nome = senha.Categoria.Nome;
            }
            if(String.IsNullOrEmpty(Url))
            {
                Url = senha.Url;
            }
            if(String.IsNullOrEmpty(Usuario))
            {
                Usuario = senha.Usuario;
            }
            if(String.IsNullOrEmpty(SenhaEncrypt))
            {
                SenhaEncrypt = senha.SenhaEncrypt;
            }
            if(String.IsNullOrEmpty(Procedimento))
            {
                Procedimento = senha.Procedimento;
            }

            Senha.AlterarSenha(
                Id,
                Nome,
                categoria.Id,
                Url,
                Usuario,
                SenhaEncrypt,
                Procedimento
            );

            return senha;
        }

        public static Senha RemoverSenha(
            int Id
        )
        {
            Senha senha = GetSenha(Id);
            Senha.RemoverSenha(senha);
            return senha;
        }

        public static Senha GetSenha(
            int Id
        )
        {
            return Senha.GetSenha(Id);
        }

        public static IEnumerable<Senha> VisualizarSenha()
        {
            return Senha.GetSenhas();
        }
    }
}