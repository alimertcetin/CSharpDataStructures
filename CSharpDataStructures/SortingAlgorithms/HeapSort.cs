using System;

// https://www.tutorialspoint.com/heap-sort-in-chash#
namespace XIV.SortingAlgorithms
{
    public static class HeapSorting
    {
        public static void Sort(int[] arr, int itemCount)
        {
            int loopCount = 0;

            int middle = itemCount / 2 - 1;
            for (int i = middle; i >= 0; i--)
            {
                Heapify(arr, itemCount, i, ref loopCount);
            }

            for (int i = itemCount - 1; i >= 0; i--)
            {
                (arr[0], arr[i]) = (arr[i], arr[0]);
                Heapify(arr, i, 0, ref loopCount);
            }
            Console.WriteLine("Looped : " + loopCount);
        }

        static void Heapify(int[] arr, int itemCount, int currentIndex, ref int loopCount)
        {
            loopCount++;
            int parentIndex = currentIndex;
            int left = 2 * currentIndex + 1;
            int right = 2 * currentIndex + 2;

            if (left < itemCount && arr[left] > arr[parentIndex])
            {
                parentIndex = left;
            }

            if (right < itemCount && arr[right] > arr[parentIndex])
            {
                parentIndex = right;
            }

            if (parentIndex != currentIndex)
            {
                (arr[currentIndex], arr[parentIndex]) = (arr[parentIndex], arr[currentIndex]);
                Heapify(arr, itemCount, parentIndex, ref loopCount);
            }
        }

        public static void Sort<T>(T[] arr, int itemCount)
            where T : IComparable<T>
        {
            int loopCount = 0;

            int middle = itemCount / 2 - 1;
            for (int i = middle; i >= 0; i--)
            {
                Heapify(arr, itemCount, i, ref loopCount);
            }

            for (int i = itemCount - 1; i >= 0; i--)
            {
                (arr[0], arr[i]) = (arr[i], arr[0]);
                Heapify(arr, i, 0, ref loopCount);
            }
            Console.WriteLine("Looped : " + loopCount);
        }

        static void Heapify<T>(T[] arr, int itemCount, int currentIndex, ref int loopCount)
            where T : IComparable<T>
        {
            loopCount++;
            int parentIndex = currentIndex;
            int left = 2 * currentIndex + 1;
            int right = 2 * currentIndex + 2;

            if (left < itemCount && arr[left].CompareTo(arr[parentIndex]) > 0)
            {
                parentIndex = left;
            }

            if (right < itemCount && arr[right].CompareTo(arr[parentIndex]) > 0)
            {
                parentIndex = right;
            }

            if (parentIndex != currentIndex)
            {
                (arr[currentIndex], arr[parentIndex]) = (arr[parentIndex], arr[currentIndex]);
                Heapify(arr, itemCount, parentIndex, ref loopCount);
            }
        }

        public static void Sort<T>(T[] arr, int itemCount, Comparison<T> comparison)
        {
            int loopCount = 0;

            int middle = itemCount / 2 - 1;
            for (int i = middle; i >= 0; i--)
            {
                Heapify(arr, itemCount, i, comparison, ref loopCount);
            }

            for (int i = itemCount - 1; i >= 0; i--)
            {
                (arr[0], arr[i]) = (arr[i], arr[0]);
                Heapify(arr, i, 0, comparison, ref loopCount);
            }
            Console.WriteLine("Looped : " + loopCount);
        }

        static void Heapify<T>(T[] arr, int itemCount, int currentIndex, Comparison<T> comparison, ref int loopCount)
        {
            loopCount++;
            int parentIndex = currentIndex;
            int left = 2 * currentIndex + 1;
            int right = 2 * currentIndex + 2;

            if (left < itemCount && comparison.Invoke(arr[left], arr[parentIndex]) > 0)
            {
                parentIndex = left;
            }

            if (right < itemCount && comparison.Invoke(arr[right], arr[parentIndex]) > 0)
            {
                parentIndex = right;
            }

            if (parentIndex != currentIndex)
            {
                (arr[currentIndex], arr[parentIndex]) = (arr[parentIndex], arr[currentIndex]);
                Heapify(arr, itemCount, parentIndex, comparison, ref loopCount);
            }
        }

    }

}