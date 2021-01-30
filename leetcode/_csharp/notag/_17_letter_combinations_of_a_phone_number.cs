using System;
using System.Collections.Generic;

// https://leetcode.com/problems/letter-combinations-of-a-phone-number/
namespace _csharp
{
	public class _17_letter_combinations_of_a_phone_number
	{

		List<List<string>> map = new List<List<string>>(){
			new List<string>(){" "},
			new List<string>(){""},
			new List<string>(){"a","b","c"},
			new List<string>(){"d","e","f"},
			new List<string>(){"g","h","i"},
			new List<string>(){"j","k","l"},
			new List<string>(){"m","n","o"},
			new List<string>(){"p","q","r","s"},
			new List<string>(){"t","u","v"},
			new List<string>(){"w","x","y","z"}        
		};

		public IList<string> LetterCombinations(string digits) {
			return rc(digits,0);
		}

		List<string> rc(string digits, int start){
			if(start == digits.Length)
				return new List<string>();

			int digit = (int)digits[start] - 48;
			List<string> listOfDigits = map[digit];

			List<string> myResult = new List<string>();

			List<string> result = rc(digits,start+1);

			if(result.Count == 0){
				return listOfDigits; 
			}

			foreach(string s in listOfDigits){
				for(int i=0;i<result.Count;++i){
					myResult.Add(s + result[i]); 
				}    
			}    

			return myResult;
		}
	}
}

