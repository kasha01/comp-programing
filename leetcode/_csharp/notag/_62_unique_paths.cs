using System;
using System.Collections.Generic;

// https://leetcode.com/problems/unique-paths/
namespace _csharp
{
	public class _62_unique_paths
	{
		int M=0;
		int N=0;
		int[,] memo;
		public int UniquePaths(int m, int n) {
			M=m; N=n;
			memo = new int[n,m];
			return unique(0,0);
		}

		private int unique(int x, int y){
			if(x>=N || y>=M)
				return 0;

			if(x==N-1 && y==M-1)
				return 1;

			if(memo[x,y] > 0)
				return memo[x,y];

			int a = unique(x,y+1);  // down
			int b = unique(x+1,y);  // right
			memo[x,y] = a+b;

			return memo[x,y];
		}
	}
}

