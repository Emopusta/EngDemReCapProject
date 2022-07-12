using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult AddImage(CarImage carImage);
        IResult UpdateImage(CarImage carImage);
        IResult DeleteImage(CarImage carImage);

        IDataResult<List<CarImage>> GetImagesByCarId(int carId);
        IDataResult<List<CarImage>> GetAll();
    }
}
