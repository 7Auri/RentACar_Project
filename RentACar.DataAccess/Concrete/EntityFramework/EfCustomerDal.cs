﻿using RentACar.Core.DataAccess.EntityFramework;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarDbContext>, ICustomerDal
    {
    }
}
