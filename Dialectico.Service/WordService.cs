using Dialectico.Data;
using Dialectico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace Dialectico.Service
{
    public class WordService
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private ModelStateDictionary _modelState = new ModelStateDictionary();
        //Get all for display
        public IEnumerable<WordListItem> GetWords()
        {
            var wordEntities = _db.Words.ToList();
            var wordList = wordEntities.Select(r => new WordListItem
            {
                WordId = r.WordId,
                Notes = r.Notes,
                WordName = r.WordName,
                RootName = r.RootName,
                RootId = r.RootId,
            });
            return wordList;
        }

        public WordDetail GetWordById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Words
                        .Single(e => e.WordId == id);

                var list = new List<MeaningListItem>();

                foreach (var item in entity.Meanings)
                {//Converting meanings into meaninglistitems
                    var conversion = new MeaningListItem
                    {
                        MeaningId = item.MeaningId,
                        WordName = item.WordName,
                        Pronunciation = item.Pronunciation,
                        Context = item.Context,
                        Description = item.Description,
                        RegionalDialect = item.RegionalDialect,
                        DialectList = item.DialectList
                    };
                    list.Add(conversion);
                }

                return
                    new WordDetail
                    {
                        WordId = entity.WordId,
                        Notes = entity.Notes,
                        WordName = entity.WordName,
                        RootName = entity.RootName,
                        Meanings = list,
                    };
            }
        }

        //Create
        public bool CreateWord(WordCreate model)
        {
            try
            {
                var rId = _db.Roots.Single(e => e.RootName == model.RootName);
                using (var ctx = new ApplicationDbContext())
                {
                    if (rId != null)
                    {

                        var entity = new Word()
                        {
                            WordName = model.WordName,
                            RootName = model.RootName,
                            Notes = model.Notes,
                            RootId = rId.Id
                        };

                        ctx.Words.Add(entity);
                        return ctx.SaveChanges() == 1;
                    }

                    else
                    {
                        _modelState.AddModelError("NoRoot", "No Root Exists");
                        return ctx.SaveChanges() == 0;
                    }
                }
            }
            catch (Exception e)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    if (RootIsInDb(model) == false)
                    {
                        var root = new Root()
                        {
                            RootName = model.RootName,
                            NotesOnRoot = "This root was created without notes. Please consider adding some."
                        };
                        ctx.Roots.Add(root);


                        var rootId = _db.Roots.Where(r => r.RootName == model.RootName).Select(r => r.Id).FirstOrDefault();

                        var entity = new Word
                        {
                            WordName = model.WordName,
                            RootName = model.RootName,
                            Notes = model.Notes,
                            RootId = rootId
                        };

                        ctx.Words.Add(entity);
                        return ctx.SaveChanges() == 2;
                    }
                    throw;
                }
            }
        }

        public bool UpdateWord(WordListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Words
                        .Single(e => e.WordId == model.WordId);

                entity.RootName = model.RootName;
                entity.WordName = model.WordName;
                entity.Notes = model.Notes;
                entity.RootId = ctx.Roots.Where(e => e.RootName == entity.RootName).Select(e => e.Id).FirstOrDefault();


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteWord(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Words.Single(e => e.WordId == id);

                ctx.Words.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool RootIsInDb(WordCreate model)
        {
            var doesExist = _db.Roots.Where(e => e.RootName == model.RootName).Any();
            if (doesExist is true)
                return true;
            return false;
        }
    }
}

