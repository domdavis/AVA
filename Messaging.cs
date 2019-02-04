using System.Collections.Generic;
using System.Threading.Tasks;

namespace AVA
{
    interface IModule { }

    interface IMonitor<T> : IModule
    { 
        void Handle(T e);
    }

    class Dispatchable<T>
    {
        public void Dispatch(T e) { Dispatcher<T>.Instance.Dispatch(e); }
    }

    class Dispatcher<T>
    {
        public static Dispatcher<T> Instance = new Dispatcher<T>();

        private List<IMonitor<T>> handlers = new List<IMonitor<T>> { };

        public void Add(IMonitor<T> handler) { Task.Run(() => { lock (handlers) handlers.Add(handler); }); }
        public void Remove(IMonitor<T> handler) { Task.Run(() => { lock (handlers) handlers.Remove(handler); }); }

        public void Dispatch(T e)
        {
            Task.Run(() => { lock (handlers) foreach (IMonitor<T> handler in handlers) handler.Handle(e); });
        }
    }
}
