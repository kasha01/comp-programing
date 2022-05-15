using System;
using System.Collections.Generic;

// https://leetcode.com/discuss/interview-question?currentPage=5&orderBy=hot&query=&tag=facebook
namespace _csharp
{
	public class _fb_oa_dot_product
	{
		public void solve(){
			int[] a = new int[]{ 1, 1, 4, 4, 4, 4, 7, 7, 7, 7, 7, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
			int[] b = new int[]{ 2, 2, 5, 5, 5, 5, 5, 5, 5, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };

			var compressed_list_a = compress (a);
			var compressed_list_b = compress (b);

			int ans = getDotProduct(compressed_list_a, compressed_list_b);
			Console.WriteLine (ans);
		}

		private int getDotProduct(List<int[]> a, List<int[]> b){
			int sum = 0;

			int n = a.Count; int m = b.Count;
			int i = 0; int j = 0;
			while (i < n && j < m) {

				int cnt = Math.Min (a [i] [1], b [j] [1]);

				sum = sum + (a [i] [0] * b [j] [0] * cnt);

				a [i] [1] = a [i] [1] - cnt;
				b [j] [1] = b [j] [1] - cnt;

				if (a [i] [1] == 0)
					++i;

				if (b [j] [1] == 0)
					++j;
			}

			return sum;
		}

		private List<int[]> compress(int[] arr){
			var list = new List<int[]> ();
			int n = arr.Length;

			int i = 0;
			while (i < arr.Length) {

				int cnt = 0; int key = arr [i];
				while (i<n && arr [i] == key) {
					cnt++; ++i;
				}

				list.Add (new int[2]{ key, cnt });
			}

			return list;
		}
	}
}