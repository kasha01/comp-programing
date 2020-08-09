using System;

// https://www.geeksforgeeks.org/find-element-bitonic-array/
namespace GeeksForGeeks_csharp
{
	public class find_an_element_in_bitonic_array
	{
		static int? a, b = null;
		static int[] arr; 
		public static void test ()
		{
			int n = 5;
			arr = new int[]{ -1, 2, 7, 4, -3 };
			int r = solve (n, -3);
			Console.WriteLine (r);
		}

		static int solve(int n, int x){
			int p = findPeakPoint(0,n-1);
			if (x > arr [p])
				return -1;
			else if (x == arr [p])
				return p;
			else {
				int result = -1;
				result = bsearch (0, p - 1, x);
				if (result == -1) {
					result = bsearchDesc (p + 1, n - 1, x);
				}
				return result;
			}				
		}

		static int bsearch(int i, int j, int x){
			int m = ((j - i) / 2) + i;

			while (i<=j) {
				if (arr [m] == x)
					return m;
				else if (arr [m] < x)
					return bsearch (m + 1, j, x);
				else if (arr [m] > x)
					return bsearch (i, m - 1, x);
			}
			return -1;
		}

		static int bsearchDesc(int i, int j, int x){
			int m = ((j - i) / 2) + i;

			while (i<=j) {
				if (arr [m] == x)
					return m;
				else if (arr [m] > x)
					return bsearchDesc (m + 1, j, x);
				else if (arr [m] < x)
					return bsearchDesc (i, m - 1, x);
			}
			return -1;
		}

		static int findPeakPoint(int i, int j){
			int m = ((j - i) / 2) + i;

			if (i == j)
				return m;

			while (i < j) {
				if(m-1>=i)
					a = arr [m - 1];

				if(m+1<=j)
					b = arr [m + 1];

				if (a.HasValue && b.HasValue && a.Value < arr [m] && b.Value < arr [m]) {
					return m;
				}
				else if ((a.HasValue && a.Value < arr [m]) || (b.HasValue && arr [m] < b.Value)) {
					// ascending
					return findPeakPoint (m + 1, j);
				} else if ((a.HasValue && a.Value > arr [m]) || (b.HasValue && arr [m] > b.Value)) {
					// desc
					return findPeakPoint (i, m - 1);
				} else {
					return -1;
				}
			}
			return -1;
		}
	}
}

