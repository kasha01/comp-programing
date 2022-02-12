using System;
using System.Collections.Generic;

// https://leetcode.com/problems/asteroid-collision/
namespace _csharp
{
	public class _735_asteroid_collision
	{
		public int[] AsteroidCollision(int[] asteroids) {
			Stack<int> right = new Stack<int>();
			Stack<int> left = new Stack<int>();
			List<int> ans = new List<int>();

			int i=0;
			while(i<asteroids.Length){
				int x = asteroids[i];

				if(x>0)
					right.Push(x);
				else
					left.Push(x*-1);

				while(left.Count>0 && right.Count>0){
					int l = left.Peek(); int r = right.Peek();

					if(l>r){
						right.Pop();
					}
					else if(l<r){
						left.Pop();
					}
					else{
						left.Pop();
						right.Pop();
					}
				}

				// pop left-wards asteroids as they are passed and will never collide with right asteroids 
				while(left.Count>0){
					ans.Add(left.Pop() * -1);
				}

				++i;
			}

			// pop remaining right asteroids in reverse order.
			int k = right.Count-1;
			int[] temp = new int[right.Count];
			while(right.Count>0){
				temp[k] = right.Pop();
				--k;
			}

			foreach(int t in temp){
				ans.Add(t);
			}

			return ans.ToArray();
		}
	}
}