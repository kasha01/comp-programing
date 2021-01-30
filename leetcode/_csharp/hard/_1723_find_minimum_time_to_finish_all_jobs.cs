using System;
using System.Collections.Generic;

// https://leetcode.com/problems/find-minimum-time-to-finish-all-jobs/
// Not entirely my solution.
namespace _csharp
{
	public class _1723_find_minimum_time_to_finish_all_jobs
	{
		static int minAchievedWorkLoadOnWorker;

		public int MinimumTimeRequired(int[] jobs, int k) {
			int n = jobs.Length;
			minAchievedWorkLoadOnWorker=int.MaxValue;

			int[] arr = new int[k];

			rc(0,0,k,n,jobs,arr);
			return minAchievedWorkLoadOnWorker;
		}

		// O(k^n). as I have n jobs to put in k buckets(states). permutation with repetition
		private static void rc(int j, int ws, int k, int n, int[] jobs, int[] arr){
			if(j==n){
				// all jobs were assigned. check the jobs
				int s=0;
				int mx=-1;
				for(int i=0;i<k;++i){
					s=s+arr[i];
					mx=Math.Max(arr[i],mx);
				}

				minAchievedWorkLoadOnWorker=Math.Min(mx, minAchievedWorkLoadOnWorker);
				return;
			}

			HashSet<int> set = new HashSet<int>();
			// optimization: instead of cramping all the workloads in the first bucket (1 worker), let's spread the workload. increasing the probability
			// to reach the optimal answer faster, thus will decrease the number of iterations we have to do, as non-productive answers will get excluded
			// in the other optimizations.
			for (int i = ws; i<k+ws; ++i) {
				int w = i%k;
				int workLoad = arr[w]+jobs[j];

				// I already have an answer(minAchievedWorkLoadOnWorker) that is smaller than the workLoad I am putting in a bucket (A worker)
				// this will lead to no-productive answer, so skip this iteration.
				if(workLoad >= minAchievedWorkLoadOnWorker){continue;}

				// in case I have workers with similar workloads when I reach j Job, I just need to try one of them as putting the workLoad
				// on worker A or B will have the same result. consider this arr[10,5,5,5,5]. doesn't matter if I put the job on worker 2,3,4 or 5
				// it is the same outcome, so try the iteration with only one of them. this is called Symmetry Breaking: Filtering out the searched value
				// is really useful, and interestingly, this is actually a common technique in discrete optimization.
				if(set.Contains(workLoad)){continue;}

				set.Add(workLoad);
				arr[w]=workLoad;
				rc(j+1,i+1,k,n,jobs,arr);
				arr[w]=arr[w]-jobs[j];
			}
		}		
	}
}