using System;

// https://leetcode.com/problems/count-all-possible-routes/

/* It is giving me TLE when tried it with C#, but with C++, same logic passes! */
namespace _csharp
{
	public class _1575_count_all_possible_routes
	{
		public int CountRoutes(int[] locations, int start, int finish, int fuel) {
			int[,] memo = new int[locations.Length, fuel+1];
			return rc(start, fuel, locations, finish, memo) % 1000000007;
		}

		private int rc(int prev, int fuelLeft, int[] locations, int finish, int[,] memo){
			if(fuelLeft<0)
				return 0;        

			if(prev==finish && fuelLeft==0){
				memo[prev,fuelLeft] = 1;
				return 1;
			}

			if(fuelLeft==0){
				memo[prev,fuelLeft] = 0;
				return 0;
			}

			if(memo[prev, fuelLeft]==-1)
				return 0;

			if(memo[prev, fuelLeft] > 0)
				return memo[prev, fuelLeft];

			int sum = prev == finish ? 1 : 0;
			for(int j=0;j<locations.Length;++j){
				if(j==prev)
					continue;

				int fuelForTrip = Math.Abs(locations[j] - locations[prev]);

				if(fuelLeft-fuelForTrip < 0){
					memo[prev, fuelLeft] = -1;
					continue;
				}

				sum = (sum%1000000007) + rc(j, fuelLeft- fuelForTrip, locations, finish, memo);
			}

			memo[prev, fuelLeft] = sum % 1000000007;
			return memo[prev, fuelLeft];
		}
	}
}

