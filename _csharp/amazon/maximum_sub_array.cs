using System;

// https://practice.geeksforgeeks.org/problems/maximum-sub-array/0
namespace GeeksForGeeks_csharp
{
	public class maximum_sub_array
	{
		static int mxsum = 0;
		static int localSum = 0;
		static int i = 0; static int j = 0;
		static int _i = 0; static int _j = 0;
		static bool firstPositive = true;

		public static void test()
		{
			int[] arr = {-1,-6,-3,0,5};
			solve (arr, 5);
		}

		static void compare_segments(){
			if (localSum < mxsum) {
				// ignore
			} else if (localSum > mxsum) {
				// we have a new max segement
				i = _i;
				j = _j;
				mxsum = localSum;
			} else {
				// compare lengths
				int length = j - i;
				int _length = _j - _i;
				if (_length > length) {
					i = _i;
					j = _j;
				} else if (_length < length) {
					// ignore
				} else{
					// compare first index
					if (_i < i) {
						i = _i;
						j = _j;		
					}
				}
			}		
		}

		static void solve(int[] arr, int n){

			for (int k = 0; k < n; ++k) {
				int x = arr [k];

				if (x >= 0) {
					if (firstPositive) {
						firstPositive = false;
						i = k; j = k; _i = k;
					}

					localSum = localSum + x;
					_j = k;
				} else {
					// segement ends
					compare_segments();

					// new start
					_i = k + 1; localSum = 0;
				}
			}

			compare_segments ();

			for (int a = i; a <= j; a++) {
				Console.Write (arr [a] + " ");
			}
			Console.WriteLine ();
		}
	}
}

