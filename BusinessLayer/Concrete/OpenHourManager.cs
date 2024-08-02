using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OpenHourManager : IOpenHourService
    {
        private readonly IOpenHourDal _openHourDal;

        public OpenHourManager(IOpenHourDal openHourDal)
        {
            _openHourDal = openHourDal;
        }

        public void TAdd(OpenHour entity)
        {
            _openHourDal.Add(entity);
        }

        public void TDelete(OpenHour entity)
        {
            _openHourDal.Delete(entity);
        }

        public List<OpenHour> TGetAll()
        {
           return _openHourDal.GetAll();
        }

        public OpenHour TGetById(int id)
        {
            return _openHourDal.GetById(id);
        }

        public void TUpdate(OpenHour entity)
        {
            _openHourDal.Update(entity);
        }
    }
}
