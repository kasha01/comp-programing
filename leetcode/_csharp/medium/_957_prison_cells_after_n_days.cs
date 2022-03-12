using System.Linq;
using System;
using System.Collections.Generic;

// https://leetcode.com/problems/prison-cells-after-n-days/submissions/
namespace _csharp
{
	public class _957_prison_cells_after_n_days
	{
		public int[] PrisonAfterNDays(int[] cells, int n) {
			int m = cells.Length;
			var current = new int[m];
			var first_cycle = new int[m];
			var next = new int[m];
			int days = n;

			// I didn't want to modify the input array
			Array.Copy(cells,current,m);

			// first cycle
			for(int i=1;i<m-1;++i){
				next[i] = current[i-1] == current[i+1] ? 1 : 0;
			}

			--days;
			if(days==0) return next;   // if days are 0 so I just needed one cycle. return next.

			Array.Copy(next,first_cycle,m);

			// I already have one cycle. so start counting from 1
			for(int cycles=1; days>0; ++cycles){
				--days;
				Array.Copy(next,current,m);

				for(int i=1;i<m-1;++i){
					next[i] = current[i-1] == current[i+1] ? 1 : 0;
				}

				// I hit a full cycle. so mod days will get me the remaining days out of x cycles.
				if(first_cycle.SequenceEqual(next))
					days=days%cycles;
			}

			return next;        
		}
	}
}