
using System.Collections;

namespace Collection
{
    class ClassIEnumerator : IEnumerator
    {
        private object[] objects;
        private int index = -1;
        public ClassIEnumerator(object[] objects)
        {
            this.objects = objects;
        }

        public object Current => objects[index]; 

        public bool MoveNext()
        { 
            return index < objects.Length; 
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
