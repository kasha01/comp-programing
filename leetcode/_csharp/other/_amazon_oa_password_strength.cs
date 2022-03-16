using System;

namespace _csharp
{
	// https://leetcode.com/discuss/interview-question/1471459/amazon-oa
	public class _amazon_oa_password_strength
	{
		/*
		 * Find the password strength.
		For each substring of the password which contains at least one vowel and one consonant, its strength goes up by 1.
		vowels={'a', 'e', 'i', 'o', 'u'}, and rest of letters are all consonant.
		(Only lower alphabet letters)
		*/
		public void getPasswordStrength(){
			string password = "thisisbeautiful";
			int vowel=0;
			int consonent = 0;
			int res = 0;
			foreach (char c in password) {
				if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u') {
					vowel++;
				} else {
					consonent++;
				}
				if (vowel >= 1 && consonent >= 1) {
					res++;
					vowel = 0;
					consonent = 0;
				}
			}

			Console.WriteLine (res);
		}

		public void Sort_1_and_0(){
			var arr = new int[]{0,0,0,0,1,0,1,0,0};

			Console.WriteLine (Math.Min (countMoves (arr, 1), countMoves (arr, 0)));
		}

		private int countMoves(int[] arr, int target){
			int moves=0; int ptr=0;
			for (int i = 0; i < arr.Length; ++i) {
				if (arr [i] == target) {
					moves = moves + (i - ptr);
					++ptr;
				}
			}

			return moves;
		}
	}
}

