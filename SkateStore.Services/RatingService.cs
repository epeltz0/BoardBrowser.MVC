﻿using SkateStore.Data;
using SkateStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateStore.Services
{
    public class RatingService
    {
        private readonly Guid _userId;

        public RatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRating(RatingCreate model)
        {
            var entity =
                new Ratings()
                {
                    UserId = _userId,


                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RatingListItem> GetRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ratings
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new RatingListItem
                                {

                                }
                        );

                return query.ToArray();
            }
        }


        public RatingDetail GetRatingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.RatingId == id && e.UserId == _userId);
                return
                    new RatingDetail
                    {

                    };
            }
        }


        public bool UpdateRating(RatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.RatingId == model.RatingId && e.UserId == _userId);




                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRating(int ratingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ratings
                        .Single(e => e.RatingId == ratingId && e.UserId == _userId);

                ctx.Ratings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
