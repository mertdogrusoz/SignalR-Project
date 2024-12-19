using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        void IGenericService<Slider>.TAdd(Slider entity)
        {
            throw new NotImplementedException();
        }

        void IGenericService<Slider>.TDelete(Slider entity)
        {
            throw new NotImplementedException();
        }

        Slider IGenericService<Slider>.TGetById(int id)
        {
            throw new NotImplementedException();
        }

        List<Slider> IGenericService<Slider>.TGetListAll()
        {
           return _sliderDal.GetListAll();
        }

        void IGenericService<Slider>.TUpdate(Slider entity)
        {
            throw new NotImplementedException();
        }
    }
}
