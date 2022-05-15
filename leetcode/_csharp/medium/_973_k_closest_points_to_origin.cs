using System;

// https://leetcode.com/problems/k-closest-points-to-origin/
// tags: quick select average:O(N) as we only partition one half of the array.
namespace _csharp
{
	public class _973_k_closest_points_to_origin
	{
		public int[][] KClosest(int[][] points, int k) {
			int n = points.Length;

			// tuple: index | distance
			var distance = new Tuple<int,int>[n];
			for(int i=0;i<n;++i){
				var d = (points[i][0] * points[i][0]) + (points[i][1] * points[i][1]);
				distance[i] = Tuple.Create(i,d);
			}       

			quickSort(0,n-1,k,distance);

			var ans = new int[k][];
			for(int i=0;i<k;++i){
				ans[i] = points[distance[i].Item1];
			}

			return ans;
		}

		private void quickSort(int lo, int hi, int k, Tuple<int,int>[] distance){
			if(lo<hi){
				int pivotIndex = partition(lo,hi,distance);

				if(pivotIndex == k){
					return;     // return distance[k];
				}

				if(pivotIndex < k)
					quickSort(pivotIndex+1,hi,k,distance);

				if(pivotIndex > k)
					quickSort(lo,pivotIndex-1,k,distance);
			}

			return;    // size 1 array: return distance[lo];
		}

		private int partition(int lo, int hi, Tuple<int,int>[] distance){
			var pivotItem = distance[hi];
			var pivot = pivotItem.Item2;
			int i=lo;

			if(lo<hi){
				for(int j=lo;j<hi;++j){
					if(distance[j].Item2 < pivot){
						// swap i with j
						var temp = distance[j];
						distance[j] = distance[i];
						distance[i] = temp;
						++i;
					}
				}
			}

			distance[hi] = distance[i];
			distance[i] = pivotItem;
			return i;
		}

	}
}

