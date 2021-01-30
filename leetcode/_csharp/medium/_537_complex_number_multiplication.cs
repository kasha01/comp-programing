using System;

// https://leetcode.com/problems/complex-number-multiplication/
namespace _csharp
{
	public class _537_complex_number_multiplication
	{
		public string ComplexNumberMultiply(string a, string b) {
			string[] a_arr = a.Split('+');
			string[] b_arr = b.Split('+');

			int a1 = int.Parse(a_arr[0]);
			int a2 = int.Parse(a_arr[1].Substring(0,a_arr[1].Length-1));

			int b1 = int.Parse(b_arr[0]);
			int b2 = int.Parse(b_arr[1].Substring(0,b_arr[1].Length-1));

			int p1 = (a1*b1) + (a2*b2*-1);
			int p2 = (a1*b2) + (a2*b1);

			return p1.ToString() + "+" + p2.ToString() + "i";
		}
	}
}

