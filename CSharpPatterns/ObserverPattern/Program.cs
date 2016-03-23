using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteSubject s = new ConcreteSubject();

            s.Attach(new ConcreteObserver(s, "X"));
            s.Attach(new ConcreteObserver(s, "Y"));
            s.Attach(new ConcreteObserver(s, "Z"));

            s.SubjectState = "ABC";
            s.Notify();

            Console.ReadKey();
        }
    }

    /// <summary>
    ///  The 'Subject' abstract class
    /// </summary>
    abstract class Subject
    {
        private List<Observer> _observer = new List<Observer>();

        public void Attach(Observer observer)
        {
            _observer.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observer.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer o in _observer)
            {
                o.Update();
            }
        }
    }

    class ConcreteSubject : Subject
    {
        private string _subjectState;

        // Gets or sets subject state
        public string SubjectState
        {
            get { return _subjectState;  }
            set { _subjectState = value; }
        }
    }

    /// <summary>
    /// The Observer abstract class
    /// </summary>
    abstract class Observer
    {
        public abstract void Update();
    }

    class ConcreteObserver : Observer
    {
        private string _name;
        private string _observerState;
        private ConcreteSubject _subject;


        // Constructor
        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            this._subject = subject;
            this._name = name;
        }

        public override void Update()
        {
            _observerState = _subject.SubjectState;
            Console.WriteLine("Observer {0}'s new state is {1}", _name, _observerState);
        }

        // gets or sets subject
        public ConcreteSubject Subject
        {
            get { return _subject;  }
            set { _subject = value; }
        }
    }
}