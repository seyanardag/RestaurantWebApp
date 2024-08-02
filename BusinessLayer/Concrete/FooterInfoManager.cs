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
    public class FooterInfoManager : IFooterInfoService
    {
        private readonly IFooterInfoDal _footerInfoDal;

        public FooterInfoManager(IFooterInfoDal footerInfoDal)
        {
            _footerInfoDal = footerInfoDal;
        }

        public void TAdd(FooterInfo entity)
        {
            _footerInfoDal.Add(entity);
        }

        public void TDelete(FooterInfo entity)
        {
            _footerInfoDal.Delete(entity);
        }

        public List<FooterInfo> TGetAll()
        {
            return _footerInfoDal.GetAll();
        }

        public FooterInfo TGetById(int id)
        {
            return _footerInfoDal.GetById(id);  
        }

        public void TUpdate(FooterInfo entity)
        {
            _footerInfoDal.Update(entity);
        }
    }
}
