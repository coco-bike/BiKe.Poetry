using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiKe.Poetry.Event
{
    public class TestEvent : ICapSubscribe
    {
        [CapSubscribe("now")]
        public void ReceiveMessage(DateTime dateTime)
        {

        }
    }
}
