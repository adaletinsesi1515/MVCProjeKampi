using System.Collections.Generic;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IImageFileService
    {
        ImageFile GetById(int id);
        List<ImageFile> GetList();
        void ImageFileAddBL(ImageFile imageFile);
        void ImageFileDelBl(ImageFile imageFile);
        void ImageFileUpdate(ImageFile imageFile);
    }
}