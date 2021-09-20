using System;
using System.Collections.Generic;

// https://leetcode.com/problems/permutation-in-string/
namespace _csharp
{
	public class _567_permutation_in_string
	{
		public bool CheckInclusion(string s1, string s2) {
			int targetCount=s1.Length;
			Dictionary<char,int> targetMap = new Dictionary<char,int>();

			foreach(char c in s1){
				if(!targetMap.ContainsKey(c))
					targetMap.Add(c,0);

				targetMap[c]++;
			}

			Dictionary<char,int> tempMap = new Dictionary<char,int>();
			int count=0;
			for(int i=0; i<s2.Length; ++i){
				char x = s2[i];
				if(targetMap.ContainsKey(x)){
					if(!tempMap.ContainsKey(x))
						tempMap.Add(x,0);

					tempMap[x]++;
					++count;
					if(tempMap[x] > targetMap[x]){
						int j = i;
						tempMap.Clear();
						count = 0;
						while(j>=0 && targetMap.ContainsKey(s2[j])){
							if(!tempMap.ContainsKey(s2[j]))
								tempMap.Add(s2[j],0);

							if(tempMap[s2[j]] == targetMap[s2[j]])
								break;

							tempMap[s2[j]]++;
							++count;
							--j;
						}
					}
				}
				else{
					tempMap.Clear(); count=0;
				}

				if(count==targetCount)
					return true;
			}

			return false;
		}
	}
}