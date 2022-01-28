using System;

// https://leetcode.com/problems/capacity-to-ship-packages-within-d-days/
namespace _csharp
{
	public class _1011_capacity_to_ship_packages_within_d_days
	{
		public int ShipWithinDays(int[] weights, int days) {
			int sum = 0;
			foreach(int x in weights){
				sum = sum + x;
			}

			int lo=1; int hi=sum; int ans=0;
			while(lo<=hi){
				int mid = lo + ((hi-lo)/2);

				bool b = isValid(mid,weights,days);
				if(b){
					hi = mid-1; ans = mid;
				}
				else{
					lo = mid+1;
				}
			}

			return ans;
		}

		private bool isValid(int v, int[] weights, int days){
			int i=0; int sum=0; 
			while(i<weights.Length){
				// even a single weight is larger than v -> exit
				if(weights[i] > v) return false;

				if(sum + weights[i] > v){
					--days; sum=0;  //reset - start new day
				}

				if(days <= 0) return false;

				sum = sum + weights[i];

				++i;
			}

			return true;
		}
	}
}