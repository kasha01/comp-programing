using System;

// https://leetcode.com/problems/delete-and-earn/
namespace _csharp
{
	public class _740_delete_and_earn
	{
		public int DeleteAndEarn(int[] nums) {
			int[] arr = new int[10001];

			int mn=10000; int mx=1;
			foreach(int x in nums){
				arr[x]++;
				mn=Math.Min(mn,x);
				mx=Math.Max(mx,x);
			}

			int ans = -1;
			int[] pick = new int[10001];
			int[] no_pick = new int[10001];
			for(int i=mn;i<=mx;++i){
				int s = arr[i]*i;

				pick[i] = s + no_pick[i-1];
				no_pick[i] = Math.Max(pick[i-1],no_pick[i-1]);

				ans = Math.Max(ans, Math.Max(pick[i],no_pick[i]));
			}

			return ans;
		}
	}
}