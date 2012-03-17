using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ASDlib
{
    #region Interfacce
    interface IPriorityQueue
    {
        bool insert(int i);
        int findMin();
        int extractMin();
    }
    interface IGraphSearch
    {
        void depthFirst();
        void breadthFirst(int s);
    }
    interface ICandidate
    {
        string nome { get; }
        string cognome { get; }
        string matricola { get; }
    }
    #endregion

    #region Data Structure of Graph
    public struct Nodo
    {
        public int id;
        public int x, y;
        public Nodo(int p1, int p2, int p3) { id = p1; x = p2; y = p3; }
    }
    public struct Arco
    {
        public int id;
        public int end1;
        public int end2;
        public int w;
        public Arco(int p1, int p2, int p3, int p4)
        {
            id = p1; end1 = p2; end2 = p3; w = p4;
        }
    }
    #endregion

    public class Ordinamenti : ICandidate
    {
        public string nome
        {
            get { return "Andrea"; }
        }
        public string cognome
        {
            get { return "Mazzotti"; }
        }
        public string matricola
        {
            get { return "0000######"; }
        }

        #region insertionSort

        //Insertion sort for integers
        public void insertionSort(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                int key = A[i];
                int j = i - 1;
                while (j >= 0 && A[j] > key)
                {
                    A[j + 1] = A[j];
                    j = j - 1;
                }
                A[j + 1] = key;
            }
        }

        //Insertion sort for doubles
        public void insertionSort(double[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                double key = A[i];
                int j = i - 1;
                while (j >= 0 && A[j] > key)
                {
                    A[j + 1] = A[j];
                    j = j - 1;
                }
                A[j + 1] = key;
            }
        }

		/*  The insertionSort with strigs is not the best of ecciciency.
            Probabli because of .CompareTo. Override the operator > would be better,
            but it is strongly not recommended by the Microsoft documentation. */
        //Insertion sort for strings
        public void insertionSort(string[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                string key = A[i];
                int j = i - 1;
                while (j >= 0 && (A[j].CompareTo(key) > 0))
                {
                    A[j + 1] = A[j];
                    j = j - 1;
                }
                A[j + 1] = key;
            }
        }
        #endregion

        #region quickSort
        //Partition for quickSort(int[])
        int partition(int[] A, int p, int q)
        {
            int i = p + 1;
            int j = q;
            int key;
            while (i <= j)
            {
                while (A[j] > A[p])
                {
                    j = j - 1;
                }
                while ((i <= j) && (A[i] <= A[p]))
                {
                    i = i + 1;
                }
                if (i < j)
                {
                    key = A[i];
                    A[i] = A[j];
                    A[j] = key;
                }
            }
            key = A[p];
            A[p] = A[j];
            A[j] = key;
            return j;
        }
        
        /*  quickSort launches quickSort with overloading of two integers, p and q */
        public void quickSort(int[] A)
        {
            int p = 0;
            int q = A.Length - 1;
            quickSort(A, p, q);
        }

        //quickSort with overloading 
        public void quickSort(int[] A, int p, int q)
        {
            int l;
            l = partition(A, p, q);
            if ((l - p) < (q - 1))
            {
                if (p < (l - 1))
                    quickSort(A, p, l - 1);
                if ((l + 1) < q)
                    quickSort(A, l + 1, q);
            }
            else
            {
                if ((l + 1) < q)
                    quickSort(A, l + 1, q);
                if (p < (l - 1))
                    quickSort(A, p, l - 1);
            }
        }

        //Partition for quickSort(double[])
        int partition(double[] A, int p, int q)
        {
            int i = p + 1;
            int j = q;
            double key;
            while (i <= j)
            {
                while (A[j] > A[p])
                {
                    j = j - 1;
                }
                while ((i <= j) && (A[i] <= A[p]))
                {
                    i = i + 1;
                }
                if (i < j)
                {
                    key = A[i];
                    A[i] = A[j];
                    A[j] = key;
                }
            }
            key = A[p];
            A[p] = A[j];
            A[j] = key;
            return j;
        }

        public void quickSort(double[] A)
        {
            int p = 0;
            int q = A.Length - 1;
            quickSort(A, p, q);
        }

        public void quickSort(double[] A, int p, int q)
        {
            int l;
            l = partition(A, p, q);
            if ((l - p) < (q - 1))
            {
                if (p < (l - 1))
                    quickSort(A, p, l - 1);
                if ((l + 1) < q)
                    quickSort(A, l + 1, q);
            }
            else
            {
                if ((l + 1) < q)
                    quickSort(A, l + 1, q);
                if (p < (l - 1))
                    quickSort(A, p, l - 1);
            }
        }

        //Partition for quickSort(string[])
        int partition(string[] A, int p, int q)
        {
            int i = p + 1;
            int j = q;
            string key;
            while (i <= j)
            {
                while (A[j].CompareTo(A[p])>0)
                {
                    j = j - 1;
                }
                while ((i <= j) && (A[i].CompareTo(A[p])<=0))
                {
                    i = i + 1;
                }
                if (i < j)
                {
                    key = A[i];
                    A[i] = A[j];
                    A[j] = key;
                }
            }
            key = A[p];
            A[p] = A[j];
            A[j] = key;
            return j;
        }

        public void quickSort(string[] A)
        {
            int p = 0;
            int q = A.Length - 1;
            quickSort(A, p, q);
        }

        public void quickSort(string[] A, int p, int q)
        {
            int l;
            l = partition(A, p, q);
            if ((l - p) < (q - 1))
            {
                if (p < (l - 1))
                    quickSort(A, p, l - 1);
                if ((l + 1) < q)
                    quickSort(A, l + 1, q);
            }
            else
            {
                if ((l + 1) < q)
                    quickSort(A, l + 1, q);
                if (p < (l - 1))
                    quickSort(A, p, l - 1);
            }
        }
        #endregion

        #region countingSort
        //Counting sort. 
        public void countingSort(int[] A,out int[] B)
        {
            int max = A[0];
            int min = A[0];
            B = new int[A.Length];
            int i,k;
            for (i = 0; i < A.Length; i++)
            {
                if (A[i] > max)
                    max = A[i];
                else if (A[i] < min)
                    min = A[i];
            }
            int[] C = new int[max - min + 1];
            for (i = 0; i < C.Length; i++)
            {
                C[i] = 0;
            }
            for (i = 0; i < A.Length; i++)
            {
                C[A[i] - min] = C[A[i] - min] + 1;
            }
            k = 0;
            for (i = 0; i < C.Length; i++)
            {
                while (C[i] > 0)
                {
                    B[k] = i + min;
                    k = k + 1;
                    C[i] = C[i] - 1;
                }
            }
        }
        #endregion
    }

    public class MyHeap
    {
        private int[] heapInt;
        private double[] heapDouble;
        private string[] heapString;
        /*  The constructor initializes the vectors of size 0.
            The functions for inserting and removing bother to do any resizing. */
        public MyHeap()
        {
            heapInt = new int[0];
            heapDouble = new double[0];
            heapString = new string[0];
        }
        public int[] HeapInt
        {
            get { return heapInt; }
        }

        public double[] HeapDouble
        {
            get { return heapDouble; }
        }

        public string[] HeapString
        {
            get { return heapString; }
        }

        
		/*	Because of overloading, I included the variables "swap", "sift" and "heapify"
            that depending on the use are integer, double, or string.
            It would have been more elegant to do it in another way, but I found out later and
            i think that the "dirty" solution is an acceptable compromise,
            considering the short time spent to implement it and a negligible resource consumption.
			I decided to implement siftDown instead of siftUp, due to a less computational cost(n compared to nlogn).
            The performance is still poor, because I wanted to do a rebuild the heap at each entry
            and each extraction, to avoid any kind of problems.
            I can optimize, but I prefer to not run any type of risk (or reduction of the score). */		

        #region Integers
        //Function Swap for siftDown(integers)
        private void Swap(int a, int b, int swap)
        {
            int temp;
            temp = heapInt[a];
            heapInt[a] = heapInt[b];
            heapInt[b] = temp;
        }

        //Function siftDown for Heapify(integers)
        private void siftDown(int start, int end, int sift)
        {
            int swap = 1;
            int root=start;
            int child;
            while((root*2+1) <= end)
            {
                child = root * 2 + 1;
                if ((child<end)&&(heapInt[child]>heapInt[child+1]))
                    child=child+1;
                if (heapInt[root] > heapInt[child])
                {
                    Swap(root, child, swap);
                    root = child;
                }
                else
                {
                    break;
                }
            }
        }

        //Function Heapify(integers)
        private void Heapify(int count, int heapify)
        {
            int sift = 1;
            int start;
            start = (count - 1) / 2;
            while (start >= 0)
            {
                siftDown(start, count - 1, sift);
                start = start - 1;
            }
        }

        public void buildHeap(int[] A)
        {
            int heapify = 1;
            heapInt = A;
            Heapify(heapInt.Length, heapify);        
        }

        public void Insert(int x)
        {
            Array.Resize(ref heapInt,heapInt.Length+1);
            heapInt[heapInt.Length - 1] = x;
            buildHeap(heapInt);
        }

        public void extractMin(out int min)
        {
            buildHeap(heapInt);
            min = heapInt[0];
            for (int i = 0; i < heapInt.Length-1; i++)
            {
                heapInt[i] = heapInt[i + 1];
            }
            Array.Resize(ref heapInt, heapInt.Length - 1);
            buildHeap(heapInt);
        }
        #endregion

        #region Doubles
        private void Swap(int a, int b, double swap)
        {
            double temp;
            temp = heapDouble[a];
            heapDouble[a] = heapDouble[b];
            heapDouble[b] = temp;
        }
        private void siftDown(int start, int end, double sift)
        {
            double swap= 1.3;
            int root = start;
            int child;
            while ((root * 2 + 1) <= end)
            {
                child = root * 2 + 1;
                if ((child < end) && (heapDouble[child] > heapDouble[child + 1]))
                    child = child + 1;
                if (heapDouble[root] > heapDouble[child])
                {
                    Swap(root, child, swap);
                    root = child;
                }
                else
                {
                    break;
                }
            }
        }
        private void Heapify(int count, double heapify)
        {
            double sift = 1.3;
            int start;
            start = (count - 1) / 2;
            while (start >= 0)
            {
                siftDown(start, count - 1, sift);
                start = start - 1;
            }
        }
        public void buildHeap(double[] A)
        {
            double heapify = 1.3;
            heapDouble = A;
            Heapify(heapDouble.Length, heapify);
        }
        public void Insert(double x)
        {
            Array.Resize(ref heapDouble, heapDouble.Length + 1);
            heapDouble[heapDouble.Length - 1] = x;
            buildHeap(heapDouble);
        }
        public void extractMin(out double min)
        {
            buildHeap(heapDouble);
            min = heapDouble[0];
            for (int i = 0; i < heapDouble.Length - 1; i++)
            {
                heapDouble[i] = heapDouble[i + 1];
            }
            Array.Resize(ref heapDouble, heapDouble.Length - 1);
            buildHeap(heapDouble);
        }
        #endregion

        #region Strings
        private void Swap(int a, int b, string swap)
        {
            string temp;
            temp = heapString[a];
            heapString[a] = heapString[b];
            heapString[b] = temp;
        }
        private void siftDown(int start, int end, string sift)
        {
            string swap = "Hello!";
            int root = start;
            int child;
            while ((root * 2 + 1) <= end)
            {
                child = root * 2 + 1;
                if ((child < end) && (heapString[child].CompareTo(heapString[child + 1]))>0)
                    child = child + 1;
                if (heapString[root].CompareTo(heapString[child])>0)
                {
                    Swap(root, child, swap);
                    root = child;
                }
                else
                {
                    break;
                }
            }
        }
        private void Heapify(int count, string heapify)
        {
            string sift = "Hello again!";
            int start;
            start = (count - 1) / 2;
            while (start >= 0)
            {
                siftDown(start, count - 1, sift);
                start = start - 1;
            }
        }
        public void buildHeap(string[] A)
        {
            string heapify = "Ok, stop this";
            heapString = A;
            Heapify(heapString.Length, heapify);
        }
        public void Insert(string x)
        {
            Array.Resize(ref heapString, heapString.Length + 1);
            heapString[heapString.Length - 1] = x;
            buildHeap(heapString);
        }
        public void extractMin(out string min)
        {
            buildHeap(heapString);
            min = heapString[0];
            for (int i = 0; i < heapString.Length - 1; i++)
            {
                heapString[i] = heapString[i + 1];
            }
            Array.Resize(ref heapString, heapString.Length - 1);
            buildHeap(heapString);
        }
        #endregion
    }

    public class MyHash
        {
            private int m;
            List<int>[] Indice;
			/* 	The constructor takes care of initializing the index of List<int>, but also of include
                in each cell an empty list. This so that the hash table is already built and the more
                "static" possible, at least in its exoskeleton. There is a higher consumption of resources, which is still
                negligible, but at least it avoids the continuous destruction and creation of lists, which would require
                additional time to the memory manager to continuously allocate and destroy. */
            public MyHash(int mcostruttore)
            {
                m = mcostruttore;
                Indice = new List<int>[m];
                for (int i = 0; i < m; i++)
                {
                    Indice[i] = new List<int> { };
                }
            }

            public int NumPos
            {
                get { return m; }
            }
            
            public List<int> showTableLine(int k)
            {
                    return Indice[hash(k)];
            }

            public void chainedHashInsert(int x)
            {
                Indice[hash(x)].Add(x);
            }

            public bool chainedHashSearch(int k)
            {
                int q = Indice[hash(k)].Count;
                for (int i = 0; i < q; i++)
                {
                    if (Indice[hash(k)][i] == k)
                    {
                        return true;
                    }
                }
                return false;
            }

            public bool chainedHashDelete(int x)
            {
                int q = Indice[hash(x)].Count;
                for (int i = 0; i < q; i++)
                {
                    if (Indice[hash(x)][i] == x)
                    {
                        Indice[hash(x)].Remove(x);
                        return true;
                    }
                }
                return false;
            }

            private int hash(int i)
            {
                return i%m;
            }
        }

    public class ArrayPQ : IPriorityQueue
    {
        private int[] array;
        //Constructor
        public ArrayPQ(int dimensione)
        {
            array = new int[dimensione];
            for (int i = 0; i < dimensione; i++)
            {
                array[i] = -1; //Initialize the vector to -1, taking as true that there will be negative priorities.
            }
        }

		/*	Function that looks for any empty cell of the vector (initialized to -1)
            and returns true if inserted, false if there are not empty cells. */
        public bool insert(int i)
        {
            for (int j = 0; j < array.Length; j++)
            {
                if (array[j] == -1)
                {
                    array[j] = i;
                    return true;
                }
            }
            return false;
        }

        //findMin() search and returns the smallest value in the unordered vector.
        public int findMin()
        {
            int temp=array.Max(); //Initialize temp to the highest value in the vector.
            if (temp != -1) //If the vector is not empty...
            {
                for (int i = 0; i < array.Length; i++) //...browse entirely.
                {
                    if ((temp > array[i]) && (array[i] != -1)) //If find a lower value, that is not -1...
                    {
                        temp = array[i]; //...assign it to temp.
                    }
                }
                return temp; //temp is now the lower number
            }
            else
            {
                return -1; //If the larger value is -1, it means that the vector is empty. Returns -1 to the joy of the compiler, since the error is not handled in the project requirements.
            }
        }

        //extractMin() extracts the lowest value in the unordered vector.
        public int extractMin()
        {
            int temp = findMin(); //temp is now the lower number
            if (temp != -1) //If the vector is not empty...
            {
                for (int i = 0; i < array.Length; i++) //...browse entirely.
                {
                    if (array[i] == temp) //If I find a value equal to temp, i already know to be the lower...
                    {
                        array[i] = -1; //... initialize it to -1
                        break; //I left the loop because I want to extract just one and not all those like its in case there are
                    }
                }
                return temp;
            }
            else
            {
                return -1; // If the larger value is -1, it means that the vector is empty. Returns -1 to the joy of the compiler, since the error is not handled in the project requirements.
            }
        }
    }
    public class HeapPQ : IPriorityQueue
    {
        private MyHeap heap = new MyHeap();
        
        //I put the value in the heap. The function heap.Insert(int i) already takes care to rebuild the heap.
        public bool insert(int i)
        {
            heap.Insert(i);
            return true;
        }

        //MyHeap reconstructs the heap every ectraction and every insert, so I'm sure that the minimum value is always the first.
        public int findMin()
        {
            return heap.HeapInt[0];
        }

        //Uses the function heap.extractMin(out int min).
        public int extractMin()
        {
            int min;
            heap.extractMin(out min);
            return min;
        }
   
    }

    public class Grafo
    {
        /*  Adjacent structure, made ​​public for any debugging.
            I need it to create the adjacency list.*/
        public struct Adiacente
        {
            public int id;  //id of adjacent node
            public int w;   //weight of the arc that connects it
            public Adiacente(int p1, int p2)
            {
                id = p1; w = p2;
            }
        }

        /*  Lista di adiacenza. L'indice del vettore di liste sarà considerato l'id del nodo relativo.
            La lista relativa ad una determinata cella, sarà quindi la lista di adiacenza di quel determinato nodo. */
		/* 	Adjacency list. The index of the vector of lists will be considered the id of the relative node.
            The list related to a particular cell, will therefore be the adjacency list of that particular node.*/
        private List<Adiacente>[] lista_adiacenza;

        /*  The list is private, I do not want anyone to access and modify it directly, but i return it to debug. */
        public List<Adiacente>[] lista
        {
            get { return lista_adiacenza; }
        }
        
		// 	Function that creates the adjacency list after reading the file, using in turn lists of nodes and edges.
        private void creaLista(int dimensione)
        {
            lista_adiacenza = new List<Adiacente>[dimensione];
            for (int j = 0; j < dimensione; j++)
            {
                lista_adiacenza[j]= new List<Adiacente>();
            }
            for (int i = 0; i < archi.Count; i++)
            {
                Adiacente temp = new Adiacente(archi[i].end2,archi[i].w);
                lista_adiacenza[archi[i].end1].Add(temp);
            }
        }

        public List<Nodo> nodi = new List<Nodo>(); //List of nodes, i save in it the informations read from the file .xml
        public List<Arco> archi = new List<Arco>();//List of strings, i save in it the informations read from the file related to the arcs

        public int numNodi, numArchi; //Public integers containing the number of nodes and the number of arcs.
        public bool isOriented; //Bool set to true if the graph is oriented.

        public void readXMLgraph(string fpath)
        {
            isOriented = false; //I assume that the graph is not oriented
            XmlTextReader reader = new XmlTextReader(fpath);
            Nodo tempnodo = new Nodo();
            Arco temparco = new Arco();
            Arco temparco2 = new Arco(); //Second temporary arc, if i meet an Edge.
            bool edge;
            while (reader.Read())
            {
                switch(reader.Name)
                {
                    case "nodo":
                        while (reader.MoveToNextAttribute())
                        {
                            switch (reader.Name)
                            {
                                case "id":
                                    tempnodo.id = Convert.ToInt32(reader.Value);
                                    break;
                                case "x":
                                    tempnodo.x = Convert.ToInt32(reader.Value);
                                    break;
                                case "y":
                                    tempnodo.y = Convert.ToInt32(reader.Value);
                                    break;
                            }
                        }
                        nodi.Add(tempnodo);
                        break;
                    case "arco":
                        edge = false; //I assume that there are no edge
                        while (reader.MoveToNextAttribute())
                        {
                            switch (reader.Name)
                            {
                                case "id":
                                    temparco.id = Convert.ToInt32(reader.Value);
                                    break;
                                case "end1":
                                    temparco.end1 = Convert.ToInt32(reader.Value);
                                    break;
                                case "end2":
                                    temparco.end2 = Convert.ToInt32(reader.Value);
                                    break;
                                case "type":
                                    switch (reader.Value)
                                    {
                                        case "Edge": //The edges are considered as two distinct and opposite arcs.
                                            edge = true;
                                            temparco2.end1 = temparco.end2;
                                            temparco2.end2 = temparco.end1;
                                            temparco2.id = temparco.id;
                                            break;
                                        case "Arc":
                                            isOriented = true; //If I meet a single arc, the graph is directed.
                                            break;
                                    }
                                    break;
                                case "w":
                                    temparco.w = Convert.ToInt32(reader.Value);
                                    if (edge)
                                        temparco2.w = temparco.w;
                                    break;
                            }
                        }
                        archi.Add(temparco);
                        if (edge) //If I come across an edge, I have to insert two arcs.
                            archi.Add(temparco2);
                        break;
                }
            }
            //After reading the entire file and save the information, I create the adjacency list.
            creaLista(nodi.Count);
            //And initialize variables
            numNodi = nodi.Count;
            numArchi = archi.Count;
            reader.Close();
        }

        #region Kruskal
        //Implemented according to the pseudocode provided in Professor Luciano Margara's handouts.
        public virtual List<int> Kruskal()
        {
            archi.Sort(comparatoreArchi); //Order the arcs according to their weight, from the "light" to the "heavier".
            List<int> ris = new List<int>();
            UpTree uptree = new UpTree(nodi.Count);
            for (int i = 0; i < nodi.Count; i++)
            {
                uptree.makeSet(nodi[i].id);
            }
            for (int j = 0; j < archi.Count; j++)
            {
                if (uptree.findSet(archi[j].end1) != uptree.findSet(archi[j].end2))
                {
                    ris.Add(archi[j].id);
                    uptree.union(archi[j].end1,archi[j].end2);
                }
            }
            return ris;
        }

        /*  Custom comparator, used by Array.sort(). */
        private int comparatoreArchi(Arco x, Arco y) 
        {
            if (x.w > y.w)
                return 1;
            else if (x.w < y.w)
                return -1;
            else
                return 0;
        }
        #endregion

        #region Dijkstra
        public virtual int[] Dijkstra(int s)
        {
            int[] d = new int[nodi.Count]; //Vector of distances..
            int[] d2 = new int[nodi.Count]; //Vector of distances over which the algorithm actually works.
            int[] p = new int[nodi.Count];  //Vector of predecessors.
            initialize(d, d2, p, s); //Initializing vectors.
            int estratto;
            int i = 0;
            while (i < nodi.Count)
            {
                estratto = extractMin(d2);
                i++;
                for (int j = 0; j < lista_adiacenza[estratto].Count; j++)
                {
                    relax(d, d2, p, estratto, lista_adiacenza[estratto][j].id, lista_adiacenza[estratto][j].w);
                }
            }
            return p;
        }

        //The vectors are initialized to -1, which conceptually means both "null" and "infinite".
        private void initialize(int[] d, int[] d2, int[] p, int s)
        {
            for (int i = 0; i < nodi.Count; i++)
            {
                d[i] = -1;
                d2[i] = -1;
                p[i] = -1;
            }
            d[s] = 0;
        }

        private void relax(int[] d, int[] d2, int[] p, int u, int v, int w)
        {
            if ((d[v] > (d[u] + w)) || (d[v]==-1))
            {
                d[v] = d[u] + w;
                d2[v] = d2[u] + w;
                p[v] = u;
            }
        }

        //Returns the node with the smallest gap and initializes it.
        private int extractMin(int[] d2)
        {
            int temp= d2.Max();
            for (int i = 0; i < d2.Length; i++)
            {
                if ((temp>d2[i])&&(d2[i]!=-1))
                    temp=d2[i];
            }
            for (int i = 0; i<d2.Length; i++)
            {
                if (d2[i]==temp)
                {
                    temp = i;
                    d2[i] = -1;
                    break;
                }
            }
            return temp;
        }
        #endregion

        #region Prim
        //Prim.
        public virtual int[] Prim(int r)
        {
            int[] d = new int[nodi.Count];
            int[] d2 = new int[nodi.Count];
            int[] p = new int[nodi.Count];
            initialize(d, d2, p, r); //Initialize is the same as Dijkstra, initializes the vectors to -1.
            int estratto;
            int i = 0;
            while (i < nodi.Count)
            {
                estratto = extractMinPrim(d2);
                i++;
                for (int j = 0; j < lista_adiacenza[estratto].Count; j++)
                {       //-2 Means that the node is already been extracted
                    if ((d2[lista_adiacenza[estratto][j].id]!=-2)&&((lista_adiacenza[estratto][j].w < d[lista_adiacenza[estratto][j].id]) || (d[lista_adiacenza[estratto][j].id] == -1)))
                    {
                        p[lista_adiacenza[estratto][j].id] = estratto;
                        d[lista_adiacenza[estratto][j].id] = lista_adiacenza[estratto][j].w;
                        d2[lista_adiacenza[estratto][j].id] = lista_adiacenza[estratto][j].w;
                    }
                }
            }
            return p;
        }

        //The function is the same as extractMin of Dijkstra, the only difference is that it uses -2 to mark the extraction, because I have to take account of the nodes actually extracts.
        private int extractMinPrim(int[] d2)
        {
            int temp = d2.Max();
            for (int i = 0; i < d2.Length; i++)
            {
                if ((temp > d2[i]) && (d2[i] != -1) && (d2[i]!=-2))
                    temp = d2[i];
            }
            for (int i = 0; i < d2.Length; i++)
            {
                if (d2[i] == temp)
                {
                    temp = i;
                    d2[i] = -2;
                    break;
                }
            }
            return temp;
        }
        #endregion

    }

    public class UpTree
    {
        //UpTree.
        int[] p;
        int[] rank;
        int dimensione;

        public UpTree(int n)
        {
            dimensione = n;
            p = new int[n];
            rank = new int[n];
        }

        public void makeSet(int x)
        {
            p[x] = x;
            rank[x] = 0;
        }

        private void Link(int x, int y)
        {
            if (rank[x] > rank[y])
                p[y] = x;
            else
            {
                p[x] = y;
                if (rank[x] == rank[y])
                    rank[y]++;
            }
        }

        public int findSet(int x)
        {
            if (x != p[x])
                p[x] = findSet(p[x]);
            return p[x];
        }


        public void union(int x, int y)
        {
            Link(findSet(x), findSet(y));
        }
    }

    public class GrafoOrientato : Grafo
    {
        public override List<int> Kruskal()
        {
            return null; //If the graph is oriented, Kruskal has no sense.
        }

        public override int[] Prim(int r)
        {
            return null; //Same for Prim.
        }

        public override int[] Dijkstra(int s)
        {
            return base.Dijkstra(s);
        }
    }

    public class GrafoNonOrientato : Grafo
    {
        public override List<int> Kruskal()
        {
            return base.Kruskal();
        }

        public override int[] Prim(int r)
        {
            return base.Prim(r);
        }

        public override int[] Dijkstra(int s)
        {
            return base.Dijkstra(s);
        }
    }

    public class GraphSearch : IGraphSearch
    {
        public enum colori { white, gray, black };
        public colori[] nodeColor;
        public int[] p;
        public int[] d;
        public int[] f;
        Grafo graph;
        private int time = 0;

        //The constructor initializes the vectors based on the number of nodes contained in "Grafo.xml"
        public GraphSearch()
        {
            graph= new Grafo();
            graph.readXMLgraph("Grafo.xml");
            int n = graph.lista.Length;
            nodeColor = new colori[n];
            p = new int[n];
            d = new int[n];
            f = new int[n];
        }

        //Research in depth
        public void depthFirst()
        {   
            //Initializing vectors
            for (int i = 0; i < graph.lista.Length; i++)
            {
                nodeColor[i] = colori.white;
                p[i] = -1;
            }
            time = 0;
            for (int i = 0; i < graph.lista.Length; i++)
            {
                if (nodeColor[i] == colori.white)
                {
                    dfsVisit(i);
                }
            }
        }

        //Visit for the DFS.
        private void dfsVisit(int u)
        {
            nodeColor[u] = colori.gray;
            time++;
            d[u] = time;
            for (int j = 0; j < graph.lista[u].Count; j++)
            {
                if (nodeColor[graph.lista[u][j].id] == colori.white)
                {
                    p[graph.lista[u][j].id] = u;
                    dfsVisit(graph.lista[u][j].id);
                }
            }
            nodeColor[u] = colori.black;
            time++;
            f[u] = time;
        }

        //Breadth-first search.
        public void breadthFirst(int s)
        {
            int u;
            List<int> Coda = new List<int>{};
            //Inizializing vectors.
            for (int i = 0; i < graph.lista.Length; i++)
            {
                nodeColor[i] = colori.white;
                d[i] = -1;
                p[i] = -1;
            }
            nodeColor[s] = colori.gray;
            d[s] = 0;
            Coda.Add(s);
            while (Coda.Count > 0) //For all the time in which the queue is not empty.
            {
                u = Coda[0];
                for (int i = 0; i < graph.lista[u].Count; i++)
                {
                    if (nodeColor[graph.lista[u][i].id] == colori.white)
                    {
                        nodeColor[graph.lista[u][i].id] = colori.gray;
                        d[graph.lista[u][i].id] = d[u] + 1;
                        p[graph.lista[u][i].id] = u;
                        Coda.Add(graph.lista[u][i].id);
                    }
                }
                Coda.RemoveAt(0);
                nodeColor[u] = colori.black;
            }
        }
    }
    
}