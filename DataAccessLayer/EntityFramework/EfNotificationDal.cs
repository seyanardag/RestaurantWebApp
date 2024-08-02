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
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(signalRContext signalRContext) : base(signalRContext)
        {
        }

        public List<Notification> GetUnReadNotifications()
        {
            using var context = new signalRContext();
            return context.Notifications.Where(x=>x.IsRead == false).ToList();
        }
    }
}
