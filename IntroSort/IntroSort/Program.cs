using System;

namespace IntroSort
{
    class Program
    {
        
        static void Main(string[] args)
        {

            int[] arr = RandomNumber(17);
            int start = 0;
            int end = arr.Length - 1;

            Console.WriteLine("Array Before Sorting");
            PrintArray(arr);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Array After Sorting..");
            
            IntroSort(arr, start, end);

            PrintArray(arr);
            Console.ReadKey();
        }

        public static void PrintArray(int[] arr)
        {
            foreach (int item in arr)
            {
                Console.Write(item + ",");
            }
        }

        /// <summary>
        /// Generates and return an array with Random Values 
        /// </summary>
        public static int[] RandomNumber(int n)
        {
            int[] a = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
                a[i] = rand.Next(-10, n * 2); 
            return a;
        }

        /// <summary>
        /// Sort an array using IntroSort and depthLimit
        /// </summary>

        public static void IntroSort(int[] arr, int begin, int end)
        {
            int depthLimit = (int)(2 * Math.Log(arr.Length, 2)); 
            Instrospective(arr, begin, end, depthLimit);
        }

        /// <summary>
        /// Utility Function for introSort
        /// </summary>

        public static void Instrospective(int[] arr,int begin, int end,int depthLimit)
        {
            int size = arr.Length;
            // size is less than 16 elements
            if(size < 16)
            {
                InsertionSort(arr);
                return;
            }

            // if depth limit is zero
            if(depthLimit == 0)
            {
                
                HeapSort(arr, size);
                return;
            }

            // choose pivot and run Quick Sort
            int partitionValue = Partition(arr, 0, arr.Length - 1);
            Instrospective(arr, begin, partitionValue - 1, depthLimit - 1);
            Instrospective(arr, partitionValue + 1, end, depthLimit - 1);

        }

        /// <summary>
        /// Sorts an array using Quick Sort  
        /// </summary>
        
        public void QuickSort(int[] arr,int low,int high)
        {
            if(low < high)
            {
                int pIndex = Partition(arr, low, high);
                QuickSort(arr, low, pIndex - 1);
                QuickSort(arr, pIndex + 1, high);
            }
        }
        
        /// <summary>
        /// Calculates the partition value from the array 
        /// </summary>
        
        public static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high]; // set pivot as last value of the array
            int pIndex = low - 1; 
            int temp; 

            for (int i = low; i <= high - 1; i++){
                if (arr[i] <= pivot)
                { 
                    pIndex++;
                    temp = arr[pIndex]; 
                    arr[pIndex] = arr[i];
                    arr[i] = temp;
                }
            }
            
            temp = arr[pIndex + 1];
            arr[pIndex + 1] = arr[high];
            arr[high] = temp;
            return pIndex + 1;
        }

        /// <summary>
        /// Sorts an array by comparing previous value with the next value 
        /// </summary>

        public static void InsertionSort(int[] arr)
        {
            int j; int temp;

            for (int i = 0; i < arr.Length; i++)
            {
                j = i; // current index 
                while (j > 0) // until last element not reached
                {
                    if (arr[j - 1] > arr[j])
                    {
                        temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                    j--;
                }
            }
        }




        /// <summary>
        /// Sorts an array using binary heap
        /// </summary>

        public static void HeapSort(int[] arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                // find the max heap from the array
                MaxHeap(arr, n, i);
            }

            int temp;
            for (int i = n - 1; i >= 0; i--)
            {
                // swap max value to last index
                temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                // again find max heap from the sub tree 
                MaxHeap(arr, i, 0);
            }

        }

        /// <summary>
        ///  Builds the binary heap and calculates the maximum node 
        /// </summary>
        
        public static void MaxHeap(int[] arr, int size, int index)
        {
            int largest = index; 
            int left = (2 * index) + 1;
            int right = (2 * index);

            // if left child is greater then largest value
            if (left < size && arr[left] > arr[largest])
                largest = left; // set largest to left

            // if the right child is greater then largest value
            if (right < size && arr[right] > arr[largest])
                largest = right; // set largest to right

            // if largest is not the root 
            if (largest != index)
            {
                
                int temp = arr[index];
                arr[index] = arr[largest];
                arr[largest] = temp;
                // find max heap again from the heap
                MaxHeap(arr, size, largest);
            }
            
        }

    }
}
