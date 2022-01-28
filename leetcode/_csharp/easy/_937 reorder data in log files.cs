using System;
using System.Collections.Generic;
using System.Text;

// https://leetcode.com/problems/reorder-data-in-log-files/
namespace _csharp
{
	// C# Compare unlike Java Comparer is not stable. need to separate both lists or have to include the index of number logs so I can have a stable sort.
	public class _937_reorder_data_in_log_files
	{
		public string[] ReorderLogFiles(string[] logs) {
			List<string> letterLogs = new List<string>();
			List<string> numberLogs = new List<string>();

			foreach(string x in logs){
				string[] split_logs = x.Split(new char[]{' '},2);

				if(isDigit(split_logs[1])){
					numberLogs.Add(x);  
				}
				else{
					letterLogs.Add(x);
				}
			}

			letterLogs.Sort(new LogSort());
			letterLogs.AddRange(numberLogs);
			return letterLogs.ToArray();
		}

		private bool isDigit(string s){
			int firstCharAscii = s[0] - '0';
			return firstCharAscii >= 0 && firstCharAscii <= 9;
		}

		public class LogSort : IComparer<string>{
			public int Compare(string a, string b){
				string[] log_a = a.Split(new char[]{' '},2);
				string[] log_b = b.Split(new char[]{' '},2);

				string log_a_identifier = log_a[0];
				string log_b_identifier = log_b[0];

				string log_a_content = log_a[1];
				string log_b_content = log_b[1];

				int sort_by_content = string.Compare(log_a_content,log_b_content);
				if(sort_by_content != 0) return sort_by_content;

				return string.Compare(log_a_identifier,log_b_identifier);
			}
		}
	}
}