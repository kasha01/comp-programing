using System;
using System.Collections.Generic;

// https://leetcode.com/problems/accounts-merge/
namespace _csharp
{
	public class _721_accounts_merge
	{
		public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
			// email - neighboring emails
			Dictionary<string,List<string>> edges = new Dictionary<string,List<string>>();

			// head email to account map
			Dictionary<string,string> emailsMap = new Dictionary<string,string>();

			// account - flattened list of emails
			List<List<string>> result = new List<List<string>>();

			int n = accounts.Count;
			for(int i=0;i<n;++i){
				int m = accounts[i].Count;
				string headEmail = accounts[i][1];          

				for(int j=1;j<m;++j){
					string email = accounts[i][j];
					if(!edges.ContainsKey(email)){
						edges.Add(email, new List<string>());
					}

					if(!edges.ContainsKey(headEmail)){
						edges.Add(headEmail, new List<string>());
					}

					edges[email].Add(headEmail);
					edges[headEmail].Add(email);

					if(!emailsMap.ContainsKey(email))
						emailsMap.Add(email,accounts[i][0]);
				}
			}

			Stack<string> stack = new Stack<string>();
			HashSet<string> visited = new HashSet<string>();
			foreach(var kvp in emailsMap){
				string email = kvp.Key;
				string myEdges = kvp.Value;

				if(visited.Contains(email)){
					continue;
				}

				string account = emailsMap[email];
				result.Add(new List<string>());
				int i = result.Count - 1;

				stack.Push(email);

				while(stack.Count>0){
					string em = stack.Pop();

					if(visited.Contains(em)) continue;

					visited.Add(em);
					result[i].Add(em);
					foreach(string neighbor in edges[em]){
						if(!visited.Contains(neighbor)){
							stack.Push(neighbor);
						}
					}                
				}

				result[i].Sort(new MyComparer());
				result[i].Insert(0,account);
			}

			return result.ToArray();
		}

		class MyComparer : IComparer<string>{
			public int Compare(string a, string b){
				return String.CompareOrdinal(a, b);
			}
		}
	}
}

