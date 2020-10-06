using Dialectico.Data;
using Dialectico.Models;
using Microsoft.Scripting.Runtime;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialectico.Service
{
    public class MeaningService
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public IEnumerable<MeaningListItem> GetAllMeanings()
        {
            var meaningEntities = _db.Meanings.ToList();
            
            var meaningList = meaningEntities.Select(m => new MeaningListItem
            {
                MeaningId = m.MeaningId,
                WordName = m.WordName,
                Pronunciation = m.Pronunciation,
                Context = m.Context,
                Description = m.Description,
                RegionalDialect = m.RegionalDialect,
            });
            return meaningList;
        }

        public IEnumerable<MeaningListItem> GetMeaningsById(int id)
        {
            var meaningEntities = _db.Meanings.ToList();
            var meaningList = meaningEntities.Where(m => m.Word.WordId == id).Select(m => new MeaningListItem
            {
                WordName = m.WordName,
                Context = m.Context,
                Description = m.Description,
                RegionalDialect = m.RegionalDialect,
                //UserRating = m.UserRating,
                //RegionalDialect = (Models.Dialect)m.RegionalDialect,
            });
            return meaningList; 
        }

        public MeaningListItem GetMeaningById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Meanings
                        .Single(e => e.MeaningId == id);
                return
                    new MeaningListItem
                    {
                        MeaningId = entity.MeaningId,
                        WordName = entity.WordName,
                        Pronunciation = entity.Pronunciation,
                        Context = entity.Context,
                        Description = entity.Description,
                        RegionalDialect = entity.RegionalDialect,
                        DialectList = entity.DialectList
                    };
            }

        }

        public bool CreateMeaning(WordDetail word, MeaningCreate model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity = new Meaning()
                {
                    WordName = word.WordName,//

                    WordId = ctx.Words.Where(e => e.WordName == word.WordName).Select(e => e.WordId).FirstOrDefault(),
                    Pronunciation = model.Pronunciation,
                    Context = model.Context,
                    Description = model.Description,
                    RegionalDialect = (Data.Dialect)model.RegionalDialect,
                    //UserRating = model.UserRating,
                    //Rating = model.Rating,
                    //RatingId = model.RatingId
                };
                ctx.Meanings.Add(entity);
                
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateMeaning(MeaningListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Meanings
                        .Single(e => e.MeaningId == model.MeaningId);

                entity.MeaningId = model.MeaningId;
                entity.WordName = model.WordName;
                entity.Context = model.Context;
                entity.Description = model.Description;
                entity.RegionalDialect = model.RegionalDialect;
                entity.DialectList = model.DialectList;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMeaning(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Meanings.Single(e => e.MeaningId == id);

                ctx.Meanings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
