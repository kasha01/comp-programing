using System;

// https://leetcode.com/problems/kth-largest-element-in-an-array/
namespace _csharp
{
	public class _215_kth_largest_element_in_an_array
	{
		public int FindKthLargest(int[] nums, int k) {
			int kk = nums.Length - k;
			return sortLomuto(0, nums.Length-1, nums, kk);
		}

		private int parition(int lo, int hi, int[] arr){
			int pivot = arr[hi];
			int i = lo;
			if (lo < hi)
			{
				for (int j = lo; j < hi; j++)
				{
					if (arr[j] < pivot)
					{
						int temp = arr[j];
						arr[j] = arr[i];
						arr[i] = temp;
						i++;
					}
				}
			}

			arr [hi] = arr [i];
			arr[i] = pivot;
			return i;
		}

		// also known as quick select
		private int sortLomuto(int lo, int hi, int[] arr, int kk){
			if (lo < hi) {
				int pivot = parition (lo, hi, arr);
				if (pivot == kk)
				{
					return arr[kk];
				}

				if(kk<pivot)
					return sortLomuto (lo, pivot-1, arr, kk);    

				if(kk>pivot)
					return sortLomuto (pivot + 1, hi, arr, kk);            
			}

			// count if array becomes 1 element. lo==hi
			return arr[lo];
		}
	}
}