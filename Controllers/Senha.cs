using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
            Validates(Nome, Url, Usuario, SenhaEncrypt);

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

            Validates(Nome, Url, Usuario, SenhaEncrypt);

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

        public static void Validates(string Nome, string Url, string Usuario, string SenhaEncrypt)
        {
            if(String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome não pode ser vazio.");
            }
            if(String.IsNullOrEmpty(Url))
            {
                throw new Exception("Url não pode ser vazio.");
            }
            Regex rx = new Regex(@"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$");
            if(!rx.IsMatch(Url))
            {
                throw new Exception("Url inválido.");
            }
            if(String.IsNullOrEmpty(Usuario))
            {
                throw new Exception("Usuário não pode ser vazio.");
            }
            if(String.IsNullOrEmpty(SenhaEncrypt))
            {
                throw new Exception("Senha não pode ser vazio.");
            }
        }
    }
}