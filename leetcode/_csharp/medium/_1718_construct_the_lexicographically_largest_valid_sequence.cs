using System;
using System.Collections.Generic;
using System.Collections;

// https://leetcode.com/problems/construct-the-lexicographically-largest-valid-sequence/
namespace _csharp
{
	public class _1718_construct_the_lexicographically_largest_valid_sequence
	{
		int[] result;
		public int[] ConstructDistancedSequence(int n) {
			int m = n*2 - 1;
			result = new int[m];
			var used = new HashSet<int>();

			rc(0,used,n,m);

			return result;    
		}

		private bool rc(int i, HashSet<int> used, int n, int m){
			if(used.Count==n)
				return true;

			if(i>=m)
				return false;

			if(result[i] != 0){
				// I still have more numbers but this spot is already filled in.
				return rc(i+1,used,n,m);
			}

			for(int x=n;x>0;--x){
				if(used.Contains(x))
					continue;

				if(x==1 || (x+i<m && result[i+x]==0)){
					result[i]=x;
					if(x>1){
						result[i+x]=x;
					}

					used.Add(x);

					bool r =rc(i+1, used, n, m);

					if(r)
						return true;

					if(x>1){
						result[i+x]=0;    
					} 
					result[i]=0;
					used.Remove(x);
				}
			}
			return false;
		}
	}
}