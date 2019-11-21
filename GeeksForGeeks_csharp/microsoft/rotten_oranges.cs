using System;
using System.Collections.Generic;

// https://practice.geeksforgeeks.org/problems/rotten-oranges/0
namespace GeeksForGeeks_csharp
{
	public class rotten_oranges
	{
		static void example ()
		{
			int r = 3; int c = 5;
			//int[,] matrix = new int[r, c];
			//int[] items = {"2","1","0","2","1","1","0","1","2","1","1","0","0","2","1"};
			//solve(r,c,items);
		}

		// r: rows count, c:columns count, items: oranges
		public static void solve(int r, int c, string[] items){
			int[,] matrix = new int[r, c];
			int total = r * c;
			int rottens = 0;
			int empty = 0;
			int offset=0;

			Queue<KeyValuePair<int,int>> queue = new Queue<KeyValuePair<int, int>> ();
			for (int i = 0; i < r; i++) {
				for (int j = 0; j < c; j++) {
					matrix[i,j] = Int32.Parse(items[offset+j]);

					if (matrix [i, j] == 2) {
						rottens++;
						queue.Enqueue (new KeyValuePair<int, int> (i, j));
					} else if (matrix [i, j] == 0) {
						empty++;
					}
				}
				offset = offset+c;
			}

			int counter = 0;
			bool end_program = false;
			int fresh = total - rottens - empty;
			while (fresh > 0 && rottens>0 && !end_program) {
				int n = queue.Count;
				if(n==0){
					break;
				}

				bool did_rotten = false;
				for (int i = 0; i < n; ++i) {
					if (fresh <= 0) {
						end_program = true;
						break;
					}

					KeyValuePair<int,int> cell = queue.Dequeue ();
					int x = cell.Key; int y = cell.Value;

					// left
					if(y-1 >=0 && matrix[x,y-1] == 1){
						did_rotten = true;
						matrix [x, y - 1] = 2;
						queue.Enqueue (new KeyValuePair<int, int> (x,y-1));
						fresh--;
					}
					// right
					if(y+1 <c && matrix[x,y+1] == 1){
						did_rotten = true;
						matrix [x, y + 1] = 2;
						queue.Enqueue (new KeyValuePair<int, int> (x,y+1));
						fresh--;
					}
					// up
					if(x-1 >=0 && matrix[x-1,y] == 1){
						did_rotten = true;
						matrix [x-1, y] = 2;
						queue.Enqueue (new KeyValuePair<int, int> (x-1,y));
						fresh--;
					}
					// down
					if(x+1 <r && matrix[x+1,y] == 1){
						did_rotten = true;
						matrix [x+1, y] = 2;
						queue.Enqueue (new KeyValuePair<int, int> (x+1,y));
						fresh--;
					}
				}

				if (did_rotten) {
					counter++;
				}
			}

			if(counter == 0 || fresh >0){
				Console.WriteLine (-1);
			}
			else{
				Console.WriteLine (counter);
			}
		}
	}
}

