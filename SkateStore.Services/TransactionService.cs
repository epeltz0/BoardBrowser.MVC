using SkateStore.Data;
using SkateStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkateStore.Services
{
    public class TransactionService
    {
        private readonly Guid _userId;

        public TransactionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTransaction(TransactionCreate model)
        {
            var entity =
                new Transactions()
                {
                    
                    BoardId = model.BoardId

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TransactionListItem> GetTransaction()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Transactions
                        .Select(
                            e =>
                                new TransactionListItem
                                {
                                    BoardId = e.BoardId,
                                }
                        );

                return query.ToArray();
            }
        }


        public TransactionDetail GetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionId == id);
                return
                    new TransactionDetail
                    {
                        BoardId = entity.BoardId
                    };
            }
        }


        public bool UpdateTransaction(TransactionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionId == model.TransactionId);




                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransaction(int transactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionId == transactionId);

                ctx.Transactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

