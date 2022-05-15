using System;
using System.Collections.Generic;
using System.Collections;

// https://leetcode.com/discuss/interview-experience/1470686/Amazon-Online-Assessment (2nd question)
namespace _csharp
{
	public class _valid_discount_coupons
	{
		/*
		 * Determine if coupon is valid. The validity of a coupon is determined as follows:
		 * 1. An empty discount coupon is valid
		 * 2. If coupon A is valid, the adding the same character to the beginning and end of coupon A is also valid. e.g. AxA is a valid coupon.
		 * 3. If two discount coupons are valid, then there concatenation is also valid. i.e. A and B is valid, then AB is also valid
		*/

		public static void isValid(string[] coupons){
			if (coupons.Length == 0)
				Console.WriteLine ("valid");

			if(coupons.Length % 2 != 0)
				Console.WriteLine ("not_valid");

			foreach (string s in coupons) {
				Stack<char> st = new Stack<char> ();
				foreach (char c in s) {
					if (st.Count == 0 || st.Peek () != c)
						st.Push (c);
					else
						st.Pop ();
				}

				Console.WriteLine (st.Count == 0 ? "valid" : "not_valid");
			}
		}
	}
}

