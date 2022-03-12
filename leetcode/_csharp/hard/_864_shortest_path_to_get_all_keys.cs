using System;
using System.Collections.Generic;

// https://leetcode.com/problems/shortest-path-to-get-all-keys/submissions/
namespace _csharp
{
	public class _864_shortest_path_to_get_all_keys
	{
		public int ShortestPathAllKeys(string[] grid) {
			int n = grid.Length; int m = grid[0].Length;
			Queue<int[]> qu = new Queue<int[]>();
			int steps=0;
			var visited = new bool[n,m,65];
			var directions = new int[,]{{1,0},{-1,0},{0,1},{0,-1}};
			int keysCount = 0;

			// find starting point
			for(int i=0;i<n;++i){
				for(int j=0;j<m;++j){
					if(grid[i][j] == '@'){
						qu.Enqueue(new int[] {i,j,0,0});
						visited[i,j,0] = true;
					}
					else if(grid[i][j]>='a' && grid[i][j]<='z'){
						keysCount++;
					}
				}
			}

			while(qu.Count > 0){
				int sz = qu.Count;
				for(int c=0;c<sz;++c){
					var node = qu.Dequeue();
					int i = node[0];
					int j = node[1];

					for(int d=0;d<4;++d){
						int keys = node[2];
						int currentKeysCount = node[3];
						bool isOpen = true;
						int new_i = i + directions[d,0];
						int new_j = j + directions[d,1];

						if(new_i<0 || new_i>=n || new_j<0 || new_j>=m) continue;    // out of bound
						if(grid[new_i][new_j] == '#') continue; // wall
						if(visited[new_i,new_j,keys]) continue;

						if(grid[new_i][new_j] >= 'a' && grid[new_i][new_j] <= 'f'){
							// found a key
							int key = grid[new_i][new_j] - 'a';

							// if I already had picked the key. don't double count it.
							// this can happen if I picked the key and went backwards.
							bool alreadyHasKey = (keys & (1 << key)) > 0;

							keys = keys | (1 << key);
							currentKeysCount = alreadyHasKey ? currentKeysCount : currentKeysCount+1;
						}
						else if(grid[new_i][new_j] >= 'A' && grid[new_i][new_j] <= 'F'){
							// found a lock - try to open
							int _lock = grid[new_i][new_j] - 'A';
							isOpen = (keys & (1 << _lock)) > 0;
						}

						if(!isOpen) continue;

						if(keysCount==currentKeysCount) return steps+1;

						visited[new_i,new_j,keys] = true;
						qu.Enqueue(new int[]{new_i,new_j,keys,currentKeysCount});
					}
				}

				++steps;
			}

			return -1;
		}
	}
}