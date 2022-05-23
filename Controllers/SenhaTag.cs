using System;
using System.Linq;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class SenhaTagController
    {
        public static SenhaTag IncluirSenhaTag(
            int SenhaId,
            int TagId
        )
        {
            SenhaController.GetSenha(SenhaId);
            TagController.GetTag(TagId);
            
            return new SenhaTag(SenhaId, TagId);
        }

        public static SenhaTag RemoverSenhaTag(
            int Id
        )
        {
            SenhaTag senhaTag = GetSenhaTag(Id);
            SenhaTag.RemoverSenhaTag(senhaTag);
            return senhaTag;
        }

        public static SenhaTag GetSenhaTag(
            int Id
        )
        {
            return SenhaTag.GetSenhaTag(Id);

        }public static IEnumerable<SenhaTag> VisualizarSenhaTag()
        {
            return SenhaTag.GetSenhaTags();
        }

        public static SenhaTag GetById(int Id)
        {
            SenhaTag senhaTag = SenhaTag.GetById(Id);

            return senhaTag;
        }
    }
}