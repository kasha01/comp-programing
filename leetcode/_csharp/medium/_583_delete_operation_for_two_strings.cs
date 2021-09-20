using System;

// https://leetcode.com/problems/delete-operation-for-two-strings/
namespace _csharp
{
	public class _583_delete_operation_for_two_strings
	{
		public int MinDistance(string word1, string word2) {
			int n = word1.Length; int m = word2.Length;
			int[,] memo = new int[n+1,m+1];

			for(int i=0;i<=n;++i){
				memo[i,0]=i;
			}

			for(int i=0;i<=m;++i){
				memo[0,i]=i;
			}

			for(int i=1;i<=n;++i){
				for(int j=1;j<=m;++j){
					if(word1[i-1]==word2[j-1]){
						memo[i,j] = memo[i-1,j-1];
					}
					else{
						memo[i,j] = 1+Math.Min(memo[i-1,j],memo[i,j-1]);
					}
				}
			}

			return memo[n,m];
		}
	}
}