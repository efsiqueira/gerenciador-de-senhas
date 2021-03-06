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
            SenhaTag senhaTag = GetById(Id);
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

        public static IEnumerable<SenhaTag> GetBySenhaId(int Id)
        {
            return SenhaTag.GetBySenhaId(Id);
        }

        public static SenhaTag GetBySenhaTagId(int SenhaId, int TagId)
        {
            return SenhaTag.GetBySenhaTagId(SenhaId, TagId);
        }
    }
}