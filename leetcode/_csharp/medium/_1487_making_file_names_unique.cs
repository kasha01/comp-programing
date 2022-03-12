using System;
using System.Collections.Generic;

// https://leetcode.com/problems/making-file-names-unique/
namespace _csharp
{
	public class _1487_making_file_names_unique
	{
		public string[] GetFolderNames(string[] names) {
			var map = new Dictionary<string,int>();
			int n = names.Length; int i=0;
			var ans = new string[n];
			while(i<n){
				string name = names[i];
				if(map.ContainsKey(name)){
					string prefix = name;
					int x = map[name];

					string new_name = prefix + "(" + x + ")";
					while(map.ContainsKey(new_name)){
						++x;
						new_name = prefix + "(" + x + ")";
					}

					map.Add(new_name,1);
					map[prefix]=x+1;
					ans[i] = new_name;
				}
				else{
					map.Add(name,1);
					ans[i] = name;
				}

				++i;
			}

			return ans;
		}
	}
}