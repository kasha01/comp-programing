using System;

// https://leetcode.com/problems/maximum-profit-in-job-scheduling/
namespace _csharp
{
	public class _1235_maximum_profit_in_job_scheduling
	{
		class Node{
			public int startTime {get;set;}
			public int endTime {get;set;}
			public int profit {get;set;}

			public Node(int s, int e, int p){
				this.startTime = s;
				this.endTime = e;
				this.profit = p;
			}
		}

		int[] memo;
		public int JobScheduling(int[] startTime, int[] endTime, int[] profit) {
			int n = startTime.Length;
			var nodes = new Node[n];
			for(int i=0;i<n;++i){
				nodes[i] = new Node(startTime[i],endTime[i],profit[i]);
			}

			Array.Sort(nodes, (a,b) => sortMe(a,b));

			memo = new int[n];
			return rc(0,n,nodes);
		}

		private static int sortMe(Node a, Node b){
			return a.startTime - b.startTime;
		}

		private int rc(int i, int n, Node[] nodes){
			if(i>=n)
				return 0;

			if(memo[i]>0) return memo[i]-1;

			// don't pick this job
			int prof_no_pick = rc(i+1,n,nodes);

			// next job that can come after i job
			int next_job = findNextJob(i+1,n-1,nodes[i].endTime,nodes);

			// pick this job
			int prof_pick = nodes[i].profit + (next_job == -1 ? 0 : rc(next_job,n,nodes));

			int mx = Math.Max(prof_no_pick, prof_pick);
			memo[i] = mx+1;
			return mx;
		}

		private int findNextJob(int lo, int hi, int target, Node[] arr){
			int ans = -1;
			while(lo<=hi){
				int mid = lo + ((hi-lo)/2);

				if(arr[mid].startTime >= target){
					ans = mid;
					hi = mid-1;
				}
				else{
					lo = mid + 1;
				}
			}

			return ans;
		}
	}
}