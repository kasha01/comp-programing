using System;

// https://practice.geeksforgeeks.org/problems/possible-groups/0
namespace GeeksForGeeks_csharp
{
	public class Possible_groups
	{
		public static void solve ()
		{
			long n = 42;
			long[] arr = {68,35,1,70,25,79,59,63,65,6,46,82,28,62,92,96,43,28,37,92,5,3,54,93,83,22,17,19,96,48,27,72,39,70,13,68,100,36,95,4,12,23};

			long count_numbers_with_mod_0 = 0;
			long count_numbers_with_mod_1 = 0;
			long count_numbers_with_mod_2 = 0;
			for (long i = 0; i < n; ++i) {
				long m = arr [i] % 3;
				if (m == 0) {
					count_numbers_with_mod_0++;
				} else if (m == 1) {
					count_numbers_with_mod_1++;
				} else if (m == 2) {
					count_numbers_with_mod_2++;
				}
			}

			// count number of groups with two numbers, formed by two numbers that are both multiples of 3
			// (i.e. x%3=0) => count combinations of 2 numbers that their mod%3=0
			long groups_of_2 = 0;

			// count number of groups with three numbers, formed by three numbers that are all multiples of 3
			// (i.e. x%3=0) => count combinations of 3 numbers that their mod%3=0
			long groups_of_3 = 0;

			if (count_numbers_with_mod_0 == 1) {
				groups_of_2 = 0;
				groups_of_3 = 0;
			} else if (count_numbers_with_mod_0 == 2) {
				groups_of_2 = 1;
				groups_of_3 = 0;
			} else if (count_numbers_with_mod_0 > 2) {
				// combination of n with r=2(groups of 2) = ((n)*(n-1))/r! = ((n)*(n-1))/2!
				groups_of_2 = (count_numbers_with_mod_0 * (count_numbers_with_mod_0 - 1))/2;
				// combination of n with r=3(groups of 3) = ((n)*(n-1)*(n-2))/r! = ((n)*(n-1)*(n-2))/3!
				groups_of_3 = (count_numbers_with_mod_0 * (count_numbers_with_mod_0 - 1) * (count_numbers_with_mod_0 - 2))/6;
			}

			// count of number of groups with two numbers, where the summation of their mods = 3;
			// if the summation of the mods of numbers = 3, then the sum of the actual numbers is a multiple of 3.
			// if i have x numbers with their mod%3=1; and y numbers with their mod%3=2; total count of groups I can
			// form is x * y
			long groups_of_2_m=count_numbers_with_mod_1*count_numbers_with_mod_2;

			// count of numbers of groups with 3 numbers, two numbers have a sum of mods = 3, and the third number
			// has a mod of 0 (basically it is a multiple of 3).
			// So I will have a+b+c. where (a%3 + b%3)=3, and c%3=0. so the sum of mods = 3+0=3. so the sum of the 
			// actual numbers (a+b+c) would be a multiple of 3.
			// total numbers of groups I can form is, count of groups of {2} with their mod summation = 3 * count of 
			// numbers with their mod%3=0
			long groups_of_3_m = groups_of_2_m*count_numbers_with_mod_0;

			// represent count of groups with 3 numbers, where all numbers have a mod%3=1;
			// so their mod sum will be 1+1+1 = 3; which yield a multiple of 3 number. we need to count the combination
			// of such groups
			long groups_of_3_all_mod_1 = 0;
			if (count_numbers_with_mod_1 > 2) {
				groups_of_3_all_mod_1 = (count_numbers_with_mod_1 * (count_numbers_with_mod_1 - 1) * (count_numbers_with_mod_1 - 2))/6;
			}

			// represent count of groups with 3 numbers, where all numbers have a mod%3=2;
			// so their mod sum will be 2+2+2 = 3; which yield a multiple of 3 number. we need to count the combination
			// of such groups
			long groups_of_3_all_mod_2 = 0;
			if (count_numbers_with_mod_2 > 2) {
				groups_of_3_all_mod_2 = (count_numbers_with_mod_2 * (count_numbers_with_mod_2 - 1) * (count_numbers_with_mod_2 - 2))/6;
			}

			long total = groups_of_2 + groups_of_3 + groups_of_2_m + groups_of_3_m + groups_of_3_all_mod_1 + groups_of_3_all_mod_2;

			Console.WriteLine (total);
		}
	}
}

