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
            SenhaTag senhaTag = (
                from SenhaTag in SenhaTag.GetSenhaTags()
                    where SenhaTag.Id == Id
                    select SenhaTag
            ).First();

            if(senhaTag == null)
            {
                throw new Exception("Senha Tag não encontrada");
            }

            return senhaTag;

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