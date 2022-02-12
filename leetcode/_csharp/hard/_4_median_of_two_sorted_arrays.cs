using System;

// https://leetcode.com/problems/median-of-two-sorted-arrays/
namespace _csharp
{
	public class _4_median_of_two_sorted_arrays
	{
		public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
			int n = nums1.Length; int m = nums2.Length;

			double median1=0; double median2=0;
			int k = (n+m)/2;
			int i=0; int index1=0; int index2=0;
			while(i<=k){
				median2 = median1;
				if(index1 >= n){
					median1 = nums2[index2++];
				}
				else if(index2 >= m){
					median1 = nums1[index1++];
				}
				else if (nums1[index1] < nums2[index2]){
					median1 = nums1[index1++];
				}
				else{
					median1 = nums2[index2++];
				}

				++i;
			}

			if((n+m)%2 == 0){
				return (median1+median2)/2;
			}

			return median1;
		}

		public double _2_FindMedianSortedArrays(int[] nums1, int[] nums2) {
			int n = nums1.Length; int m = nums2.Length;     
			int z = n+m;
			int countMedian1=-1; int countMedian2=0;
			if(z%2==0){
				// even
				countMedian1 = (z/2);
			}
			countMedian2 = (z/2) + 1;

			int count=0;
			int number=0;
			double median=0;
			int i=0;int j=0;
			while(i<n || j<m){            
				if(i<n && j<m){
					if(nums1[i] <= nums2[j]){
						number=nums1[i]; ++i;
					}
					else{
						number=nums2[j]; ++j;
					}
				}
				else if(i<n){
					number=nums1[i]; ++i;        
				}
				else{
					number=nums2[j]; ++j;                
				}
				++count;

				if(countMedian2 == count){
					median = median+number; break;
				}

				if(countMedian1 == count){
					median = number;
				}
			}

			if(z%2==0){
				// even
				median = ((double)median)/2;
			}

			return median;
		}

	}
}

