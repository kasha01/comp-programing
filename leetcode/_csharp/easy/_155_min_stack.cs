using System;
using System.Collections.Generic;

// https://leetcode.com/problems/min-stack/
namespace _csharp
{
	public class _155_min_stack
	{
		public class MinStack {
			Stack<int[]> stack;

			public MinStack() {
				stack = new Stack<int[]>();
			}

			public void Push(int val) {
				int min = 0;
				if(stack.Count == 0)
					min = val;
				else
					min = Math.Min(stack.Peek()[1],val);

				stack.Push(new int[]{val,min});
			}

			public void Pop() {
				stack.Pop();
			}

			public int Top() {
				return stack.Peek()[0];
			}

			public int GetMin() {
				return stack.Peek()[1];
			}
		}
	}
}