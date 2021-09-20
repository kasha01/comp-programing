using System;

// https://leetcode.com/problems/house-robber-ii/
namespace _csharp
{
	public class _213_house_robber_ii
	{
		public int Rob(int[] nums) {
			int n = nums.Length;
			int[,,] memo = new int[n,2,2];
			for(int i=0;i<n;++i){
				for(int j=0;j<2;++j){
					for(int k=0;k<2;++k){
						memo[i,j,k]=-1;                    
					}
				}
			}

			int sum1 = nums[0] + rc(1,true,true,memo,nums);
			int sum2 = rc(1,false,false,memo,nums);

			return Math.Max(sum1,sum2);
		}

		private int rc(int i, bool prevHouseStolen, bool firstIsStolen,int[,,] memo, int[] nums){
			int n = nums.Length;
			if(i>=n)
				return 0;

			int j = prevHouseStolen ? 0 : 1;
			int k = firstIsStolen ? 0 : 1;
			if(memo[i,j,k]!=-1){
				return memo[i,j,k];
			}

			int sum1=0;
			if(!prevHouseStolen){
				if((i==n-1 && !firstIsStolen) || i!=n-1){
					// I can steal this house
					sum1 = nums[i] + rc(i+1,true,firstIsStolen,memo,nums);                
				}
			}

			int sum2 = rc(i+1,false,firstIsStolen,memo,nums);

			int s = Math.Max(sum1,sum2);
			memo[i,j,k] = s;
			return s;        
		}
	}
}