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
        public bool CreateRoot(RootCreate model)
        {
            var entity = new Root()
            {
                RootName = model.RootName,
                NotesOnRoot = model.NotesOnRoot,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Roots.Add(entity);
                return ctx.SaveChanges() == 1;

            }
        }


    }
}
