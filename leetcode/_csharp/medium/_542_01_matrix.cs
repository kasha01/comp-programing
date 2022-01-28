using System;
using System.Collections.Generic;

// https://leetcode.com/problems/01-matrix/
namespace _csharp
{
	public class _542_01_matrix
	{
		public int[][] UpdateMatrix(int[][] matrix) {
			int columns = matrix.Length; int rows = matrix[0].Length;
			int[][] distance = new int[columns][];
			var visited = new bool[rows*columns];

			Queue<Tuple<int,int,int>> qu = new Queue<Tuple<int,int,int>>();
			for(int i=0;i<columns;++i){
				distance[i] = new int[rows];
				for(int j=0;j<rows;++j){
					if(matrix[i][j] == 0){
						qu.Enqueue(Tuple.Create(i,j,0));    
						distance[i][j] = 0;
					}
				}
			}

			// bfs
			while(qu.Count>0){
				var tup = qu.Dequeue();
				int ii=tup.Item1; int jj=tup.Item2; int d=tup.Item3; int v=ii*rows + jj;

				if(visited[v]==true) continue;

				visited[v] = true;
				distance[ii][jj] = d;

				if(ii-1 >= 0 && !visited[(ii-1)*rows + jj]) qu.Enqueue(Tuple.Create(ii-1,jj,d+1)); // up
				if(ii+1 < columns && !visited[(ii+1)*rows + jj]) qu.Enqueue(Tuple.Create(ii+1,jj,d+1)); // down
				if(jj-1 >= 0 && !visited[(ii)*rows + jj-1]) qu.Enqueue(Tuple.Create(ii,jj-1,d+1)); // left
				if(jj+1 < rows && !visited[(ii)*rows + jj+1]) qu.Enqueue(Tuple.Create(ii,jj+1,d+1)); // right
			}

			return distance;
		}
	}
}