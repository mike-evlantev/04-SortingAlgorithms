using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading file...");
            int[] list = readFromFile();
            Console.WriteLine("File loaded.");
            Console.WriteLine("Choose a sorting algorithm:");
            Console.WriteLine();
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Insertion Sort");
            Console.WriteLine("3. Merge Sort");
            Console.WriteLine("4. Quick Sort");
            // Console.WriteLine("5. Block Sort");
            Console.WriteLine();

            string choice = Console.ReadLine();

            printList("Unsorted List", list);
            switch (choice)
            {
                case "1":
                    bubbleSort(list);
                    break;
                case "2":
                    insertionSort(list);
                    break;
                case "3":
                    mergeSort(list, 0, list.Length -1 );
                    break;
                case "4":
                    quickSort(list, 0, list.Length - 1);
                    break;
                // case "5":
                //    blockSort(list);
                //    break;
                default:
                    Console.WriteLine("Not a valid choice");
                    break;
            }
            printList("Sorted List", list);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        static void mergeSort(int[] list, int start, int end)
        {
                // RECURSIVE METHOD
                // Calls itself within itself
                // Overload: when two methods with the same name (but with different
                // arguments) act independently             
                if (start<end)
	            {
                    int mid = (end + start) / 2;
                    mergeSort(list, start, mid);
                    mergeSort(list, mid + 1, end);
                    mergeSort(list, start, mid, end);
                }
           
        }


        static int[] readFromFile()
        {
            // implement file read here
            string fileContents = File.ReadAllText(@"C:\dev\data\unsorted-numbers.txt");

            // cutting through string array
            string[] numberAsString = fileContents.Split(',');

            // declare new int array
            int[] numbers = new int[numberAsString.Length];

            // convert string array into ints
            for (int i = 0; i < numberAsString.Length; i++)
            {
                numbers[i] = int.Parse(numberAsString[i]);
            }
            return numbers;
        }
        static void bubbleSort(int[] list)
        {
            // printList("Unsorted List", list);

            // implement bubble sort here
            // 
            for (int i = list.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (list[j] > list[j + 1]) 
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }

            // printList("Sorted list", list);
        }

        static void insertionSort(int[] list)
        {
            // printList("Unsorted List", list);

            // implement insertion sort here
            //
            for (int i = 0; i < list.Length - 1; i++)
            {
                int j = i + 1;
                while (j > 0)
                {
                    // if index position 0 is greater than index position 1
                    if (list[j - 1] > list[j])
                    {
                        // assign temporary position to index position 0
                        int temp = list[j - 1];
                        // assign index position 0 to index position 1
                        list[j - 1] = list[j];
                        // assign index position 1 to temporary position
                        list[j] = temp;
                    }
                    // increment (-1) until while condition is false
                    j--;
                }
            }

           // printList("Sorted List", list);
        }

        // Merge Sort method involves breaking up 1 array into 2 smaller arrays:
        // list1[start...mid] and list2[mid+1...end]
        static void mergeSort(int[] list, int start, int mid, int end)
        {
            // printList("Unsorted List", list);
            // implement insertion sort here
            
            // Creating temporary array for storing merged array
            // Length of temp array = length of both arrays to be merged
            int[] temp = new int[end - start + 1];
            int i = start, j = mid + 1, k = 0;
            // Traverse (go through) both arrays to store the smallest element of
            // both to the temp array
            while (i <= mid && j <=end)
            {
                if (list[i] < list[j])
                {
                    temp[k] = list[i];
                    k++;
                    i++;
                }
                else
                {
                    temp[k] = list[j];
                    k++;
                    j++;
                }
            }
            // If elements remain in the first array then add them to temp array
            while (i<=mid)
            {
                temp[k] = list[i];
                k++;
                i++;
            }

            // If elements remain in the second array then add them to temp array
            while (j <= end)
            {
                temp[k] = list[j];
                k++;
                j++;
            }
            // Now temp array contains elements of both smaller arrays

            // Traverse (go through) temp array and store element of temp array
            // to original array
            k = 0;
            i = start;
            while (k < temp.Length && i <= end)
            {
                list[i] = temp[k];
                i++;
                k++;
            }

            // printList("Sorted List", list);
        }
        // Method which returns the Pivot Index
        static int partition(int[] list, int start, int end)
        {
            // Create last array element as Pivot Element
            int pivot = end;
            int i = start, j = end, temp;
            while (i < j)
            {
                // Travers (go through) the array and find the index where
                // element is greater than Pivot Element
                while (i < end && list[i] <= list[pivot])
                {
                    i++;
                }
                // Travers (go through) the array and find the index where
                // element is less than Pivot Element
                while (j > start && list[j] > list[pivot])
                {
                    j--;
                }
                // Swap elements indexed i and j
                if (i < j)
                {
                    temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
            // finally put (Swap) pivot element at its right position in array
            temp = list[pivot];
            list[pivot] = list[j];
            list[j] = temp;
            // return pivot index
            return j;
        }
        // Quick Sort Method
        static void quickSort(int[] list, int start, int end)
        {
            //printList("Unsorted List", list);
            // implement insertion sort here

            // Introducing a method that returns a pivot index -
            // element to which another element is compared       

            if (start < end)
            {
                // Find the Pivot Index
                int pivotIndex = partition(list, start, end);
                // Call itself (recursive method) for array element before PI
                quickSort(list, start, pivotIndex - 1);
                // Call itself (recursive method) for array element after PI
                quickSort(list, pivotIndex + 1, end);
            }

            //printList("Sorted List", list);
        }

        static void blockSort(int[] list)
        {
            printList("Unsorted List", list);
            // implement insertion sort here

            printList("Sorted List", list);
        }

        static void printList(string listName, int[] list)
        {
            Console.WriteLine("-- " + listName + " --");
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + ", ");
            }
            Console.WriteLine();
        }
    }
}
