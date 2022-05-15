using System;

// https://leetcode.com/problems/first-bad-version/
namespace _csharp
{
	public class _278_first_bad_version
	{
		public int FirstBadVersion(int n) {
			int lo = 1; int hi=n;
			return getBadVersion(lo,hi);
		}

		private int getBadVersion(int lo, int hi){
			if(lo>=hi){
				return lo;
			}

			int mid = lo + (hi-lo)/2;
			bool isVersionBad = IsBadVersion(mid);

			if(isVersionBad){
				return getBadVersion(lo, mid);
			}

			return getBadVersion(mid+1, hi);
		}

		bool IsBadVersion(int version){
			throw new Exception();
		}
	}
}

