using System;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class TagController
    {
        public static Tag IncluirTag(
            string Descricao
        )
        {
            if(String.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Descrição não pode ser vazio.");
            }

            return new Tag(Descricao);
        }

        public static Tag AlterarTag(
            int Id,
            string Descricao
        )
        {
            Tag tag = GetTag(Id);

            if(String.IsNullOrEmpty(Descricao))
            {
                Descricao = tag.Descricao;
            }

            Tag.AlterarTag(
                Id,
                Descricao
            );

            return tag;
        }

        public static Tag RemoverItem(
            int Id
        )
        {
            Tag tag = GetTag(Id);
            Tag.RemoverTag(tag);
            return tag;
        }

        public static Tag GetTag(
            int Id
        )
        {
            return Tag.GetTag(Id);
        }

        public static IEnumerable<Tag> VisualizarTag()
        {
            return Tag.GetTags();   
        }
    }
}