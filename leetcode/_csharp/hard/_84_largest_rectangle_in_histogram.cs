using System;
using System.Collections.Generic;

// https://leetcode.com/problems/largest-rectangle-in-histogram/
namespace _csharp
{
	public class _84_largest_rectangle_in_histogram
	{
		public int LargestRectangleArea(int[] heights) {
			int n = heights.Length;
			Stack<int> stack = new Stack<int>();

			int i=0; int maxArea = 0;
			while(i<n){
				if(stack.Count==0 || heights[i] >= heights[stack.Peek()]){
					stack.Push(i); ++i;
				}
				else{
					int x = stack.Pop();
					int wr = i-x-1;
					int wl = stack.Count > 0 ? x-stack.Peek() : x+1;
					int w = wr+wl;
					int area = heights[x] * w;
					maxArea = Math.Max(area,maxArea);
				}
			}

			while(stack.Count > 0){
				int x = stack.Pop();
				int wr = n-x-1;
				int wl = stack.Count > 0 ? x-stack.Peek() : x+1;
				int w = wr+wl;
				int h = heights[x];
				int area = heights[x] * w;
				maxArea = Math.Max(area,maxArea);
			}

			return maxArea;

		}
	}
}