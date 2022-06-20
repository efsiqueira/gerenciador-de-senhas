using System;
using System.Linq;
using System.Collections.Generic;
using Models;
using lib;

namespace Controllers
{
    public class UsuarioController
    {
        public static Usuario IncluirUsuario(
            string Nome,
            string Email,
            string Senha
        )
        {
            UsuarioController.ValidaInclusao(Nome, Email, Senha);

            return new Usuario(Nome, Email, Senha);
        }

        public static Usuario AlterarUsuario(
            int Id,
            string Nome,
            string Email,
            string Senha
        )
        {
            Usuario usuario = GetUsuario(Id);

            if(String.IsNullOrEmpty(Nome))
            {
                Nome = usuario.Nome;
            }

            if(String.IsNullOrEmpty(Email))
            {
                Email = usuario.Email;
            }

            if(String.IsNullOrEmpty(Senha))
            {
                Senha = usuario.Senha;
            }

            Usuario.AlterarUsuario(
                Id,
                Nome,
                Email,
                Senha
            );

            return usuario;
        }

        public static Usuario RemoverUsuario(
            int Id
        )
        {
            Usuario usuario = GetUsuario(Id);
            Usuario.RemoverUsuario(usuario);
            return usuario;
        }

        public static Usuario GetUsuario(
            int Id
        )
        {
            return Usuario.GetUsuario(Id);
        }

        public static IEnumerable<Usuario> VisualizarUsuario()
        {
            return Usuario.GetUsuarios();
        }

        public static void Auth(
            string Email,
            string Senha
        )
        {
            Usuario.Auth(Email, Senha);
        }

        public static void ValidaInclusao(string Nome, string Email, string Senha)
        {
            if(String.IsNullOrEmpty(Nome))
            {
                ErrorMessage.Show("Erro!");
            }

            if(String.IsNullOrEmpty(Email))
            {
                ErrorMessage.Show("Erro!");
            }

            if(String.IsNullOrEmpty(Senha))
            {   
                ErrorMessage.Show("Erro!");
            }
        }
    }
}