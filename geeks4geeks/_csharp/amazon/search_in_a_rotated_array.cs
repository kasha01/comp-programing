using System;

// https://practice.geeksforgeeks.org/problems/search-in-a-rotated-array/0
namespace GeeksForGeeks_csharp
{
	public class search_in_a_rotated_array
	{
		static int[] arr = { 5 ,6 ,7 ,8 ,9 ,10 ,1 ,2 ,3};
		public static void test ()
		{
			int n = 9;
			int res = bs (0, n - 1, 10);
			Console.WriteLine (res);
		}

		static int bs(int i, int j, int k){
			int m = ((j - i) / 2) + i;

			if (arr [m] == k)
				return m;

			if(j-i==1){
				if(arr[i] == k)
					return i;
				if(arr[j] == k)
					return j;

				return -1;
			}

			if (arr [i] <= arr [m]) {
				// left section not rotated.
				// check if target is within the boundary of left section.
				if (k < arr [m] && k >= arr[i]) {
					return bs (i, m, k);
				}
			} else {
				// left section is inverted.
				// check if target is within the boundary of the inverted left section.
				// i.e. it is bigger than its left bound [i], or smaller than its right bound [m]
				if(k >= arr[i] || k < arr[m]){
					return bs (i, m, k);
				}
			}

			// notice here if the 
			// left section was not rotated but target was not within boundary OR if the
			// left section was inverted but target was not within boundary. I do want to check the
			// section.

			if (arr [m] <= arr [j]) {
				// right section not rotated
				// check if target is within the boundary of right section.
				if (k > arr [m] && k <= arr[j]) {
					return bs (m, j, k);
				}
			} else {
				// right section is inverted.
				// check if target is within the boundary of the inverted right section.
				// i.e. it is bigger than its left bound [m], or smaller than its right bound [j]
				if (k > arr [m] || k <= arr [j]) {
					return bs (m, j, k);
				}
			}

			return -1;
		}

		// Geeks4Geeks solution - cleaner than mine but same concept
		int search(int[] arr, int l, int h, int key) 
		{ 
			if (l > h) 
				return -1; 

			int mid = (l + h) / 2; 
			if (arr[mid] == key) 
				return mid; 

			// The tricky case, just update left and right 
			if ((arr[l] == arr[mid]) 
				&& (arr[h] == arr[mid])) { 
				++l; 
				--h; 
			} 

			// If arr[l...mid] is sorted 
			if (arr[l] <= arr[mid]) { 

				// As this subarray is sorted, we can quickly 
				// check if key lies in any of the halves 
				if (key >= arr[l] && key <= arr[mid]) 
					return search(arr, l, mid - 1, key); 

				// If key does not lie in the first half 
				// subarray then divide the other half 
				// into two subarrays such that we can 
				// quickly check if key lies in the other half 
				return search(arr, mid + 1, h, key); 
			} 

			// If arr[l..mid] first subarray is not sorted 
			// then arr[mid... h] must be sorted subarray.
			// check if the key is within the boundary.
			if (key >= arr[mid] && key <= arr[h]) 
				return search(arr, mid + 1, h, key); 

			// If key does not lie in the second/right subarry arr[mid... h]
			// then divide the other half (left) 
			// into two subarrays such that we can 
			// quickly check if key lies in the other half 
			return search(arr, l, mid - 1, key); 
		} 
	}
}