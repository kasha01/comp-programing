using System;

// https://practice.geeksforgeeks.org/problems/sum-of-query-ii/0
namespace GeeksForGeeks_csharp
{
	public class Sum_of_Query_II
	{
		public static void solve() {
			int t = Int16.Parse(Console.ReadLine());
			while(t>0){
				t--;
				int n = Int32.Parse(Console.ReadLine());
				int[] arr = new int[n];
				int[] a = new int[n];
				int sum = 0;
				string _arr_items = Console.ReadLine();
				string[] arr_items = _arr_items.Split(' ');
				for(int i=0;i<n;++i){
					int x = Int32.Parse(arr_items[i]);
					arr[i]=x;
					sum = sum + x;
					a[i]=sum;
				}
				int q = Int32.Parse(Console.ReadLine());
				string _items = Console.ReadLine();
				string[] items = _items.Split(' ');
				for(int i=0;i<q*2;i=i+2){
					int l = Int32.Parse(items[i])-1;
					int r = Int32.Parse(items[i+1])-1;

					int result = 0;
					if(l==0){
						result = a[r]; 
					}
					else{
						result = a[r]-a[l-1];
					}
					Console.Write(result + " ");
				}
				Console.WriteLine();
			}
		}
	}
}

