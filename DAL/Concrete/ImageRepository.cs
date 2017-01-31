using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfacies.DTO;
using DAL.Interfacies.Repository;
using ORM;

namespace DAL.Concrete
{
    public class ImageRepository : IImageRepository
    {
        private readonly DbContext _context;

        public ImageRepository(DbContext uow)
        {
            _context = uow;
        }

        public IEnumerable<DalImage> GetAll() => 
            _context.Set<Image>().Select(img => new DalImage()
            {
                Id = img.Id,
                Image = img.Picture,
                NumberOfLikes = img.NumberOfLikes,
                UserId = img.UserId
            });

        public DalImage GetById(int key)
        {
            var ormImg = _context.Set<Image>().FirstOrDefault(image => image.Id == key);
            return new DalImage()
            {
                Id = ormImg.Id,
                Image = ormImg.Picture,
                NumberOfLikes = ormImg.NumberOfLikes,
                UserId = ormImg.UserId
            };
        }

        public void Create(DalImage e)
        {
            var image = new Image()
            {
                Picture = e.Image,
                UserId = e.UserId
            };
            _context.Set<Image>().Add(image);
        }

        public void Update(int imageId)
        {
            var ormImg = _context.Set<Image>().FirstOrDefault(image => image.Id == imageId);
            ormImg.NumberOfLikes++;
            _context.SaveChanges();
        }
    }
}
