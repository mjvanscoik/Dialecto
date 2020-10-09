using Dialectico.Data;
using Dialectico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialectico.Service
{
    public class RootService
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public IEnumerable<RootListItem> GetRoots()
        {
            var rootEntities = _db.Roots.ToList();
            var rootList = rootEntities.Select(r => new RootListItem
            {
                Id = r.Id,
                RootName = r.RootName,
                NotesOnRoot = r.NotesOnRoot
            });
            return rootList;
        }

        public RootListItem GetRootById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Roots
                        .Single(e => e.Id == id);

                var list = new List<WordListItem>();

                foreach (var item in entity.WordsList)
                {
                    var conversion = new WordListItem
                    {
                        RootId = item.RootId,
                        RootName = item.RootName,
                        WordId = item.WordId,
                        Notes = item.Notes,
                        WordName = item.WordName,
                    };
                    list.Add(conversion);
                }
                return
                    new RootListItem
                    {
                        RootName = entity.RootName,
                        NotesOnRoot = entity.NotesOnRoot,
                        WordsList = list,
                    };
            }
        }
        public bool CreateRoot(RootCreate model)
        {
            var entity = new Root()
            {
                RootName = model.RootName,
                NotesOnRoot = model.NotesOnRoot,
            };

            using (var ctx = new ApplicationDbContext())
            {
                if (_db.Roots.Where(e => e.RootName == model.RootName).Any())
                {
                    return false;
                }
                else
                {
                    ctx.Roots.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
        }
        public bool DeleteRoot(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Roots.Single(e => e.Id == id);

                ctx.Roots.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public bool UpdateRoot(RootListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Roots
                        .Single(e => e.Id == model.Id);

                entity.RootName = model.RootName;
                entity.NotesOnRoot = model.NotesOnRoot;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
