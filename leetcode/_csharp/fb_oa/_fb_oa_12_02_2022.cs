using System;

namespace _csharp
{
	public class _fb_oa_12_02_2022
	{
		public void query_diff(){
			var query = new string[] {"+2", "+2", "+4", "+3", "-2"};
			query_diff_inner (query);
		}

		private void query_diff_inner(string[] query){
			int n = query.Length;
			int[] ans = new int[n];

			int m = 109+109+1;
			var arr = new int[m];

			int sum = 0;
			for(int i=0;i<n;++i){
				string q = query [i];
				int x = Int16.Parse(q.Substring (1)) + 109;

				if (q [0] == '+') {
					arr [x]++;
					sum = getNewSum (x, sum, 1, m, arr);
				} else {
					sum = getNewSum (x, sum, -1, m, arr);
					arr [x] = 0;
				}

				ans [i] = sum;
			}

			for (int i = 0; i < n; ++i) {
				Console.Write (ans [i] + " ");
			}
		}

		private int getNewSum(int x, int sum, int mult, int m, int[] arr){
			if (x - 1 >= 0)
				sum = sum + (arr [x] * arr [x - 1] * mult);

			if (x + 1 < m)
				sum = sum + (arr [x] * arr [x + 1] * mult);

			return sum;
		}
	}
}