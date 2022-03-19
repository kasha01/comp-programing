using System;

// https://leetcode.com/problems/determine-whether-matrix-can-be-obtained-by-rotation/

// NOT MINE - TO TRY MORE OPTIMAL ROTATION ALGORITHMS
// COURTESY OF eminem18753
// https://leetcode.com/problems/determine-whether-matrix-can-be-obtained-by-rotation/discuss/1254089/C%2B%2B-straightforward-solution-comparing-in-place

namespace _csharp
{
	public class _1886_determine_whether_matrix_can_be_obtained_by_rotation
	{
		public bool FindRotation(int[][] mat, int[][] target) {
			int n = mat.Length;

			var c = new bool[4];
			for(int i=0;i<4;++i)
				c[i] = true;

			for(int i=0;i<n;i++)
			{
				for(int j=0;j<n;j++)
				{
					if(mat[i][j]!=target[i][j]) c[0]=false;         // 0 degree rotation
					if(mat[i][j]!=target[n-j-1][i]) c[1]=false;     // 90 degree rotation anti-clockwise
					if(mat[i][j]!=target[n-i-1][n-j-1]) c[2]=false; // 180 degree rotation
					if(mat[i][j]!=target[j][n-i-1]) c[3]=false;     // 270 degree rotation anti-clockwise

					if(!c[0] && !c[1] && !c[2] && !c[3])
						return false;
				}
			}

			return true;
		}		
	}
}