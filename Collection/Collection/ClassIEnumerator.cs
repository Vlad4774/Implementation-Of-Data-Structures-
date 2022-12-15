
using System.Collections;

namespace Collection
{
    class ClassIEnumerator : IEnumerator
    {
        private object[] objects;
        private int index = -1;
        private int count;
        public ClassIEnumerator(object[] objects, int count)
        {
            this.objects = objects;
            this.count = count;
        }

        public object Current => objects[index];

        public bool MoveNext()
        {
            index++;
            return index < count;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
