using System;

// https://leetcode.com/discuss/interview-question/1850570/Meta-(Facebook)-or-Recruiting-Portal-Preparation-or-Encrypted-Words
// tags: encrypt

/*
 * You've devised a simple encryption method for alphabetic strings that shuffles the characters in such a way that the resulting string is hard to quickly read, but is easy to convert back into the original string.
When you encrypt a string S, you start with an initially-empty resulting string R and append characters to it as follows:

    Append the middle character of S (if S has even length, then we define the middle character as the left-most of the two central characters)
    Append the encrypted version of the substring of S that's to the left of the middle character (if non-empty)
    Append the encrypted version of the substring of S that's to the right of the middle character (if non-empty)

For example, to encrypt the string "abc", we first take "b", and then append the encrypted version of "a" (which is just "a") and the encrypted version of "c" (which is just "c") to get "bac".
If we encrypt "abcxcba" we'll get "xbacbca". That is, we take "x" and then append the encrypted version "abc" and then append the encrypted version of "cba".
*/

namespace _csharp
{
	public class _fb_oa_encrypted_words
	{
		public void solve(){
			Console.WriteLine(encrypt("facebook"));
		}

		private string encrypt(string s){
			int n = s.Length;
			if(n <= 2)
				return s;

			int mid = n % 2 == 0 ? (n / 2) - 1 : n / 2;
			return s [mid] + encrypt (s.Substring (0, mid)) + encrypt (s.Substring (mid + 1, n - mid - 1));
		}	
	}
}