using System;

// https://leetcode.com/problems/where-will-the-ball-fall/
namespace _csharp
{
	public class _1706_where_will_the_ball_fall
	{
		public int[] FindBall(int[][] grid) {
			int r = grid.Length;
			int c = grid[0].Length;
			int[] result = new int[c];

			for(int b=0;b<c;++b){
				int ri=0; int ci=b;
				while(ri < r){
					if(grid[ri][ci] == 1){
						// move down and right .. check next
						if(ci+1<c && grid[ri][ci+1] != -1){
							ri=ri+1;
							ci=ci+1; 
						}
						else{
							break;   // ball is stuck
						}
					}
					else{
						// grid = -1.. move down and left
						if(ci-1>=0 && grid[ri][ci-1] != 1){
							ri=ri+1;
							ci=ci-1;
						}
						else{
							break;   // stuck
						}
					}
				}

				if(ri==r){
					result[b] = ci;
				}
				else{
					result[b] = -1;
				}
			}

			return result;
		}
	}
}

