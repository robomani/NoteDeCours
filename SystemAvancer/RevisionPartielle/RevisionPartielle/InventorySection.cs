using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionPartielle
{
    // Classe generique dont le type générique ne peut être qu'une classe qui hérite de InventoryItem
    class InventorySection < T > where T : InventoryItem
    {
        List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }
    }
}
