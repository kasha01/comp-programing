using System;
using System.Collections.Generic;

// https://www.geeksforgeeks.org/sort-a-stack-using-recursion/
namespace misc
{
	public class sort_a_stack_using_recursion
	{
		static Stack<int> mystack = new Stack<int>();
		public static void driver ()
		{
			mystack.Push (30);
			mystack.Push (-5);
			mystack.Push (18);
			mystack.Push (14);
			mystack.Push (-3);

			rc ();

			foreach (int i in mystack) {
				Console.WriteLine (i);
			}
		}

		static void rc(){
			if (mystack.Count == 0)
				return;

			int x = mystack.Pop ();
			rc ();
			sort_rc (x);
		}

		static void sort_rc(int x){
			if (mystack.Count == 0) {
				mystack.Push (x);
			} else {
				if (x >= mystack.Peek()) {
					mystack.Push (x);
				} else {
					int y = mystack.Pop ();
					sort_rc (x);
					mystack.Push (y);
				}
			}
		}
	}
}

