using System;

// https://leetcode.com/problems/find-the-distance-value-between-two-arrays/
namespace _csharp
{
	public class _1385_find_the_distance_value_between_two_arrays
	{
		public int FindTheDistanceValue(int[] arr1, int[] arr2, int d) {
			Array.Sort(arr2);

			int ans = 0;
			int n = arr1.Length;
			for(int i=0;i<n;++i){
				int targetOrGreaterIndex = bs(arr2,arr1[i]);

				if(targetOrGreaterIndex>0){
					int distance1 = Math.Abs(arr2[targetOrGreaterIndex] - arr1[i]);
					int distance2 = Math.Abs(arr2[targetOrGreaterIndex-1] - arr1[i]);

					if(distance1 > d && distance2 > d)
						++ans;
				}
				else{
					int distance = Math.Abs(arr2[targetOrGreaterIndex] - arr1[i]);
					if(distance > d)
						++ans;
				}
			}

			return ans;
		}

		private int bs(int[] arr, int target){
			int l=0; int r=arr.Length-1;

			int mid=r;
			while(l<r){
				mid = ((r-l)/2) + l;
				if(arr[mid]>=target){
					r=mid;
				}
				else{
					l=mid+1;
				}
			}

			return l;
		}
	}
}

