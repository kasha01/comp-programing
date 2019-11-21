using System;

// https://practice.geeksforgeeks.org/problems/does-robot-moves-circular/0
namespace GeeksForGeeks_csharp
{
	public class does_robot_moves_circular
	{
		static void test ()
		{
			string s = "GGGGL";
			bool result = solve (s);
			string res = result ? "Circular" : "Not Circular";
			Console.WriteLine (res);
		}

		static char getDirection(char direction, char rotate){
			if (direction == 'U') {
				if (rotate == 'L')
					return 'L';
				else if (rotate == 'R')
					return 'R';
			}

			if (direction == 'L') {
				if (rotate == 'L')
					return 'D';
				else if (rotate == 'R')
					return 'U';
			}

			if (direction == 'D') {
				if (rotate == 'L')
					return 'R';
				else if (rotate == 'R')
					return 'L';
			}

			if (direction == 'R') {
				if (rotate == 'L')
					return 'U';
				else if (rotate == 'R')
					return 'D';
			}

			return 'U';
		}

		static bool solve(string s){
			int x = 0; int y = 0;
			char d = 'U';

			int n = s.Length;
			for (int i = 0; i < n; ++i) {
				if (s[i] == 'G') {
					// moving
					if (d == 'U') {
						++y;
					} else if (d == 'D') {
						--y;
					} else if (d == 'R') {
						++x;
					} else if (d == 'L') {
						--x;
					}
				} else if (s[i] != 'G') {
					// rotating
					d = getDirection(d,s[i]);
				}
			}

			return x == 0 && y == 0;
		}
	}
}

