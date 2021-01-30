using System;
using System.Collections.Generic;

// https://leetcode.com/problems/3sum/
namespace _csharp
{
	public class _15_3_sum
	{
		public IList<IList<int>> ThreeSum(int[] nums) {
			var result = new List<List<int>>();
			int n = nums.Length;
			if(n<3)
				return result.ToArray();

			Dictionary<int,int> map = new Dictionary<int,int>();

			int zeroCount=0;
			List<int> pos = new List<int>();
			List<int> neg = new List<int>();

			for(int i=0;i<n;++i){
				int x = nums[i];

				if(x>0){
					addToMap(x, map, pos);
				}
				else if(x<0){
					addToMap(x, map, neg);
				}
				else {
					zeroCount++;
				}
			}

			// all zeros
			if(zeroCount >=3){
				result.Add(new List<int>(){0,0,0});
			}

			neg.Sort();
			pos.Sort();

			int lastUsed=0;
			int lastUsedB=0;
			int lastUsedC=0;

			// positives
			int m=pos.Count;
			for(int i=0;i<m;++i){
				int a = pos[i];
				if(lastUsed==a){
					// to avid duplicates
					continue;
				}

				lastUsed=a;
				int _a = -1*a;
				if(zeroCount>0){
					// check if there is a negative number == -a; ==> {a,0,-a}
					if(map.ContainsKey(_a)){
						result.Add(new List<int>(){a,0,_a});
					}
				}

				// check of two negatives numbers where b+c = -a
				int j=0; int k = neg.Count-1;
				while(j<k){
					int b = neg[j];
					int c = neg[k];
					int s = b+c;
					if(s < _a){
						++j;
					}
					else if(s > _a){
						--k;
					}
					else{
						if(b!=lastUsedB || c!=lastUsedC){
							result.Add(new List<int>(){a,b,c});                        
						}
						lastUsedB=b;
						lastUsedC=c;
						++j; --k;
					}
				}
			}

			// negatives
			m=neg.Count;
			lastUsed=0;
			lastUsedB=0;
			lastUsedC=0;
			for(int i=0;i<m;++i){
				int a = neg[i];
				if(lastUsed==a){
					// to avid duplicates
					continue;
				}

				lastUsed=a;
				int _a = Math.Abs(a);

				// check of two positive numbers where (b+c) = Abs(a)
				int j=0; int k = pos.Count-1;
				while(j<k){
					int b = pos[j];
					int c = pos[k];
					int s = b+c;
					if(s < _a){
						++j;
					}
					else if(s > _a){
						--k;
					}
					else{
						if(b!=lastUsedB || c!=lastUsedC){
							result.Add(new List<int>(){a,b,c});                        
						}
						lastUsedB=b;
						lastUsedC=c;
						++j; --k;
					}
				}
			}

			return result.ToArray();
		}

		void addToMap(int x, Dictionary<int,int> map, List<int> list){
			if(!map.ContainsKey(x)){
				map.Add(x,1);
				list.Add(x);
			}
			else if(map.ContainsKey(x) && map[x]<2){
				map[x]++;
				list.Add(x);
			}
		}
	}
}

