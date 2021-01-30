using System;

// https://leetcode.com/problems/check-if-a-string-can-break-another-string/
namespace _csharp
{
	public class _1433_check_if_a_string_can_break_another_string
	{
		public bool CheckIfCanBreak(string s1, string s2) {
			char[] sa = s1.ToCharArray(); 
			Array.Sort(sa);

			char[] sb = s2.ToCharArray(); 
			Array.Sort(sb);

			int n = sa.Length;

			bool s1CanBreaks2 = true;
			bool s2CanBreaks1 = true;
			for(int i=0;i<n;++i){
				if(sa[i] == sb[i]){
					continue;
				}
				if(sa[i] > sb[i]){
					s2CanBreaks1 = false;
				}

				if(sa[i] < sb[i]){
					s1CanBreaks2 = false;
				}
			}

			return s1CanBreaks2 || s2CanBreaks1;
		}
	}
}

