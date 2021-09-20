using System;

// https://leetcode.com/problems/arithmetic-slices/
namespace _csharp
{
	public class _413_arithmetic_slices
	{
		public int NumberOfArithmeticSlices(int[] A) {
			int n = A.Length;
			if(n<3)
				return 0;

			int result = 0;
			int c = 2;
			int diff = A[1] - A[0];
			for(int i=1;i<n-1;++i){
				int d = A[i+1]-A[i];
				if(d == diff){
					++c;
				}
				else{
					if(c==3){
						result = result + 1;
					}
					else if(c>3){
						int x = c-2;
						if(x%2==0){
							result = result + ((x+1) * (x/2));
						}
						else{
							result = result + (((x+1) * (x/2)) + ((x/2) + 1));
						}
					}
					c=2;
					diff = d;
				}
			}

			if(c==3){
				result = result + 1;
			}
			else if(c>3){
				int x = c-2;
				if(x%2==0){
					result = result + ((x+1) * (x/2));
				}
				else{
					result = result + (((x+1) * (x/2)) + ((x/2) + 1));
				}
			}

			return result;
		}
	}
}