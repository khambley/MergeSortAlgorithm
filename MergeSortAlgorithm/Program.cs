using System;
using System.Collections.Generic;

namespace MergeSortAlgorithm
{
	class Program
	{
		static void Main(string[] args)
		{
			//int[] array = new int[] { 5, 8, 3, 9, 4, 1, 7 }; //{ 7, 3, 8, 1, 9, 4, 0, 6, 5, 2 }
			List<int> array = new List<int>() { 5, 8, 3, 9, 4, 1, 7 };
			Console.WriteLine("Before sorting: ");
			for (int i = 0; i < array.Count; i++)
			{
				Console.Write(array[i] + " ");
			}

			Console.WriteLine();

			var sortedArray = merge_sort(array);

			Console.WriteLine("After sorting: ");

			for (int i = 0; i < array.Count; i++)
			{
				Console.Write(sortedArray[i] + " ");
			}
		}
		public static List<int> merge_sort(List<int> arr)
		{
			List<int> left = new List<int>();
			List<int> right = new List<int>();
			List<int> result = new List<int>();

			if(arr.Count <= 1)
			{
				return arr;
			}

			int mid = arr.Count / 2;

			//Populate left array (list).
			for(int i = 0; i < mid; i++)
			{
				left.Add(arr[i]);
			}

			//Populate right array (list).
			for (int i = mid; i < arr.Count; i++)
			{
				right.Add(arr[i]);
			}

			//Recursively sort the left array
			left = merge_sort(left);
			right = merge_sort(right);

			//Merge the two sorted arrays
			result = merge(left, right);
			return result;
		}
		public static List<int> merge(List<int> left, List<int> right)
		{
			List<int> result = new List<int>();

			int indexLeft = 0;
			int indexRight = 0;

			//while either array still has an element
			while(indexLeft < left.Count || indexRight < right.Count)
			{
				//if both arrays have elements
				if(indexLeft < left.Count && indexRight < right.Count)
				{
					//if item in left array < item in right array, add to result array.
					if(left[indexLeft] <= right[indexRight])
					{
						result.Add(left[indexLeft]);
						indexLeft++;
					}
					// otherwise the item in right array will be added to results array
					else
					{
						result.Add(right[indexRight]);
						indexRight++;
					}
				}
				//if only left array has elements, add all its items to the results array
				else if (indexLeft < left.Count)
				{
					result.Add(left[indexLeft]);
					indexLeft++;
				}
				else if (indexRight < right.Count)
				{
					result.Add(right[indexRight]);
					indexRight++;
				}
			}
			return result;
		}
	}
}
