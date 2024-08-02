﻿using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
		int GetCategoryCount();
		int GetActiveCategoryCount();
		int GetPassiveCategoryCount();
		List<KeyValuePair<string, int>> GetCategoryProductCounts();
	}
}