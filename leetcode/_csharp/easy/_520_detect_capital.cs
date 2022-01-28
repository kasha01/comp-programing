using System;

// https://leetcode.com/problems/detect-capital/
namespace _csharp
{
	public class _520_detect_capital
	{
		public bool DetectCapitalUse(string word) {
			if(word.Length==1) return true;

			char a = word[0];
			int ascii = a - 'A';
			bool isFirstLetterCaps = ascii>=0 && ascii<=25;

			char b = word[1];
			int ascii_2 = b - 'A';
			bool isSecondLetterCaps = ascii_2>=0 && ascii_2<=25;

			if(!isFirstLetterCaps && isSecondLetterCaps) return false;

			bool nextLettersMustBeCaps = isFirstLetterCaps && isSecondLetterCaps;

			for(int i=2;i<word.Length;++i){
				int ca = word[i] - 'A';
				bool isLetterCaps = ca>=0 && ca<=25;
				if((nextLettersMustBeCaps && !isLetterCaps) || (!nextLettersMustBeCaps && isLetterCaps)) 
					return false;                
			}

			return true;
		}
	}
}