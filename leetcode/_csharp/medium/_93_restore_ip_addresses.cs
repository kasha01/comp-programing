using System;
using System.Collections.Generic;

// https://leetcode.com/problems/restore-ip-addresses/
namespace _csharp
{
	public class _93_restore_ip_addresses
	{
		List<string> ans;
		public IList<string> RestoreIpAddresses(string s) {
			ans = new List<string>();
			fn(0, 0, new int[4], s, s.Length);
			return ans.ToArray();
		}

		private void fn(int start, int parts, int[] ip, string s, int n){
			if(start==n && parts==4){
				string myIp=$"{ip[0]}.{ip[1]}.{ip[2]}.{ip[3]}";
				ans.Add(myIp);
				return;
			}

			if(start>=n || parts >= 4)
				return;

			int remainingDigits = n-start;
			int remainingParts = 4-parts;
			if(remainingDigits < remainingParts || remainingDigits > remainingParts*3)
				return;

			if(s[start]-'0' == 0){
				ip[parts] = 0;
				fn(start+1, parts+1, ip, s, n);
				return;
			}

			int sum = 0;
			for(int i=start;(i<start+4) && (i<n); ++i){
				sum = sum*10 + (s[i]-'0');
				if(sum>255)
					return;

				ip[parts] = sum;
				fn(i+1, parts+1, ip, s, n);
			}
		}
	}
}