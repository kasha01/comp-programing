using System;

// https://practice.geeksforgeeks.org/problems/count-number-of-words/0
namespace GeeksForGeeks_csharp
{
	public class count_number_of_words
	{
		public static void test ()
		{
			Console.WriteLine (solve ("\t \n \t \n asd  \tnhy \nhgf \twerdsff      \tdfd\nsgsgb   hg"));
		}

		static int solve(string s){
			int n = s.Length;
			int i = 0;
			bool start_word_counter = true;
			int count = 0;
			while (i < n) {
				char c = s [i];

				if (c == ' ') {
					start_word_counter = true;
					i++;
					continue;
				}

				if ((c == '\t') || (c == '\n')) {
					start_word_counter = true;
					//i = i + 1;
					i++;
					continue;
				}

				if (start_word_counter == true) {
					count++;
					start_word_counter = false;
				}

				++i;
			}
			return count;
		}
	}
}

