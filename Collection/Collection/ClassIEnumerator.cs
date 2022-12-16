
using System.Collections;

namespace Collection
{
    class ClassIEnumerator : IEnumerator
    {
        private ObjectArray objects;
        private int index = -1;
        public ClassIEnumerator(ObjectArray objects)
        {
            this.objects = objects;
        }

        public object Current => objects[index];

        public bool MoveNext()
        {
            int count = objects.Count;
            index++;
            return index < count;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
