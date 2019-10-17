using System;

// https://practice.geeksforgeeks.org/problems/digit-multiplier/0
namespace GeeksForGeeks_csharp
{
	public class Digit_multiplier
	{
		private static void append_factor(int[] factors, int e){
			switch(e){
			case 2:
				factors[0]++;
				break;
			case 3:
				factors[1]++;
				break;
			case 5:
				factors[2]++;
				break;
			case 7:
				factors[3]++;
				break;						
			}
		}

		private static int[] compress_factors_into_digits (int[] factors){
			// trying to consolidate the prime factors into a single digit.

			// my digits array holds the digit counts as follows:
			// array index: 	0, 1, 2, 3, 4, 5, 6, 7
			// count of digit:	2, 3, 4, 5, 6, 7, 8, 9	
			int[] digits = new int[8];

			// can i have a 9 -> 2 (digit 3)
			while(true){
				if(factors[1]>=2){
					factors[1] = factors[1] - 2;	// i have 2 counts of digit 3
					digits[7]++;
				}
				else{
					break;
				}
			}

			// can i have a 8 -> 3 (digit 2)
			while(true){
				if(factors[0]>=3){
					factors[0] = factors[0] - 3;	// i have 3 counts of digit 3
					digits[6]++;
				}
				else{
					break;
				}
			}

			// can i have a 7 -> 1 (digit 7)
			while(true){
				if(factors[3]>=1){
					factors[3] = factors[3] - 1;	// i have 1 count of digit 7
					digits[5]++;
				}
				else{
					break;
				}
			}

			// can i have a 6 -> 1 count of digit 2&3. (3x2)
			while(true){
				if(factors[0]>=1 && factors[1]>=1){
					factors[0] = --factors[0];
					factors[1] = --factors[1];
					digits[4]++;
				}
				else{
					break;
				}
			}

			// can i have a 5 -> 1 count of digit 5
			while(true){
				if(factors[2]>=1){
					factors[2] = --factors[2];
					digits[3]++;
				}
				else{
					break;
				}
			}

			// can i have a 4 -> 2 counts of digit 2
			while(true){
				if(factors[0]>=2){
					factors[0] = factors[0]- 2;
					digits[2]++;
				}
				else{
					break;
				}
			}

			// can i have a 3 -> 1 count of digit 3.
			while(true){
				if(factors[1]>=1){
					factors[1] = --factors[1];
					digits[1]++;
				}
				else{
					break;
				}
			}

			// can i have a 2 -> 1 count of digit 2.
			while(true){
				if(factors[0]>=1){
					factors[0] = --factors[0];
					digits[0]++;
				}
				else{
					break;
				}
			}

			return digits;
		}

		static string solve(long n){
			// special case - if number is 1 digit
			if (n < 10) {
				return n.ToString();
			}

			// factors index mapping is as follows:
			// array index	 	: 0, 1, 2, 3
			// factors count	: 2, 3, 5, 7
			int[] factors = new int[4];
			int[] f = { 2, 3, 5, 7};
			int i = 0;

			// start factoring n
			while (n > 1) {
				if (i >= f.Length) {
					// one of the number factors is a prime number greater than 9
					return "-1";
				}

				int x = f [i];
				if (n % x == 0) {
					n = n / x;
					append_factor(factors,x);
				} else {
					i++;	// divide by the next prime factor {2,3,5,7}
				}
			}
			//end factoring

			// Maximize the digits i can form number (n) with
			int[] digits = compress_factors_into_digits(factors);

			string result = "";
			for(int k=digits.Length-1;k>=0;--k){
				int digit = k+2;
				while (digits [k] > 0) {					
					result = digit + result;
					digits [k]--;
				}
			}

			return result;
		}

		public static void test ()
		{
			string res = solve (26460);
			Console.WriteLine (res);
		}
	}
}

