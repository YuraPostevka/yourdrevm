using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL.Managers.NotificationServiceManager;

namespace BAL.Interfaces
{
    public interface INotificationServiceManager
    {
        void SendNotification(Notify item);
    }
}
