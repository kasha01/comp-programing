using System;
using System.Text;

// https://leetcode.com/discuss/interview-question/1612730/Facebook-Enterprise-Engineer-PhoneScreening-Interview-Dec-2021-Amsterdam
namespace _csharp
{
	// calculate arithmetic expression with O(1) space
	public class _fb_oa_math_expression_O_1
	{
		int i = 0;
		public int Calculate(string s) {
			// get ride of all the space
			s = s.Trim();
			int j=0; StringBuilder sb = new StringBuilder();
			foreach(char c in s){
				if(c != ' '){
					sb.Append(c);
				}
			}

			string exp = sb.ToString();
			int n = exp.Length;

			int prevOprand = scanNum (n, exp);
			int total = prevOprand;
			while (i < n) {
				var op = exp [i];

				if (op == '+' || op == '-') {
					++i;
					int secondOperand = scanNum (n, exp);
					prevOprand = op == '+' ? secondOperand : secondOperand*(-1);

					if(op == '+')
						total = total + secondOperand;
					else
						total = total - secondOperand;
				} else if (op == '*' || op == '/') {
					total = (total - prevOprand) + scanMultiply (n, exp, prevOprand);
				}
			}

			return total;
		}

		// starts with operator and ends with i on next operator
		private int scanMultiply(int n, string exp, int operand){
			int total_mult = operand;
			while (i < n && (exp[i] == '*' || exp[i] == '/')) {
				char op = exp[i];
				++i;
				int secondOperand = scanNum (n, exp);
				total_mult = op == '*' ? total_mult * secondOperand : total_mult / secondOperand ;
			}

			return total_mult;
		}

		// scanNum: starts with a digit, ends with i at next operator
		private int scanNum(int n ,string exp){
			int operand = 0;
			while (i < n && exp[i] >= '0' && exp[i] <= '9') {
				operand = operand * 10 + (exp [i] - '0');
				++i;
			}

			return operand;		
		}

		/*********************************************************************************************************************/

		// using split
		public void solve_with_split(string exp){
			int n = exp.Length;

			int total = 0;
			string[] arr_plus = exp.Split ('+');
			foreach (string s in arr_plus) {
				if (s.Contains ("*")) {
					// this is a multiplication sub-expression
					var arr_mult = s.Split('*');
					int m = 1;
					foreach (string x in arr_mult) {
						m = m * parseNum (x);
					}
					total = total + m;
				} else {
					total = total + parseNum (s);					
				}
			}

			Console.WriteLine (total);
		}

		private int parseNum(string s){
			int t = 0; int n = s.Length; int j = 0;
			while (j < n && s[j] >= '0' && s[j] <= '9') {
				t = t * 10 + (s [j] - '0');
				++j;
			}
			return t;		
		}
	}
}