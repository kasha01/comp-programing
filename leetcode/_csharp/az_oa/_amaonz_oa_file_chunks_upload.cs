using System;
using System.Collections.Generic;

// https://leetcode.com/discuss/interview-question/1495982/Amazon-OA
namespace _csharp
{
	public class _amaonz_oa_file_chunks_upload
	{
		public static void Run_Tests (string[] args)
		{
			test1 ();
			test2 ();
			test3 ();
		}

		private static void solve(int[][] arr){			
			var current = new List<int[]>();

			var ans = new List<List<int[]>> ();
			for(int i=0; i<arr.Length;++i){
				current = merge(current, arr[i]);
				ans.Add(current);
			}

			foreach (var e in ans) {
				Console.Write ("[");
				foreach (var a in e) {
					Console.Write ($"[{a[0]},{a[1]}]" + " ");
				}
				Console.Write ("]");
				Console.WriteLine ();
			}
			Console.WriteLine ("==============================");
		}


		private static List<int[]> merge(List<int[]> intervals, int[] newInterval) {
			var merge = new List<int[]>();
			int i=0; int n = intervals.Count;

			int start = newInterval[0];
			int end = newInterval[1];

			while(i<n && intervals[i][1] < newInterval[0]-1){
				merge.Add(intervals[i]); ++i;
			}

			while(i<n && end >= intervals[i][0]-1){
				start = Math.Min(intervals[i][0], start);
				end = Math.Max(intervals[i][1], end);
				++i;
			}            

			merge.Add(new int[]{start,end});

			while(i<n){
				merge.Add(intervals[i]); ++i;
			}

			return merge;
		}

		private static void test1(){
			int[][] arr = new int[3][];
			arr [0] = new int[]{ 1,1 };
			arr [1] = new int[]{ 2,2 };
			arr [2] = new int[]{ 3,3 };

			solve(arr);
		}

		private static void test2(){
			int[][] arr = new int[5][];
			arr [0] = new int[]{ 7,9 };
			arr [1] = new int[]{ 1,3 };
			arr [2] = new int[]{ 8, 15 };
			arr [3] = new int[]{ 6,9 };
			arr [4] = new int[]{ 2,4 };

			solve(arr);
		}

		private static void test3(){
			int[][] arr = new int[5][];
			arr [0] = new int[]{ 1,3 };
			arr [1] = new int[]{ 8,15 };
			arr [2] = new int[]{ 6,9 };
			arr [3] = new int[]{ 2,5 };
			arr [4] = new int[]{ 1,9 };

			solve(arr);
		}

	}
}

