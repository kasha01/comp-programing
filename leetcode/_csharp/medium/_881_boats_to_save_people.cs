using System;

// https://leetcode.com/problems/boats-to-save-people/
namespace _csharp
{
	public class _881_boats_to_save_people
	{
		public int NumRescueBoats(int[] people, int limit) {
			int n = people.Length;

			Array.Sort(people);

			int sum = 0;
			int i=0; int j=n-1;
			while(i<j){
				int s = people[i] + people[j];
				if(s <= limit){
					++i; --j; ++sum;
				}
				else{
					--j; ++ sum;
				}
			}

			if(i==j){
				++sum;
			}

			return sum;
		}
	}
}

