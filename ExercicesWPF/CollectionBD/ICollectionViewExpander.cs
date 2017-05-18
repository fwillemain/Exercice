using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColBD
{
    static public class ICollectionViewExpander
    {
        static public int GetLastIndex(this ICollectionView view)
        {
            int currentIndex = view.CurrentPosition;

            view.MoveCurrentToLast();
            int lastIndex = view.CurrentPosition;

            view.MoveCurrentToPosition(currentIndex);

            return lastIndex;
        }
    }
}
