﻿using DataAccessLayer.Abstract;
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
    public class EfFooterInfoDal : GenericRepository<FooterInfo>,IFooterInfoDal
    {
        public EfFooterInfoDal(signalRContext signalRContext) : base(signalRContext)
        {
        }
    }
}
