using System;

// https://leetcode.com/discuss/interview-question/1474282/Amazon-OA
namespace _csharp
{
	public class _amazon_oa_alphabet_encryption_wheel
	{
		public void solve(){
			var wheel = new char[]{'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
			string ss = "VTAOG"; int k = 2;
			for (int i = 0; i < ss.Length; ++i) {
				int a = ss [i] - 'A';
				int n = 26;
				char c = Convert.ToChar (((a + n - k) % n) + 'A');
				Console.Write (c);
			}
		}
	}
}

