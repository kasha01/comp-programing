using System;
using System.Collections.Generic;

namespace GeeksForGeeks_csharp
{
	// https://practice.geeksforgeeks.org/problems/smallest-window-in-a-string-containing-all-the-characters-of-another-string/0
	public class smallest_window_in_string
	{
		public void solve(){
			string s = "kalmazloo";
			string t = "oom";

			Dictionary<char,int> map = new Dictionary<char,int> ();
			for (int i = 0; i < t.Length; i++) {
				if (!map.ContainsKey (t [i])) {
					map.Add (t [i], 1);
				} else {
					map [t [i]]++;
				}
			}

			List<KeyValuePair<int,char>> list = new List<KeyValuePair<int,char>> ();
			for (int i = 0; i < s.Length; ++i) {
				if (map.ContainsKey (s [i])) {
					list.Add (new KeyValuePair<int, char> (i, s [i]));
				}
			}

			list.Sort (compare_me);

			int a1 = -1;
			int d = int.MaxValue;
			for (int i = 0; i < list.Count; ++i) {
				var map2 = new Dictionary<char,int>(map);
				int total = t.Length;
				int ii = list [i].Key;
				for (int j = i; j < list.Count; j++) {
					int jj = list [j].Key;
					char c = list [j].Value;
					if (map2 [c] > 0) {
						map2 [c]--;
						total--;
						if (total == 0 && (jj-ii+1)<d) {
							d = jj - ii + 1;
							a1 = ii;
							break;
						}
					}
				}
			}

			string ans = "";
			if (d == int.MaxValue) {
				d = -1;
				ans = "-1";
			} else {
				ans = s.Substring (a1, d);
			}
			Console.WriteLine (ans);
		}

		private int compare_me (KeyValuePair<int,char> a, KeyValuePair<int,char> b)
		{
			if (a.Key > b.Key)
				return 1;
			else if (a.Key < b.Key)
				return -1;
			else
				return 0;
		}
	}
}

