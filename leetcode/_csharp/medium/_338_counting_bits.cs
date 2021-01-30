using System;

// https://leetcode.com/problems/counting-bits/
namespace _csharp
{
	public class _338_counting_bits
	{
		public int[] CountBits(int num) {
			int[] result = new int[num+1];

			result[0]=0;
			if(num==0){ 
				return result;     
			}

			result[1]=1;
			if(num==1){
				return result;
			}

			result[2]=1;
			if(num==2){
				return result;
			}

			result[3]=2;
			if(num==3){
				return result;
			}

			int j=0;
			int b=0;
			for(int i=4;i<=num;++i){
				if(i%4==0){
					j=0;b++;
				}
				result[i] = result[j] + result[b]; 
				++j;
			}

			return result;
		}
	}
}

