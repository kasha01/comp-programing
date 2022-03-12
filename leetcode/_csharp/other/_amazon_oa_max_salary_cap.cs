using System;

// https://leetcode.com/discuss/interview-question/351313/Google-or-Phone-Screen-or-Salary-Adjustment
namespace _csharp
{
	public class _amazon_oa_max_salary_cap
	{
		public void solve(){
			var salaries = new int[]{100, 300, 200, 400};
			int budget = 800;
			int n = salaries.Length;

			Array.Sort (salaries);

			double remainingBudget = budget;
			int remainingSalariesCount = n;
			double cap = remainingBudget / remainingSalariesCount;

			int i = 0;
			while (i < n) {
				int x = salaries [i];

				if (x < cap) {
					// x is below the cap. exclude it.
					remainingBudget = remainingBudget - x;
					remainingSalariesCount = remainingSalariesCount - 1;
					cap = remainingBudget / remainingSalariesCount;
				} else {
					break;
				}

				++i;
			}

			Console.WriteLine ($"Maximum salary cap is: {cap}");
		}
	}
}

