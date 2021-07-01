using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);
        List<Message> GetAllRead();
        Message GetByID(int id);
        void MessageAdd(Message message);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
