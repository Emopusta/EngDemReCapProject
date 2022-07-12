using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        public int DefaultImageId { get; private set; }
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult AddImage(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageCountLimitExceeded(carImage.CarId)
                );
            if (result == null)
            {
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult();
            }
            return result;
        }

        public IResult DeleteImage(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {   
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarImageExists(carId));
            if (result != null)
            {
                return GetDefaultCarImage(carId); // return new ErrorDataResult<List<CarImage>>(GetDefaultCarImage(carId).Data);
            }
            
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci => ci.CarId == carId));
            
        }

        public IResult UpdateImage(CarImage carImage)
        {
            throw new NotImplementedException();
        }


        private IResult CheckIfCarImageCountLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarCountOfImageError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarImageExists(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        // no need for sure
        //private IResult UpdateDefaultCarImage()
        //{
        //    _carImageDal.Update(new CarImage
        //    {
        //        CarId = DefaultCarImageProperties.DefaultCarId,
        //        Id = DefaultCarImageProperties.DefaultId,
        //        ImagePath = DefaultCarImageProperties.DefaultImagePath,
        //        Date = DefaultCarImageProperties.DefaultImageChangeDate
        //    });
        //    return new SuccessResult();
        //}
        private IDataResult<List<CarImage>> GetDefaultCarImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();
            carImages.Add(new CarImage
            {
                Id = DefaultCarImageProperties.DefaultId,
                CarId = carId,
                Date = DateTime.Now,
                ImagePath = DefaultCarImageProperties.DefaultImagePath
            });
            return new SuccessDataResult<List<CarImage>>(carImages);
        }

    }
}
