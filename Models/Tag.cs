using System.Collections.Generic;
using System.Linq;
using Repository;
using System;
using lib;

namespace Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<Tag> SenhaTag { get; set; }

        public Tag() { }

        public Tag(
            string Descricao
        )
        {
            this.Descricao = Descricao;

            Context db = new Context();
            db.Tags.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"{this.Id} - {this.Descricao}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Tag.ReferenceEquals(this, obj))
            {
                return false;
            }
            Tag it = (Tag) obj;
            return it.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static Tag AlterarTag(
            int Id,
            string Descricao
        )
        {
            Tag tag = GetTag(Id);
            tag.Descricao = Descricao;

            Context db = new Context();
            db.Tags.Update(tag);
            db.SaveChanges();

            return tag;
        }


        public static IEnumerable<Tag> GetTags()
        {
            Context db = new Context();
            return (from Tag in db.Tags select Tag);
        }

        public static Tag GetTag(int Id)
        {
            try
            {
                Tag tag = (
                    from Tag in Tag.GetTags()
                        where Tag.Id == Id
                        select Tag
                ).First();
                if (tag == null)
                {
                    ErrorMessage.Show("Tag não encontrada");
                }

                return tag;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public static void RemoverTag(Tag tag)
        {
            Context db = new Context();
            db.Tags.Remove(tag);
            db.SaveChanges();
        }
    }
}