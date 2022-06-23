using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Models;

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
            ValidateInsert(Nome, Email, Senha);

            return new Usuario(Nome, Email, BCrypt.Net.BCrypt.HashPassword(Senha));
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

            if(!String.IsNullOrEmpty(Senha) && !BCrypt.Net.BCrypt.Equals(Senha, usuario.Senha))
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
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

        public static void ValidateInsert(string Nome, string Email, string Senha)
        {
            if(String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome do usuário não pode ser vazio.");
            }

            if(String.IsNullOrEmpty(Email))
            {
                throw new Exception("Email do usuário não pode ser vazio.");
            }

            Regex rx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if(!rx.IsMatch(Email))
            {
                throw new Exception("Email inválido.");
            }

            if(String.IsNullOrEmpty(Senha))
            {   
                throw new Exception("Senha não pode ser vazio.");
            }

            int minChar = 8;
            bool invalidPass = Senha.Length < minChar;
            if (invalidPass)
            {
                throw new Exception("A senha deve possuir no mínimo 8 caracteres.");
            }        
        }
    }
}