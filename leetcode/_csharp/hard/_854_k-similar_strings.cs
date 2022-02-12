using System;
using System.Collections.Generic;

// https://leetcode.com/problems/k-similar-strings/
namespace _csharp
{
	/* Trick Explanation
* lets take string a b c d e. On level 1 my nodes added to the queue can be like this:
* Level 1 => ... a c b d e .... a b c e d  
* Level 2 => ... a c b e d .... a b c d e
* Notice how I produced similar/visited strings, which can be caught by visited hashset, however since the swap process is expensive, this will TLE, so I avoid unnecessary swaps by only swapping one pair of unmatched characters. This will still give the correct result since:
1. Order of the swaps does not matter. i.e. if I swapped [b,c] first or [d,e] first, it would yield the same result
2. BFS guarantees shortest path
3. Naturally I am to count 1 swap per level, so logically all what I need to do (per each level) is to find an unmatched character at(i) and swap it will all qualified characters at(j) where j>i. Attempting to swap for i+1 characters, will still yield the same result but with TLE, because the order of the swaps has no effect here in shortening the path.
*/

	public class _854_k_similar_strings
	{
		public int KSimilarity(string s1, string s2) {
			if(s1 == s2) return 0;
			int m = s1.Length;

			Queue<string> qu = new Queue<string>();
			var visited = new HashSet<string>();

			qu.Enqueue(s2);
			visited.Add(s2);
			int k = 0;

			while(qu.Count > 0){
				int n = qu.Count;

				for(int p=0;p<n;++p){
					var node = qu.Dequeue();

					if(node == s1)
						return k;

					// TRICK
					// find i for a character that is misplaced.
					int i=0;
					while(i<m && node[i] == s1[i]){
						++i;
					}

					// replace that char at (i) with all positions j that is a match (ignore non matched characters)
					for(int j=i+1;j<m;++j){
						if(node[i] == node[j] || node[j] != s1[i]) continue; 

						var sb = node.ToCharArray();

						// swap
						char c = sb[i];
						sb[i] = sb[j];
						sb[j] = c;

						string s = new string(sb);
						if(!visited.Contains(s)){
							qu.Enqueue(s);
							visited.Add(s);
						}
					}
				}
				++k;
			}

			return k;
		}
	}
}