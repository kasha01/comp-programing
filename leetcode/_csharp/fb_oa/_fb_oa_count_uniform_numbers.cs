using System;

// https://leetcode.com/discuss/interview-question/1555073/Facebook-or-Phone-or-Count-uniform-numbers-in-range
namespace _csharp
{
	public class _fb_oa_count_uniform_numbers
	{
		public void solve(){
			int x = 1; int y = 11; int cnt = 0;
			string x_string = x.ToString();

			// edge case for single digits
			while(x<10 && x<=y){
				Console.WriteLine (x); ++x;
				cnt++;
			}

			int digit_max_length = x_string.Length - 1;
			int c = x_string [0] - '0';
			int sum = 0;
			while (sum <= y) {
				sum = 0;
				int l = digit_max_length;
				while (l >= 0) {
					sum = sum * 10 + c;
					--l;
				}

				if (sum <= y && sum>=x) {
					Console.WriteLine (sum);
					++cnt;
				}

				++c;
				if (c == 10) {
					digit_max_length++;
					c = 1;
				}
			}

			Console.WriteLine ("Count is: " + cnt);
		}
	}
}