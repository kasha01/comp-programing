using System;

// https://leetcode.com/problems/reducing-dishes/
namespace _csharp
{
	public class _1402_reducing_dishes
	{
		public int MaxSatisfaction(int[] satisfaction) {

			// sort asc.
			Array.Sort(satisfaction);
			int n = satisfaction.Length;

			int neg=0; int pos=0;
			int sum = 0;
			for(int i=0;i<n;++i){
				int x = satisfaction[i];
				if(x>=0){
					pos = pos + x;
				}
				else{
					neg = neg + x;
				}
				sum = sum + (x*(i+1));
			}

			// edge case: no positive numbers, return 0 
			if(pos == 0)
				return 0;

			// edge case: no negative numbers, return the whole sum.
			if(neg==0)
				return sum;

			for(int i=0;i<n;++i){
				int x = satisfaction[i];
				if(x>=0){
					// we want to be greedy and remove negative numbers one by one. once we reach a positive
					// number, we can no longer make sum increase, so we break.
					break;
				}

				// shifting all numbers to right, means negative numbers will be added to total sum, and
				// positive numbers will be subtracted from total sum.
				int tempSum = sum + Math.Abs(neg) - pos;
				if(tempSum < sum){
					// tempSum is no longer increasing - break.
					break;
				}
				else{
					sum = tempSum;
					// negative numbers has gotten rid of x, so add x to neg.
					// neg = -20(-9,-1,-8,-2), and I took (-9) out ==> neg = -20+9=-11
					neg = neg + Math.Abs(x);
				}
			}

			return sum;
		}
	}
}