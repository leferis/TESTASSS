﻿namespace Lab1
{
     
    internal class SelectionSort : Sort
    {
        public static void Sort(Array items, ArrayLong a, ArrayLong t, ArrayLong count, ArrayLong pref)
        {
            for (var i = 0; i < items.Length - 1; i++)
            {
                var indexOfMin = i;

                for (var j = i + 1; j < items.Length; j++)
                {
                    ComparisonCount++;

                    if (items[j] < items[indexOfMin])
                    {
                        indexOfMin = j;
                    }
                }

                if (indexOfMin != i)
                {
                    SwapCount++;
                    items.Swap(i, indexOfMin);
                }
            }
        }

        public static void Sort(LinkedList items, ArrayLong a, ArrayLong t, ArrayLong count, ArrayLong pref)
        {
            var length = items.Count;
            var currentOuter = items.GetFirstNode();

            for (var i = 0; i < length - 1; i++)
            {
                var minimum = currentOuter;
                var currentInner = items.NextOf(currentOuter);

                for (var j = i + 1; j < length; j++)
                {
                    ComparisonCount++;

                    if (currentInner.Value < minimum.Value)
                    {
                        minimum = currentInner;
                    }
                    currentInner = items.NextOf(currentInner);
                }

                if (!ReferenceEquals(minimum, currentOuter))
                {
                    SwapCount++;
                    items.Swap(minimum, currentOuter);
                }
                currentOuter = items.NextOf(currentOuter);
            }
        }
    }
}