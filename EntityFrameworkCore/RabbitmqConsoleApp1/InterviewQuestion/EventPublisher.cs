using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningConsoleApp.InterviewQuestion
{
    public delegate void EventHandler(object sender, EventArgs e);
    public class EventPublisher

    {

        public event EventHandler SomethingHappened;

        public void DoSomething()

        {

            // ... do something

            OnSomethingHappened();

        }

        protected virtual void OnSomethingHappened()

        {

            SomethingHappened?.Invoke(this, EventArgs.Empty);

        }

    }
}
