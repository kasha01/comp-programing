using System;

// https://leetcode.com/problems/rectangle-overlap/
namespace _csharp
{
	public class _836_rectangle_overlap
	{
		public bool IsRectangleOverlap(int[] rec1, int[] rec2) {
			int xl_1 = rec1[0];
			int yl_1 = rec1[1];
			int xt_1 = rec1[2];
			int yt_1 = rec1[3];

			int xl_2 = rec2[0];
			int yl_2 = rec2[1];
			int xt_2 = rec2[2];
			int yt_2 = rec2[3];

			return !(
				(yl_2 >= yt_1) ||
				(yt_2 <= yl_1) ||
				(xl_2 >= xt_1) ||
				(xt_2 <= xl_1)
			);
		}
	}
}