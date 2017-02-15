using BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using System.IO;

namespace BAL.Managers
{
    public class NotificationServiceManager : BaseManager, INotificationServiceManager
    {
        public NotificationServiceManager(IUnitOfWork uOW) : base(uOW)
        {
        }

        public class Notify
        {
            public string UserEmail { get; set; }
            public string ListName { get; set; }
            public string ItemName { get; set; }
            public DateTime? Date { get; set; }
        }

        public void GetNotifyItem()
        {
            var notifyItems = uOW.ToDoItemRepo.All.Where(n => n.IsNotify == true);
            foreach (var item in notifyItems)
            {
                var notifyItem = new Notify()
                {
                    UserEmail = item.ToDoList.User.Email,
                    ListName = item.ToDoList.Name,
                    ItemName = item.Text,
                    Date = item.NotifyTime
                };

                if (notifyItem.Date == DateTime.UtcNow)
                {
                    SendNotification(notifyItem);
                }

            }
        }

        public void SendNotification(Notify item)
        {

        }



        public static void WriteErrorLog(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.UtcNow.ToString() + ": " + ex.Source.ToString().Trim() + "; " + ex.Message.ToString().Trim());
                sw.Flush();
                sw.Close();
            }
            catch
            {

            }
        }
        public static void WriteErrorLog(string message)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogFile.txt", true);
                sw.WriteLine(DateTime.UtcNow.ToString() + ": " + message);
                sw.Flush();
                sw.Close();
            }
            catch
            {

            }
        }
    }
}
