using SkateStore.Data;
using SkateStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateStore.Services
{
    public class BoardService
    {
        private readonly Guid _userId;

        public BoardService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateBoard(BoardCreate model)
        {
            var entity =
                new Boards()
                {
                   
                    TypeOfBoard = model.TypeOfBoard,
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Boards.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BoardListItem> GetBoards()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Boards
                        .Select(
                            e =>
                                new BoardListItem
                                {
                                    BoardId = e.BoardId,
                                    TypeOfBoard = e.TypeOfBoard,
                                    Name = e.Name,
                                    Description = e.Description,
                                    Price = e.Price,
                                }
                        );

                return query.ToArray();
            }
        }


        public BoardDetail GetBoardById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Boards
                        .Single(e => e.BoardId == id);
                return
                    new BoardDetail
                    {
                        BoardId = entity.BoardId,
                        TypeOfBoard = entity.TypeOfBoard,
                        Name = entity.Name,
                        Description = entity.Description,
                        Price = entity.Price,
                    };
            }
        }

        public bool UpdateBoard(BoardEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Boards
                        .Single(e => e.BoardId == model.BoardId);

                


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBoard(int boardId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Boards
                        .Single(e => e.BoardId == boardId);

                ctx.Boards.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
