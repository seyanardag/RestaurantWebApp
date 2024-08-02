﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal  = aboutDal;
        }
        public void TAdd(About entity)
        {
            _aboutDal.Add(entity);
        }

		public void TchangeSelectedAbout(int id)
		{
			_aboutDal.changeSelectedAbout(id);
		}

		public void TDelete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public List<About> TGetAll()
        {
            return _aboutDal.GetAll();
        }

        public About TGetById(int id)
        {
            return _aboutDal.GetById(id);   
        }

		public void TmakeAllAboutIsselectedFalse()
		{
			_aboutDal.makeAllAboutIsselectedFalse();
		}

		public void TUpdate(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
