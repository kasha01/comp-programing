using System;

// https://leetcode.com/problems/powx-n/
// tags: power
namespace _csharp
{
	public class _50_pow_x_n
	{
		public double MyPow(double x, int n) {
			return rc(x,n);    
		}

		private double rc(double x, int y){
			if(y==0) return 1;

			double temp = rc(x,y/2);
			if(y%2==0){
				return temp * temp;
			}
			else{
				// odd
				if(y>0){
					return x * temp * temp;
				}
				else{
					return (temp * temp ) / x;
				}
			}

			return -1;
		}
	}
}

