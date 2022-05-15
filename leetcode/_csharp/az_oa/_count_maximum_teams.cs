using System;

// https://leetcode.com/discuss/interview-question/1594880/Amazon-OA-questions-countMaximumTeams
// NOT MY SOLUTION - THANKS TO TRIMMINGTREE ON LEETCODE
namespace _csharp
{
	public class _count_maximum_teams
	{
		/*
		 * I got Amazon questions countMaximumTeams. Given an skill array example - [3,4,3,1,6,5] and teamSize = 3 and maxDiff =2. Output =2.
		 * The same dev cannot be in two different teams
		*/
		private static void fn(){
			int teamSize = 3; int maxDiff = 2; int answer = 0;
			int[] arr = { 3, 4, 2, 1, 6, 5 }; 

			Array.Sort (arr);

			int i = 0;
			while (i <= (arr.Length - teamSize)){
				if(arr[i+teamSize-1] - arr[i] <= maxDiff){
					answer += 1;
					i += teamSize;
				}					
				else
					i += 1;
			}

			Console.WriteLine (answer);
		}
	}
}

