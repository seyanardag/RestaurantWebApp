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
	public class ContactFormMessageManager : IContactFormMessageService
	{
		private readonly IContactFormMessageDal _contactFormMessageDal;

		public ContactFormMessageManager(IContactFormMessageDal contactFormMessageDal)
		{
			_contactFormMessageDal = contactFormMessageDal;
		}

		public void TAdd(ContactFormMessage entity)
		{
			_contactFormMessageDal.Add(entity);
		}

		public void TDelete(ContactFormMessage entity)
		{
			_contactFormMessageDal.Delete(entity);
		}

		public List<ContactFormMessage> TGetAll()
		{
			return _contactFormMessageDal.GetAll();
		}

		public ContactFormMessage TGetById(int id)
		{
			return _contactFormMessageDal.GetById(id);
		}

		public void TUpdate(ContactFormMessage entity)
		{
			_contactFormMessageDal.Update(entity);
		}
	}
}
