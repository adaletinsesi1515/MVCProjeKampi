using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }


        public ImageFile GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ImageFile> GetList()
        {
            return _imageFileDal.List();
        }

        public void ImageFileAddBL(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }

        public void ImageFileDelBl(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }

        public void ImageFileUpdate(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }
    }
}
