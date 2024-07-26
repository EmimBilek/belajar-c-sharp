using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarEvent3_ObserverDesignPattern
{
    public abstract class Observer : IObserver<ExternalVisitor>
    {
        IDisposable _cancellation;
        protected List<ExternalVisitor> _externalVisitors = new List<ExternalVisitor>();
        public abstract void OnCompleted();

        public abstract void OnError(Exception error);

        public abstract void OnNext(ExternalVisitor value);

        public void Subscribe(IObservable<ExternalVisitor> observable)
        {
            _cancellation = observable.Subscribe(this);
        }

        public void Unsubscribe()
        {
            _cancellation.Dispose();
            _externalVisitors.Clear();
        }
    
    }
}
