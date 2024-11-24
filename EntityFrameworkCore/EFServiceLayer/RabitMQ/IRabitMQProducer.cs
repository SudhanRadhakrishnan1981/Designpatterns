using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFServiceLayer.RabitMQ
{
    public interface IRabitMQProducer
    {
        Task SendProductMessage<T>(T message);
    }
}
