using System;

// https://leetcode.com/problems/candy/
namespace _csharp
{
	public class _135_candy
	{
		public int Candy(int[] ratings) {
			int n = ratings.Length;

			if(n==0) return 0;
			if(n==1) return 1;

			int[] left = new int[n];
			int[] right = new int[n];

			left[0]=1;
			for(int i=1;i<n;++i){
				if(ratings[i]>ratings[i-1]) 
					left[i]=left[i-1]+1;
				else
					left[i]=1;
			}

			right[n-1]=1;
			for(int i=n-2;i>=0;--i){
				if(ratings[i]>ratings[i+1]) 
					right[i]=right[i+1]+1;
				else
					right[i]=1;
			}

			int res=0;
			for(int i=0;i<n;++i){
				res = res + Math.Max(left[i],right[i]);
			}

			return res;
		}
	}
}

