using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using ORM;

namespace DAL.Concrete
{
    public class LikeRepository : ILikeRepository
    {
        private readonly DbContext _context;

        public LikeRepository(DbContext uow)
        {
            _context = uow;
        }

        public IEnumerable<DalLike> GetAll()
        {
            return _context.Set<Like>().Select(like => new DalLike()
            {
                Id = like.Id,
                ImageId = like.ImageId,
                UserId = like.UserId
            });
        }

        public DalLike GetById(int key)
        {
            throw new NotImplementedException();
        }

        public void Create(DalLike e)
        {
            var like = new Like()
            {
                ImageId = e.ImageId,
                UserId = e.UserId
            };
            _context.Set<Like>().Add(like);
        }
    }
}
