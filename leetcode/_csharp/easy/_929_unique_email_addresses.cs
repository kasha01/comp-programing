using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

// https://leetcode.com/problems/unique-email-addresses/
namespace _csharp
{
	public class _929_unique_email_addresses
	{
		public int NumUniqueEmails(string[] emails) {
			HashSet<string> set = new HashSet<string>();

			foreach(string em in emails){
				string[] sp = em.Split('@');
				string local = sp[0]; string domain = sp[1];

				string loc = "";
				foreach(char c in local){
					if(c=='+') break;
					if(c=='.') continue;
					loc = loc + c.ToString();
				}

				set.Add(loc + "@" + domain);
			}

			return set.Count();
		}
	}
}

