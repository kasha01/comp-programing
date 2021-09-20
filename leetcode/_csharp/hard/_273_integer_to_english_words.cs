using System;

// https://leetcode.com/problems/integer-to-english-words/
namespace _csharp
{
	public class _273_integer_to_english_words
	{
		public string NumberToWords(int num) {
			if(num == 0) return "Zero";

			return fn(num).Trim();
		}

		string[] tens = {"","One","Two","Three","Four","Five","Six","Seven","Eight","Nine","Ten"};
		string[] teens = {"", "Eleven","Twelve","Thirteen","Fourteen","Fifteen","Sixteen","Seventeen","Eighteen","Nineteen"};
		string[] gt_teens = {"", "", "Twenty","Thirty","Forty","Fifty","Sixty","Seventy","Eighty","Ninety"};

		private string fn(int num){
			if(num == 0) return "";

			if(num>0 && num <=10) return tens[num];

			if(num >10 && num <20) return teens[num%10];

			if(num >= 20 && num <100) return gt_teens[num/10] + " " + fn(num%10).Trim();

			if(num >=100 && num<1000) return tens[num/100] + " Hundred " + fn(num%100).Trim();

			if(num >=1000 && num<10000) return tens[num/1000] + " Thousand " + fn(num%1000).Trim();

			if(num >=10000 && num<1000000) return fn(num/1000).Trim() + " Thousand " + fn(num%1000).Trim();

			if(num >=1000000 && num<1000000000) return fn(num/1000000).Trim() + " Million " + fn(num%1000000).Trim();

			return tens[num/1000000000] + " Billion " + fn(num%1000000000).Trim();
		}
	}
}