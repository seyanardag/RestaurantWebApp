using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal //IAboutDal dan miras alma sebebi:sadece About a özgü metod olursa.
    {
        public EfAboutDal(signalRContext signalRContext) : base(signalRContext)
        {

        }

		public void changeSelectedAbout(int id)
		{
			using var context = new signalRContext();

            foreach (var item in context.Abouts)
            {
                if(item.AboutId == id)
                {
                    item.isSelected = true;
                }else
                {
                    item.isSelected = false;
                }
            }
            context.SaveChanges();

        }

		public void makeAllAboutIsselectedFalse()
		{
			using var context = new signalRContext();

            foreach (var item in context.Abouts)
            {
                if(item.isSelected)
                {
                    item.isSelected = false;
                }
            }
            context.SaveChanges();

		}
	}
}
