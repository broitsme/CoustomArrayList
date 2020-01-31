using System;
using System.Collections;

namespace ArrayListNS
{
    /// <summary>
    /// Using LinkedList to imlepment ArrayList
    /// </summary>
    public class CoustomArrayList : IEnumerable
    {
     

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ArrayListEnum(this);

        }

        //public ArrayListEnum GetEnumerator()
        //{
        //    return new ArrayListEnum(this);
        //}
        private int size; //number of elements in arraylist
        private Node _startRef; //root of Node
        private Node _endRef; //end of arraylist

        /// <summary>
        /// searches for first count(index) at which data is found(count starting from 0)
        /// </summary>
        /// <param name="data"></param>
        /// <returns>-1 if data not found and count first count(index) at which data is found(count starting from 0)</returns>
        public int Search(int data)
        {
            Node temp = _startRef;
            int i = 0;
            while (temp != null)
            {
                if (temp.data == data)
                {
                    return i;
                }
                temp = temp.next;
                i++;
            }
            return -1;
        }
        /// <summary>
        /// searches for element at given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>element at given index</returns>
        public int Get(int index)
        {
            if(index >= size)
            {
                throw new NullReferenceException();
            }
            Node temp = _startRef;
            int i = 0;
            while(i < index && temp != null)
            {
                temp = temp.next;
                i++;
            }
            return temp.data;
        }
        /// <summary>
        /// returns private variable size(elements in arraylist)
        /// </summary>
        /// <returns>size of array list</returns>
        
        public int GetSize()
        {
            return this.size;
        }
        /// <summary>
        /// Constructor intitalizing values 
        /// </summary>
        public CoustomArrayList()
        {
            size = 0;
        }
        public Boolean Add(int data)
        {
            if (_startRef == null)
            {
                _startRef = new Node(data);
                _endRef = _startRef;

            }
            else
            {
                _endRef.next = new Node(data);
                _endRef = _endRef.next;
            }
            size++;

            return true;
        }
        /// <summary>
        /// Removes the last element
        /// </summary>
        /// <returns>removed element</returns>
        public int Remove()
        {

            int data;

            if (_startRef == null)
            {
                throw new NullReferenceException();
            }
            Node temp = _startRef;
            while (temp.next.next != null)
            {
                temp = temp.next;
            }
            data = temp.next.data;
            _endRef = temp;
            temp.next = null;
            return data;
        }
        /// <summary>
        /// Prints the array list
        /// </summary>
        public void Print()
        {
            Node temp = _startRef;
            Console.Write("ArrayList : ");
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Sorts the Node and updates strating and end reference
        /// </summary>
        public void Sort()
        { 
            _startRef =  mergeSort(this._startRef);
            Node temp = _startRef;
            while(temp.next != null)
            {
                temp = temp.next;
            }
            _endRef = temp;
        }

        /// <summary>
        /// to delete an element on a given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns> deleted elemnent</returns>
        public int DeleteAtIndex(int index)
        {
            if(index >= size)
            {
                throw new NullReferenceException();
            }
            if(index == 0)
            {
                int DeletedData = _startRef.data;
                _startRef = _startRef.next;
                return DeletedData;
            }
            if(index == size - 1)
            {
                return Remove();
            }
            //index for traversel
            int data;
            int i = 0;
            Node temp = _startRef;
            while (i < index && temp.next.next.next != null)
            {
                temp = temp.next;
                i++;
            }
            data = temp.next.data;
            temp.next = temp.next.next;
            return data;
        } 
        /*****************************************************************For Sorting****************************************/
        /// <summary>
        /// to sort Node 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private Node mergeSort(Node root)
        { 
            if (root == null || root.next == null)
            {
                return root;
            }

            // get the middle of the list 
            Node middle = getMiddle(root);
            Node nextofmiddle = middle.next;

            // set the next of middle node to null 
            middle.next = null;

            // Apply mergeSort on left list 
            Node left = mergeSort(root);

            // Apply mergeSort on right list 
            Node right = mergeSort(nextofmiddle);

            // Merge the left and right lists 
            Node sortedlist = sortedMerge(left, right);
            return sortedlist;
        }
        /// <summary>
        /// reutrns mid reference of the Node
        /// </summary>
        /// <param name="root"></param>
        /// <returns>reutrns mid reference of the Node</returns>
        private Node getMiddle(Node root)
        {
            // Base case 
            if (root == null)
                return root;
            Node fastptr = root.next;
            Node slowptr = root;

            // Move fastptr by two and slow ptr by one 
            // Finally slowptr will point to middle node 
            while (fastptr != null)
            {
                fastptr = fastptr.next;
                if (fastptr != null)
                {
                    slowptr = slowptr.next;
                    fastptr = fastptr.next;
                }
            }
            return slowptr;
        }
        private Node sortedMerge(Node a, Node b)
        {
            Node result = null;
            //Base cases 
            if (a == null)
                return b;
            if (b == null)
                return a;

            //Pick either a or b, and recur
            if (a.data <= b.data)
            {
                result = a;
                result.next = sortedMerge(a.next, b);
            }
            else
            {
                result = b;
                result.next = sortedMerge(a, b.next);
            }
            return result;
        }

 
        /*****************************************************************For Sorting****************************************/
    }

    // Collection of Person objects. This class
    // implements IEnumerable so that it can be used
    // with ForEach syntax.
 


    public class ArrayListEnum : IEnumerator
    {
        public CoustomArrayList list;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public ArrayListEnum(CoustomArrayList list)
        {
            this.list = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < list.GetSize());
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public int Current
        {
            //time complexity is too much
            get
            {
                try
                {
                    return list.Get(position);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}