using System;
using System.Collections.Generic;

// https://leetcode.com/discuss/interview-question/699973/Goldman-Sachs-or-OA-or-Turnstile
namespace _csharp
{
	public class _amazon_oa_student_turnstile
	{
		public void solve(){
			int d_exit = 1; int d_enter = 0;

			var time = new int[]{ 0, 0, 1, 5 };
			var direction = new int[] { 0, 1, 1, 0 };
			int n = time.Length;

			// time | index
			Queue<int[]> entry = new Queue<int[]>();
			Queue<int[]> exit = new Queue<int[]>();

			// fill the queues
			for(int i=0;i<n;++i){
				if(direction[i] == d_enter){
					entry.Enqueue(new int[] {time[i],i});
				}
				else{
					exit.Enqueue(new int[] {time[i],i});
				}
			}

			var result = new int[n];
			int current_time = 0; int last_direction = -1;
			while (entry.Count > 0 || exit.Count > 0) {
				// if student exit time <= current time AND last direction on last second was exit OR
				// if student exit time <= current time AND last direction on last second was free OR
				// there no entry students. so always exit
				if (exit.Count > 0 && exit.Peek()[0] <= current_time && (last_direction == -1 || last_direction == d_exit || entry.Count == 0)) {
					var p = exit.Dequeue ();
					result [p [1]] = current_time;
					last_direction = d_exit;

				// if student enter time <= current time AND last direction on last second was enter OR
				// if student enter time <= current time AND last direction on last second was free OR
				// there are no exit students. so always process the enter students.
				} else if (entry.Count > 0 && entry.Peek()[0] <= current_time && (last_direction == d_enter || exit.Count == 0)) {
					var p = entry.Dequeue ();
					result [p [1]] = current_time;
				} else {
					last_direction = -1;	// last second nobody entred/exit (because there time doesn't match current time)
				}

				++current_time;
			}

			// print answer
			foreach(var e in result){
				Console.WriteLine (e);
			}
		}
	}
}