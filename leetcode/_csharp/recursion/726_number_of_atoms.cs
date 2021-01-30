using System;
using System.Collections.Generic;

// https://leetcode.com/problems/number-of-atoms/
namespace _csharp
{
	public class _726_number_of_atoms
	{
		static void driver() {
			solve ("Mg(OH)2");
		}

		static void solve(string formula){
			int i = formula.Length - 1;
			Stack<int> stack = new Stack<int> ();
			Dictionary<string,int> map = new Dictionary<string, int> ();

			int parsedNum = 1;
			int multiplier = 1;

			while (i >= 0) {
				parsedNum = 1;
				char character = formula [i];
				int dchar = character;

				int x = 1;
				int num = 0;
				while (i >=0 && dchar >= 48 && dchar <= 57) {
					int a = dchar - 48;
					num = num + (a * x);

					i--;
					x = x * 10;
					character = formula [i];
					dchar = character;
					parsedNum = num;
				}

				if (dchar >= 97 && dchar <= 122) {
					// small letter
					string atomName = formula [i - 1].ToString() + character.ToString();
					if(map.ContainsKey(atomName)){
						map[atomName] = map[atomName] + (multiplier * parsedNum);
					} else{
						map.Add (atomName, multiplier * parsedNum);
					}
					--i;	// i counted the small letter here so need to decrement i an extra -1
				} else if (dchar >= 65 && dchar <= 90) {
					// cap letter
					if(map.ContainsKey(character.ToString())){
						map[character.ToString ()] = map[character.ToString ()] + multiplier * parsedNum;
					} else{
						map.Add (character.ToString (), multiplier * parsedNum);
					}
				} else if (formula [i] == ')') {
					stack.Push (parsedNum);
					multiplier = multiplier * parsedNum;
				} else if (formula[i] == '(') {
					int a = stack.Pop ();
					multiplier = multiplier / a;
				}

				--i;
			}

			List<KeyValuePair<string,int>> list = new List<KeyValuePair<string, int>>();
			foreach (var p in map.Keys) {
				list.Add (new KeyValuePair<string, int> (p, map [p]));
			}

			list.Sort (new mycomparer());

			string r = "";
			foreach (KeyValuePair<string,int> p in list) {
				if (p.Value > 1) {
					r = r + p.Key + p.Value;
				} else {
					r = r + p.Key;
				}
			}
			Console.WriteLine (r);
		}
	}

	class mycomparer : IComparer<KeyValuePair<string, int>>
	{
		public int Compare(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
		{
			return x.Key.CompareTo(y.Key);
		}
	}
}