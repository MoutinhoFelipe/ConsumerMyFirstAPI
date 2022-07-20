using ConsumerMyFirstAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerMyFirstAPI.Controller
{
    class ConsumerController
    {
        public TripRepository TripRepository { get; set; }
        public QueueService QueueService { get; set; }
        public string IdTripConsumed { get; set; }
        public ConsumerController(string qname)
        {
            this.QueueService = new QueueService(qname);
        }

        public void SelectDriverById()
        {
            this.IdTripConsumed = QueueService.ConsumeQueue();
        }
    }
}
