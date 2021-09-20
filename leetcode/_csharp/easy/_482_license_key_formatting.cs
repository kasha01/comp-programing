using System;

// https://leetcode.com/problems/license-key-formatting/
namespace _csharp
{
	public class _482_license_key_formatting
	{
		public string LicenseKeyFormatting(string s, int k) {
			int i = s.Length - 1; int groupCount=0; string plate="";

			while(i>=0){
				char c = s[i];
				--i;

				if(c == '-') continue;

				c = char.ToUpper(c); ++groupCount;

				// to ensure "-" is only added if a character is coming in
				if(groupCount>k){
					plate = "-" + plate;
					groupCount=1;
				}

				plate = c + plate;
			}

			return plate;
		}
	}
}