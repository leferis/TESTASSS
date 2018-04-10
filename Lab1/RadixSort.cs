using System;

namespace Lab1
{

    internal class RadixSort : Sort
    {
        public const int GroupLength = 16;
        private const int BitLength = 64;

        private const long Groups = BitLength / GroupLength;
        private const long Mask = (1 << GroupLength) - 1;


        public static void Sort(Array items, ArrayLong a, ArrayLong t, ArrayLong count, ArrayLong pref)
        {
            var length = items.Length;

            for (var i = 0; i < length; i++)
            {
                a[i] = BitConverter.ToInt64(BitConverter.GetBytes(items[i]), 0);
            }
            for (int c = 0, shift = 0; c < Groups; c++, shift += GroupLength)
            {

                for (var j = 0; j < count.Length; j++)
                    count[j] = 0;

                for (var index = 0; index < a.Length; index++)
                {
                    var i = a[index];
                    count[(int)((i >> shift) & Mask)]++;
                }

                pref[0] = 0;
                for (var i = 1; i < count.Length; i++)
                    pref[i] = pref[i - 1] + count[i - 1];


                for (var index1 = 0; index1 < a.Length; index1++)
                {
                    var i = a[index1];
                    var index = pref[(int)((i >> shift) & Mask)]++;
                    t[(int)index] = i;
                }
                t.CopyTo(a, 0);
            }

            for (var i = 0; i < length; i++)
            {
                items[i] = BitConverter.ToDouble(BitConverter.GetBytes(a[i]), 0);
            }
        }

        public static void Sort(LinkedList items, ArrayLong a, ArrayLong t, ArrayLong count, ArrayLong pref)
        {
            var length = items.Count;
            var current = items.GetFirstNode();
            for (var i = 0; i < items.Count; i++)
            {
                a[i] = BitConverter.ToInt64(BitConverter.GetBytes(current.Value), 0);
                current = items.NextOf(current);
            }

            for (int c = 0, shift = 0; c < Groups; c++, shift += GroupLength)
            {
                for (var j = 0; j < count.Length; j++)
                    count[j] = 0;

                for (var index = 0; index < a.Length; index++)
                {
                    var i = a[index];
                    count[(int)((i >> shift) & Mask)]++;
                }

                pref[0] = 0;
                for (var i = 1; i < count.Length; i++)
                    pref[i] = pref[i - 1] + count[i - 1];

                for (var index1 = 0; index1 < a.Length; index1++)
                {
                    var i = a[index1];
                    var index = pref[(int)((i >> shift) & Mask)]++;
                    t[(int)index] = i;
                }

                t.CopyTo(a, 0);
            }

            current = items.GetFirstNode();
            for (var i = 0; i < length; i++)
            {
                items.SetValue(current, BitConverter.ToDouble(BitConverter.GetBytes(a[i]), 0));
                current = items.NextOf(current);
            }
        }
    }
}