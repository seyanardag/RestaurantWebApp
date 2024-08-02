using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService : IGenericService<Contact>
    {
		void TChangeSelectedContact(int id);
		void TMakeAllContactIsselectedFalse();
	}
}
