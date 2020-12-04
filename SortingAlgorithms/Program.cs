using System;

namespace SortingAlgorithms
{
    static class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 9, 6, 0, 4 };

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('_', 10) + "\n");

            //arr.BubbleSort();
            //arr.InsertionSort();
            arr.SelectionSort();
            //arr.MergeSort();
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        static void Swap(this int[] items, int left, int right)
        {
            if (left < 0 && right < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (left != right)
            {
                int temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }

        static void BubbleSort(this int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 1; j < arr.Length - i; j++)
                {
                    if (arr[j - 1].CompareTo(arr[j]) > 0)
                    {
                        arr.Swap(j - 1, j);
                    }
                }
            }
        }

        static void InsertionSort(this int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (arr[j].CompareTo(arr[j - 1]) < 0)
                    {
                        arr.Swap(j - 1, j);
                    }
                }
            }
        }

        static void SelectionSort(this int[] arr)
        {
            int min = 0;
            int minIndex = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                min = arr[i];

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(min) < 0)
                    {
                        min = arr[j];
                        minIndex = j;
                    }
                }

                arr.Swap(i, minIndex);
            }
        }

        static void MergeSort(this int[] arr)
        {
            if (arr.Length <= 1)
            {
                return;
            }

            int leftSize = arr.Length / 2;
            int rightSize = arr.Length - leftSize;

            int[] leftArr = new int[leftSize];
            int[] rightArr = new int[rightSize];

            Array.Copy(arr, 0, leftArr, 0, leftSize);
            Array.Copy(arr, leftSize, rightArr, 0, rightSize);

            MergeSort(leftArr);
            MergeSort(rightArr);

            Merge(arr, leftArr, rightArr);
        }

        private static void Merge(int[] array, int[] leftArr, int[] rightArr)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int targetIndex = 0;
            int remaining = leftArr.Length + rightArr.Length;

            while (remaining > 0)
            {
                if (leftIndex >= leftArr.Length)
                {
                    array[targetIndex] = rightArr[rightIndex++];
                }
                else if (rightIndex >= rightArr.Length)
                {
                    array[targetIndex] = leftArr[leftIndex++];
                }
                else if (leftArr[leftIndex].CompareTo(rightArr[rightIndex]) < 0)
                {
                    array[targetIndex] = leftArr[leftIndex++];
                }
                else
                {
                    array[targetIndex] = rightArr[rightIndex++];
                }

                targetIndex++;
                remaining--;
            }
        }
    }
}
