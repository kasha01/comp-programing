using System;
using System.Collections.Generic;

// https://leetcode.com/problems/baseball-game/
namespace _csharp
{
	public class _682_baseball_game
	{
		public int CalPoints(string[] ops) {
			Stack<int> stack = new Stack<int>();

			foreach(string c in ops){
				if(c=="+"){
					// pop 2 and sum
					int a = stack.Pop();
					int b = stack.Peek();
					stack.Push(a);
					stack.Push(a+b);
				}
				else if(c=="D"){
					int a = stack.Peek();
					stack.Push(a*2);
				}
				else if(c=="C"){
					stack.Pop();
				}
				else{
					stack.Push(Convert.ToInt32(c));
				}
			}

			int sum = 0;
			while(stack.Count > 0){
				Console.WriteLine(stack.Peek());
				sum = sum + stack.Pop();
			}

			return sum;
		}
	}
}