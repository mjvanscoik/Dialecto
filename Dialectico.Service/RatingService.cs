using Dialectico.Data;
using Dialectico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialectico.Service
{
    public class RatingService
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public IEnumerable<RatingListItem> GetAllRatings()
        {
            var ratingEntities = _db.Ratings.ToList();

            var ratingList = ratingEntities.Select(r => new RatingListItem
            {
                IndividualRating = r.IndividualRating,
                Comment = r.Comment,
            });
            return ratingList;
        }

        public IEnumerable<RatingListItem> GetRatingsById(int id)
        {
            var ratingEntities = _db.Ratings.ToList();

            var ratingList = ratingEntities.Where(r => r.Meaning.MeaningId == id).Select(m => new RatingListItem
            {
                IndividualRating = m.IndividualRating,
                Comment = m.Comment,
            });

            return ratingList;
        }

        public RatingListItem GetRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Single(r => r.RatingId == id);

                return new RatingListItem
                {
                    IndividualRating = entity.IndividualRating,
                    Comment = entity.Comment,
                    Meaning = entity.Meaning,
                };
            }
        }

        public bool CreateRating(int id, RatingCreate rating)
        {
            var serviceMeaning = new MeaningService();
            var meaning = serviceMeaning.GetMeaningById(id);

            using (var ctx = new ApplicationDbContext())
            {
                var entity = new Rating()
                {
                    MeaningId = meaning.MeaningId,
                    Comment = rating.Comment,
                    IndividualRating = rating.IndividualRating,
                    
                };
                ctx.Ratings.Add(entity);
                //meaning.RatingsList.Add(entity);

                return ctx.SaveChanges() == 1;
            }    
        }

        public bool UpdateRating(RatingListItem model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Single(e => e.RatingId == model.RatingId);

                entity.Meaning = model.Meaning;
                entity.RatingId = model.RatingId;
                entity.IndividualRating = model.IndividualRating;
                entity.Comment = model.Comment;
                entity.MeaningId = model.Meaning.MeaningId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRating(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Single(e => e.RatingId == id);

                ctx.Ratings.Remove(entity);

                return ctx.SaveChanges() == 1;

            }
        }
    }
}
