using System;

// https://leetcode.com/problems/shortest-common-supersequence/
namespace _csharp
{
	public class _1092_shortest_common_supersequence
	{
		public string ShortestCommonSupersequence(string str1, string str2) {
			int n = str1.Length; int m = str2.Length;
			int[,] memo = new int[n+1,m+1];

			for(int i=1;i<=n;++i){
				for(int j=1;j<=m;++j){
					if(str1[i-1] == str2[j-1]){
						memo[i,j] = 1 + memo[i-1,j-1];
					}
					else{
						memo[i,j] = Math.Max(memo[i-1,j], memo[i,j-1]);
					}
				}
			}

			int a=n; int b=m;
			string lcs_string = "";
			while(a>0 && b>0){
				if(str1[a-1] == str2[b-1]){
					lcs_string = str1[a-1] + lcs_string;
					--a; --b;
				}
				else if(memo[a-1,b] > memo[a,b-1]){
					--a;
				}
				else{
					--b;
				}
			}

			Console.WriteLine(lcs_string);

			string result = "";
			int s1=0; int s2=0; int idx=0;
			while(s1<n && s2<m && idx<lcs_string.Length){
				char c1 = str1[s1]; char c2 = str2[s2]; char cx = lcs_string[idx];
				if(c1!=cx){
					result = result + c1; s1++;
				}
				else if(c2!=cx){
					result = result + c2; s2++;
				}
				else{
					result = result + c1; s1++; s2++; idx++;
				}
			}

			while(s1<n){
				result = result + str1[s1]; s1++;
			}

			while(s2<m){
				result = result + str2[s2]; s2++;
			}

			return result;
		}
	}
}