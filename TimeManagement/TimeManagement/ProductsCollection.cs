using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagement
{
    class ProductsCollection : ObservableCollection<Product>
    {
        public void CopyFrom(IEnumerable<Product> products)
        {
            Items.Clear();
            foreach (var p in products)
            {
                Items.Add(p);
            }
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
