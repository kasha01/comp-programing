using System;

// https://leetcode.com/problems/monotone-increasing-digits/
namespace _csharp
{
	public class _738_monotone_increasing_digits
	{
		public int MonotoneIncreasingDigits(int x) {
			var ch = x.ToString().ToCharArray();
			int n = ch.Length;
			var arr = new int[n];

			for (int i = 0; i < n; ++i) {
				arr [i] = ch [i] - '0';
			}

			int marker = n-1;
			for(int i=n-2;i>=0;--i){
				int fi = arr[i+1];
				int sc = arr[i];

				if(fi<sc){
					while(marker>i){
						arr[marker] = 9;
						--marker;
					}
					arr[i] = sc-1;
				}
			}

			int ans = 0;
			for(int i=0;i<n;++i){
				ans = (10 * ans) + arr [i];
			}

			return ans;
		}
	}
}