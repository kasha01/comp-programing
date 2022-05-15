using System;
using System.Collections.Generic;

// https://leetcode.com/discuss/interview-question/380650/Bloomberg-or-Phone-Screen-or-Candy-Crush-1D

// For the follow up s="aaabbbacd" -> "cd". I think we use dynamic programing. we have choices either keep element with consec count >=3 or remove it
// and solve recurssively.

/*
 * Write a function to crush candy in one dimensional board. In candy crushing games, groups of like items are removed from the board.
 * In this problem, any sequence of 3 or more like items should be removed and any items adjacent to that sequence should now be considered adjacent 
 * to each other. This process should be repeated as many time as possible. You should greedily remove characters from left to right.
*/
namespace _csharp
{
	public class _fb_oa_candy_crush
	{
		class Node{
			public char c { get; set; }
			public int cnt { get; set; }

			public Node(char c, int n){
				this.c = c;
				this.cnt = n;
			}
		}

		public void solve(string s){
			var stack = new Stack<Node> ();

			int i = 0;
			while (i < s.Length) {
				char c = s [i];
				if (stack.Count > 0 && c != stack.Peek ().c && stack.Peek ().cnt >= 3) {
					// I can pop
					stack.Pop ();
				}

				pushToStack (stack, c);

				++i;
			}

			// check end
			if(stack.Count > 0 && stack.Peek ().cnt >= 3){
				stack.Pop ();
			}

			string ans = "";
			while (stack.Count > 0) {
				ans = stack.Pop ().c + ans;
			}

			Console.WriteLine (ans);
		}

		private void pushToStack(Stack<Node> stack, char c){
			if (stack.Count == 0) {
				stack.Push (new Node (c, 1));
				return;
			} 

			var top = stack.Peek ();
			if (c == top.c) {
				top.cnt++;
			} else {
				stack.Push (new Node (c, 1));
			}
		}
	}
}

