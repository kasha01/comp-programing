using System;

// https://leetcode.com/problems/robot-bounded-in-circle/
namespace _csharp
{
	public class _1041_robot_bounded_in_circle
	{
		public bool IsRobotBounded(string instructions) {
			int[][] distance = new int[4][];
			distance[0] = new int[]{0,1};   // north
			distance[1] = new int[]{1,0};   // east
			distance[2] = new int[]{0,-1};  // south
			distance[3] = new int[]{-1,0};  // west

			int x=0; int y=0; int d=0;
			for(int i=0;i<instructions.Length;++i){
				if(instructions[i]=='R'){
					d = (d+1)%4;
				}
				else if(instructions[i]=='L'){
					d = (d+3)%4;
				}
				else{
					x = x + distance[d][0];
					y = y + distance[d][1];
				}
			}

			// cycle exists if we are back to origin or we are not pointing north
			return (x==0 && y==0) || (d%4) != 0;
		}
	}
}