using System.Collections.Generic;
using UnityEngine;

namespace Coffee.Pattern.Observer
{
    public class Subject : MonoBehaviour
    {
        private readonly List<IObserver> _observers = new();

        public void AddObserver(IObserver observer) => _observers.Add(observer);
        public void RemoveObserver(IObserver observer) => _observers.Remove(observer);
        protected void NotifyObserver()
        {
            _observers.ForEach(observer => {
                observer.OnNotify();
            });
        }
    }
}
