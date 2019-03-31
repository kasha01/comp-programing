using System;
using System.Collections.Generic;

namespace GeeksForGeeks_csharp
{
	class MainClass
	{
		public void init(){
			int t = Int16.Parse(Console.ReadLine());
			while(t>0){
				t--;
				int n = Int32.Parse(Console.ReadLine());
				string _items = Console.ReadLine();
				string[] items = _items.Split(' ');
			}
		}

		static int n = 4;
		static int[] pet = {4,6,7,4};
		static int[] dis = {6,5,3,5};

		static bool solve(int s, int n){
			int ii = s;
			int p =0;
			do {
				int d = dis[ii];
				p=p+pet[ii];
				if(p<d){
					return false;
				}
				else{
					ii++;
					ii = ii % n;
					p=p-d;
				}
			} while(ii != s);
			return true;
		}

		public static void Main (string[] args)
		{
			int ans = -1;
			for(int i=0;i<n;++i){
				if (solve(i,n)) {
					ans = i;
					break;
				}
			}
			Console.WriteLine (ans);
		}
	}
}
