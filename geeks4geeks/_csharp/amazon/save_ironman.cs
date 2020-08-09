using System;

// https://practice.geeksforgeeks.org/problems/save-ironman/0
namespace GeeksForGeeks_csharp
{
	public class save_ironman
	{
		static bool alphaNumericalExist = false; // to count for edge case if all characters were not letters or numbers
		
		public static void test ()
		{
			Console.WriteLine (solve("%A?/Ba"));
		}

		static bool solve(string s){
			int i = 0; int j = s.Length - 1;
			while(i<=j) {
				int a = s [i] + 0;
				int b = s [j] + 0;

				while ( (i<= j) && i<s.Length-1 && !isAlphaNumerical(a)) {
					i++;
					a = s [i] + 0;
				}

				while ( (i<= j) && j>0 && !isAlphaNumerical(b)) {
					j--;
					b = s [j] + 0;
				}

				if (isAlphaNumerical(a) && isAlphaNumerical(b)) {
					string ci = s [i].ToString ().ToLower();
					string cj = s [j].ToString ().ToLower();

					if(ci!=cj)
						return false;
				}
				i++;
				j--;
			}
			if (alphaNumericalExist)
				return true;
			else
				return false;
		}

		static bool isAlphaNumerical(int x){
			bool alpnaNum = (x >= 48 && x <= 57) || (x >= 65 && x <= 90) || (x >= 97 && x <= 122);
			alphaNumericalExist = alphaNumericalExist || alpnaNum;
			return alpnaNum;
		}
	}
}

