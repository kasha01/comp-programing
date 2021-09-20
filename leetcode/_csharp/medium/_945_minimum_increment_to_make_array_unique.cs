using System;

// https://leetcode.com/problems/minimum-increment-to-make-array-unique/
namespace _csharp
{
	public class _945_minimum_increment_to_make_array_unique
	{
		public int MinIncrementForUnique(int[] A) {

			// this would ensure that (lastInput+1) would always be the least available number x can increment to
			Array.Sort(A);

			int lastInput = -1;
			int c=0;
			foreach(int x in A){
				if(x <= lastInput){
					lastInput = lastInput + 1;
					c = c + (lastInput-x);
				}
				else{
					lastInput = x;
				}
			}

			return c;
		}
	}
}

