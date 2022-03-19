using System;

// https://leetcode.com/problems/knight-probability-in-chessboard/
namespace _csharp
{
	public class _688_knight_probability_in_chessboard
	{
		public double KnightProbability(int n, int k, int row, int column) {
			var directions = new int[,]{ {1,2},{1,-2},{-1,2},{-1,-2}, {2,1},{2,-1},{-2,1},{-2,-1} };

			double[,] dp = new double[n,n];
			dp[row,column] = 1;

			for(int m=1;m<=k;++m){
				var dpNew = new double[n,n];
				for(int i=0;i<n;++i){
					for(int j=0;j<n;++j){
						for(int d=0;d<8;++d){
							int new_i = i + directions[d,0];
							int new_j = j + directions[d,1];

							if(new_i<0 || new_i>=n || new_j<0 || new_j>=n) continue;

							dpNew[new_i,new_j] = dpNew[new_i,new_j] + (dp[i,j]/8.0);    
						}                    
					}
				}

				dp = dpNew;
			}

			double sum = 0;
			for(int i=0;i<n;++i){
				for(int j=0;j<n;++j){
					sum = sum + dp[i,j];
				}
			}

			return sum;
		}
	}
}