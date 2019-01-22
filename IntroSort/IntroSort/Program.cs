using System;

namespace IntroSort
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] a = RandomNumber(18);
            Console.WriteLine("Before Sorting");
            PrintArray(a);

            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("After Sorting..");
            IntroSort(a);
            
            PrintArray(a);
       
            Console.ReadKey();
        }

        public static void PrintArray(int[] arr)
        {
            foreach (int item in arr)
            {
                Console.Write(item + ",");
            }
        }

        public static int[] RandomNumber(int n)
        {
            int[] a = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
                a[i] = rand.Next(-1, n); // generate random number from -1 to value of n
            return a;
        }


        public static void IntroSort(int[] arr)
        {
            int size = arr.Length;
            int n = arr.Length - 1;

            // if size of an array is less than 16
            if (size < 16)
            {
                Console.WriteLine("Insertion Sort");
                InsertionSort(arr); // sort using insertion sort
            } else if (size > (2 * Math.Log(arr.Length,2))) { // if size is less than 2 * log2(size)
                Console.WriteLine("HEAP SORT : {0}", (2 * Math.Log(arr.Length, 2)));
                HeapSort(arr, size); // sort using heap sort 
            } else if (size >  16 && size < (2 * Math.Log(arr.Length, 2))) { // if size is greater than 16 but less than the 2*log2(arr.lenght)
                Console.WriteLine("Quick Sort");
                QuickSort(arr, 0, n); // sort using quick sort 
            }
        }



        public static void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                // return pindex 
                int pIndex = Partition(array, low, high);
                QuickSort(array, low, pIndex - 1); // quick sort the left of the pivot 
                QuickSort(array, pIndex + 1, high); // quick sort the right of the pivot
            }
        }

        public static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high]; // set pivot as last value of the array
            int pIndex = low - 1; // pindex to -1
            int temp; 

            for (int i = low; i <= high - 1; i++){
                if (arr[i] <= pivot){ // if current value is equal or less than pivot selected 
                    pIndex++;
                    temp = arr[pIndex]; // swap 
                    arr[pIndex] = arr[i];
                    arr[i] = temp;
                }
            }

            // swap again 
            temp = arr[pIndex + 1];
            arr[pIndex + 1] = arr[high];
            arr[high] = temp;
            return pIndex + 1;
        }


        public static void InsertionSort(int[] arr)
        {
            int j; int temp;

            for (int i = 0; i < arr.Length; i++)
            {
                j = i; // current index 
                while (j > 0) // until last element not reached
                {
                    // if last element is larger than next element
                    if (arr[j - 1] > arr[j])
                    {
                        // swap
                       temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                    j--; // decrement value of j
                }
            }
        }

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
                // swap max value to first index
                temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                // again find max heap from the binary heap
                MaxHeap(arr, i, 0);
            }

        }

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

            // if largest is not on the first node
            if (largest != index)
            {
                // swap
                int temp = arr[index];
                arr[index] = arr[largest];
                arr[largest] = temp;
                // find max heap again from the heap
                MaxHeap(arr, size, largest);
            }
            
        }

    }
}
