using System;

namespace _csharp
{
	/*
	abcd / 100 ==> ab
	abcd % 100 ==> cd
	*/

	// https://leetcode.com/problems/palindrome-number/
	public class _9_palindrome_number
	{
		public bool IsPalindrome(int x) {
			if(x<0)
				return false;

			if(x==0 || x<10)
				return true;

			int lastPower = (int)Math.Log10(x);
			int numberOfDigits = lastPower+1;    
			int c = numberOfDigits/2;

			int rightMod=10;
			int rightDiv=1;

			int leftDiv= (int)Math.Pow(10, lastPower);

			while(c>0){
				c--;

				int digitRight = (x%rightMod)/rightDiv;
				int digitLeft = (x/leftDiv)%10;

				if(digitRight!=digitLeft)
					return false;

				rightMod = rightMod*10;
				rightDiv = rightDiv*10;
				leftDiv=leftDiv/10;
			}

			return true;
		}
	}
}

