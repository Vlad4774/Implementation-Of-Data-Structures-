
using System.Drawing;

namespace Collection
{
    class sortedIntArray : IntArray
    {
        public void Sort()
        {
            for (int interval = Count / 2; interval > 0; interval /= 2)
            {
                for (int i = interval; i < Count; i++)
                {
                    var currentKey = numbers[i];
                    var k = i;
                    while (k >= interval && numbers[k - interval] > currentKey)
                    {
                        numbers[k] = numbers[k - interval];
                        k -= interval;
                    }
                    numbers[k] = currentKey;
                }
            }
        }
    }
}
