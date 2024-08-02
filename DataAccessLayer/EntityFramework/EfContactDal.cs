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
	public class EfContactDal : GenericRepository<Contact>, IContactDal
    {
        public EfContactDal(signalRContext signalRContext) : base(signalRContext)
        {
        }

		public void ChangeSelectedContact(int id)
		{
			using var context = new signalRContext();
            foreach (var item in context.Contacts)
            {
                if(item.isSelected)
				{
					item.isSelected = false;
				}
            }
						
			var contact = context.Contacts.FirstOrDefault(x=>x.ContactId == id).isSelected = true;
			context.SaveChanges();
		}

		public void MakeAllContactIsselectedFalse()
		{
			using (var context = new signalRContext())
			{
				foreach (var item in context.Contacts)
				{
					if (item.isSelected)
					{
						item.isSelected = false;
					}
				}
				context.SaveChanges();
			}
		}
	}
}
