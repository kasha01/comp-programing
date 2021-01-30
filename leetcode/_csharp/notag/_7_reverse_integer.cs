using System;

// https://leetcode.com/problems/reverse-integer/
namespace _csharp
{
	public class _7_reverse_integer
	{
		public int Reverse(int x) {
			if(x==0)
				return 0;

			int sign = 1;
			if(x < 0){
				sign = -1;
			}

			int sum = 0;
			int multiplier=1;
			int divider = 1000000000;

			while(divider > 0){
				int r = x / divider;
				if(!(sum==0 && r==0)){
					x = x - (r*divider);

					if(multiplier == 1000000000 && Math.Abs(r) > 2){
						return 0;
					}

					int m = r * multiplier;
					if(sign == -1){
						// negative
						if(m < -2147483648-sum)
							return 0;
					}

					if(sign == 1 && m > 2147483647-sum){
						return 0;
					}

					sum = sum + m;                
					multiplier = multiplier*10;
				}

				divider = divider / 10;
			}

			return sum;
		}
	}
}

