using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace Zadanie1
{
    [DataContract()]
    [Serializable]
    public class DataContext
    {
        [DataMember()]
        public List<BookReader> bookReader;

        [DataMember()]
        public Dictionary<string, Book> books;

        [DataMember()]
        public ObservableCollection<Event> events;

        [DataMember()]
        public List<BookState> bookStates;

        public DataContext()
        {
            bookReader = new List<BookReader>();
            books = new Dictionary<string, Book>();
            events = new ObservableCollection<Event>();
            bookStates = new List<BookState>();

            // initialize event handlers for ObservableCollection
            events.CollectionChanged += (sender, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    Console.WriteLine("Wypożyczono książkę");
                    foreach (Event ev in e.NewItems)
                    {
                        Console.WriteLine(ev);
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    Console.WriteLine("Anulowano wypożyczenie");
                    foreach (Event ev in e.OldItems)
                    {
                        Console.WriteLine(ev);
                    }
                }
            };
        }
    }
}
