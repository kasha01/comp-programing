using System;
using System.Text;
using System.Collections.Generic;

// https://leetcode.com/problems/zigzag-conversion/
namespace _csharp
{
	public class _6_zigzag_conversion
	{
		public string Convert(string s, int numRows) {

			int n = s.Length;
			int i = 0;
			int pointer = 0;
			int multiplier = 1;
			int c = 1;

			List<Queue<char>> data = new List<Queue<char>>();

			for(int j=0;j<numRows;++j){
				data.Add(new Queue<char>());
			}

			while(i<n){
				char x = s[i];
				data[pointer].Enqueue(x);
				if(c == numRows){
					multiplier = multiplier * -1;
					c=1;
				}
				pointer = pointer + (1 * multiplier);

				if(numRows == 1){
					// edge case
					pointer = 0;
				}

				++i;
				++c;
			}        

			StringBuilder sb = new StringBuilder();
			for(int j=0;j<numRows;++j){
				Queue<char> q = data[j];
				while(q.Count != 0){
					sb.Append(q.Dequeue());
				}
			}

			return sb.ToString();
		}
	}
}