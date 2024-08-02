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
	public class MoneyBoxManager : IMoneyBoxService
	{
		private readonly IMoneyBoxDal _moneyBoxDal;

		public MoneyBoxManager(IMoneyBoxDal moneyBoxDal)
		{
			_moneyBoxDal = moneyBoxDal;
		}

		public void TAdd(MoneyBox entity)
		{
			_moneyBoxDal.Add(entity);
		}

		public void TDelete(MoneyBox entity)
		{
			_moneyBoxDal.Delete(entity);
		}

		public List<MoneyBox> TGetAll()
		{
			return _moneyBoxDal.GetAll();
		}

		public MoneyBox TGetById(int id)
		{
			return _moneyBoxDal.GetById(id);
		}

		public void TUpdate(MoneyBox entity)
		{
			_moneyBoxDal.Update(entity);
		}
	}
}
