using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Exceptions.Subscriptions
{
    public class SubscribtionNotFound : Exception
    {
        public SubscribtionNotFound() : base("Bu kullanıcının aboneliği bulunmamaktadır.")
        {

        }
    }
}
