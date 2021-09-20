using System;
using System.Collections.Generic;

// https://leetcode.com/problems/open-the-lock/
namespace _csharp
{
	public class _752_open_the_lock
	{
		public int OpenLock(string[] deadends, string target) {
			HashSet<string> visited = new HashSet<string>();
			HashSet<string> dead = new HashSet<string>();
			foreach(string d in deadends){
				dead.Add(d);
			}

			if(dead.Contains("0000"))
				return -1;

			Queue<string> qu = new Queue<string>();
			int distance = 0;
			qu.Enqueue("0000");
			visited.Add("0000");

			while(qu.Count > 0){
				int n = qu.Count;
				while(n>0){
					--n;
					string x = qu.Dequeue();                

					if(x == target)
						return distance;

					for(int i=0;i<4;++i){
						int xi =  (x [i] - '0' + 1)%10;
						int xd =  (x [i] - '0' + 9)%10;
						string x_increment = x.Substring (0, i) + xi.ToString() + x.Substring (i + 1, x.Length - i - 1);
						string x_decrement = x.Substring (0, i) + xd.ToString() + x.Substring (i + 1, x.Length - i - 1);

						if(!dead.Contains(x_increment) && !visited.Contains(x_increment)){
							visited.Add(x_increment);
							qu.Enqueue(x_increment);
						}

						if(!dead.Contains(x_decrement) && !visited.Contains(x_decrement)){
							visited.Add(x_decrement);
							qu.Enqueue(x_decrement);
						}
					}
				}
				// end of chunk of queue representing a level in BFS.
				++distance;
			}

			return -1;
		}
	}
}

