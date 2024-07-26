using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarEvent3_ObserverDesignPattern
{

    public class SecuritySurveillanceHub : IObservable<ExternalVisitor>
    {
        private List<ExternalVisitor> _externalVisitors;
        private List<IObserver<ExternalVisitor>> _observers;

        public SecuritySurveillanceHub()
        {
            _externalVisitors = new List<ExternalVisitor>();
            _observers = new List<IObserver<ExternalVisitor>>();
        }

        public IDisposable Subscribe(IObserver<ExternalVisitor> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            foreach (var externalVisitor in _externalVisitors)
                observer.OnNext(externalVisitor);

            return new UnSubscriber<ExternalVisitor>(_observers, observer);
        }

        public void ConfirmExternalVisitorEntersBuilding(int id, string firstName, string lastName, string jobTitle, string companyName, DateTime entryDtm, int empContactId)
        {
            ExternalVisitor externalVisitor = new ExternalVisitor
            {
                id = id,
                firstName = firstName,
                lastName = lastName,
                jobTitle = jobTitle,
                companyName = companyName,
                entryDateTime = entryDtm,
                employeeContactId = empContactId,
                inBuilding = true
            };
            _externalVisitors.Add(externalVisitor);

            foreach (var observer in _observers)
                observer.OnNext(externalVisitor);
        }

        public void ConfirmExternalVisitorExitBuilding(int externalVisitorId, DateTime exitDtm)
        {
            var externalVisitor = _externalVisitors.FirstOrDefault(e => e.id == externalVisitorId);
            if (externalVisitor != null)
            {
                externalVisitor.exitDateTime = exitDtm;
                externalVisitor.inBuilding = false;

                foreach (var observer in _observers)
                    observer.OnNext(externalVisitor);
            }
        }

        public void BuildingEntryCutOffTimeReached()
        {
            if (_externalVisitors.Where(e => e.inBuilding).ToList().Count == 0)
            {
                foreach (var observer in _observers)
                    observer.OnCompleted();
            }
        }
    }
}
