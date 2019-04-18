using System;

// https://practice.geeksforgeeks.org/problems/tic-tac-toe/0
namespace GeeksForGeeks_csharp
{
	public class tic_tac_toe
	{
		static bool iswin(char[,] tic, char c){
			return(
				(tic [0, 0] == c && tic [0, 1] == c && tic [0, 2] == c) ||
				(tic [1, 0] == c && tic [1, 1] == c && tic [1, 2] == c) ||
				(tic [2, 0] == c && tic [2, 1] == c && tic [2, 2] == c) ||

				(tic [0, 0] == c && tic [1, 0] == c && tic [2, 0] == c) ||
				(tic [0, 1] == c && tic [1, 1] == c && tic [2, 1] == c) ||
				(tic [0, 2] == c && tic [1, 2] == c && tic [2, 2] == c) ||

				(tic [0, 0] == c && tic [1, 1] == c && tic [2, 2] == c) ||
				(tic [0, 2] == c && tic [1, 1] == c && tic [2, 0] == c));
		}

		static bool solve(char[] arr){
			char[,] tic = new char[3, 3];

			int x_count = 0;
			int o_count = 0;
			int offset = 0;
			for (int i = 0; i < 3; ++i) {
				for (int j = 0; j < 3; ++j) {
					tic [i, j] = arr [j + offset];
					if (tic [i, j] == 'X') {
						x_count++;
					} else if (tic [i, j] == 'O') {
						o_count++;
					}
				}
				offset = offset + 3;
			}

			// testing
			if(o_count > x_count || x_count > o_count+1){
				return false;
			}

			//test win
			bool is_x_win = iswin(tic,'X');
			bool is_o_win = iswin(tic,'O');

			return (
				(is_x_win && !is_o_win && x_count==o_count+1) || 
				(is_o_win && !is_x_win && x_count==o_count) ||
				(!is_x_win && !is_o_win && x_count==o_count+1));
		}

		static void test(){
			char[] arr = {'X','X','O','O','O','X','X','O','X'};
			Console.WriteLine(solve (arr));
		}
	}
}