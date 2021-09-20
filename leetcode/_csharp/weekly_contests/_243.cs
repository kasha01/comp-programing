using System;

// https://leetcode.com/contest/weekly-contest-243
namespace _csharp
{
	public class _243
	{
		public static bool IsSumEqual(string firstWord, string secondWord, string targetWord) {

			int sumFirstWord=0; int sumSecondWord=0; int sumTargetWord=0;
			int m1 = 1; int m2 = 1; int m3 = 1;
			for(int i=7;i>=0;--i){
				if(firstWord.Length-1 >= i){
					int a = firstWord[i]-'a'; sumFirstWord=sumFirstWord+a*m1;
					m1 = m1 * 10;
				}

				if(secondWord.Length-1 >= i){
					int a = secondWord[i]-'a'; sumSecondWord=sumSecondWord+a*m2;                
					m2 = m2 * 10;
				}

				if(targetWord.Length-1 >= i){
					int a = targetWord[i]-'a'; sumTargetWord=sumTargetWord+a*m3;
					m3 = m3 * 10;
				}
			}

			return sumFirstWord + sumSecondWord == sumTargetWord;
		}
	}
}