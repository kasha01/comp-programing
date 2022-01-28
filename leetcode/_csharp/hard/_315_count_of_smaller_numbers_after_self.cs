using System;
using System.Collections.Generic;

// https://leetcode.com/problems/count-of-smaller-numbers-after-self/
namespace _csharp
{
	public class _315_count_of_smaller_numbers_after_self
	{
		// index | count of items smaller
		int[] map;

		public IList<int> CountSmaller(int[] nums) {
			int n = nums.Length;
			map = new int[n];

			// index | number
			var arr = new Tuple<int,int>[n];

			for(int i=0;i<n;++i){
				arr[i] = Tuple.Create(i,nums[i]);
			}

			mergeSort(0,n-1,arr);

			return map;
		}

		private void mergeSort(int l, int r, Tuple<int,int>[] arr){
			if(l>=r) return;

			int m = ((r-l)/2) + l;
			mergeSort(l,m,arr);
			mergeSort(m+1,r,arr);

			merge(l,r,m,arr);
		}

		private void merge(int l, int r, int m, Tuple<int,int>[] arr){
			int l_size = m - l + 1;
			int r_size = r - m;
			int k = l;

			var left = new Tuple<int,int>[l_size];
			for(int ii=0;ii<l_size;++ii){
				left[ii] = arr[l+ii]; 
			}

			var right = new Tuple<int,int>[r_size];
			for(int ii=0;ii<r_size;++ii){
				right[ii] = arr[m+1+ii]; 
			}

			int i=0; int j=0; int numberOfSmallerItemsOnRightSide=0;
			while(i<l_size && j<r_size){
				if(left[i].Item2 <= right[j].Item2){
					map[left[i].Item1] += numberOfSmallerItemsOnRightSide;
					arr[k] = left[i];
					++k; ++i;
				}
				else{
					// a number on the right side (j) is smaller than a number on the left side (i)
					++numberOfSmallerItemsOnRightSide;
					arr[k] = right[j];
					++k; ++j;
				}
			}

			while(i<l_size){
				map[left[i].Item1] += numberOfSmallerItemsOnRightSide;
				arr[k] = left[i]; ++i;++k;
			}

			while(j<r_size){
				arr[k] = right[j]; ++j;++k;
			}
		}
	}
}