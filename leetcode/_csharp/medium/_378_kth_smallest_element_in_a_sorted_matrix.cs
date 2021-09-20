using System;

// https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/
namespace _csharp
{
	public class _378_kth_smallest_element_in_a_sorted_matrix
	{
		public int KthSmallest(int[][] matrix, int k) {
			int n = matrix.Length;
			int[] arr = new int[n];
			int result = 0;
			int smallest;

			int j = -1;
			while(k!=0){
				--k;
				smallest = int.MaxValue;
				for(int i=0;i<n;++i){
					int index_of_i_row = arr[i];
					if(index_of_i_row >= n)
						continue;

					int x = matrix[i][index_of_i_row];

					if(x <= smallest){
						j = i;
						smallest = x;
					}                
				}

				++arr[j];
				result = smallest;
			}

			return result;
		}
	}
}

