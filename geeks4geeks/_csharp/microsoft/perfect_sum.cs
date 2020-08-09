using System;

// https://practice.geeksforgeeks.org/problems/perfect-sum-problem/0
namespace GeeksForGeeks_csharp
{
	public class perfect_sum
	{
		static int sum = 10;
		static int n = 5;

		public static void test(){
			int[] arr = { 1,2,3,4,5 };
			n=5; sum = 10;
			Console.WriteLine (dp (arr, 0, 0));
		}

		static int solve(int[] arr, int i, int s){
			if (s == sum)
				return 1;

			if (s > sum)
				return 0;

			if (i >= n)
				return 0;

			int a = solve (arr, i + 1, s + arr [i]);
			int b = solve (arr, i + 1, s);

			return a + b;
		}

		// NOT MY SOLUTION. THANKS TO https://hackerranksolutionc.blogspot.com/2018/05/count-no-of-subset-having-sum-k.html
		// dynamic programming
		public static int dp(int[] a,int n,int sum)
		{
			int[,] dp=new int[n+1,sum+1]; // denotes no. of subset till n having sum=sum
			for(int i=0;i<=n;++i)
				dp[i,0]=1;
			for(int i=1;i<=n;++i)
			{
				for(int j=1;j<=sum;++j)
				{
					dp[i,j]=dp[i-1,j];//do not include 
					if(a[i-1]<=j)
						dp[i,j]+=dp[i-1,j-a[i-1]]; // include sum
				}
			}
			return dp[n,sum];
		}
	}
}

