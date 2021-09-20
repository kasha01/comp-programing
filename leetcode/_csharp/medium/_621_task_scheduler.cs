using System;

/*****
NOT MY SOLUTION. THANKS TO: Naresh Gupta. 
https://www.youtube.com/watch?v=sTEPmlWBmJU

Code posted merely for my personal record.
*****/

// https://leetcode.com/problems/task-scheduler/
namespace _csharp
{
	public class _621_task_scheduler
	{
		/* Example ["A","A","A","B","B","B"] n=2
		The idea of this solution is, I find the task/letter with the largest frequency, and I start with count of idleSpots that I can have
		to ensure my max freq. task is separated by n periods. Then I fill the rest of letters in the idlespots, but since I started with count of
		idleSpots that ensure the max. freq task is separated by n, then any other task (with freq. less than or equal my max freq task) will sure
		fit into these idleSpots. i.e. if my initial idleSpots can safely separate my max freq. task, it surely can separate all other tasks.
		*/
		public static int leastInterval(char[] tasks, int n) {
			int[] f = new int[26];
			foreach(char task in tasks)
				f[task - 'A']++;

			// I am sorting the array to pick f[25] which is the task with the highest frequency.
			Array.Sort(f);

			// chunk is basically the number of spans(__) between letter. here I picked letter f[25] which the letter with the highest frequency.
			// so chunk is maximum span I have. e.g. AAA => would have 2 chunks A_A_A. AAAA => A_A_A_A.
			// In this example, max freq is 3 (3 As). chunks are like this: A__A__A
			int chunk = f[25] - 1;

			// number of idleSpots is the count of chunks multiliplied by the size of the chunk which needs to be n, to ensure that the task (A)
			// is separated by the required time period of n. thus chunk*n. Now I have the number of idleSpots to ensure my max freq. tasks are all
			// safely separated.
			// so here I have 4 idleSpots(2 chuncks each with the size of n((2)) A_ _A_ _A
			int idleSpots = chunk * n;

			// Now I need to fill in the other tasks into the idleSpots..Notice here I started with task[24] since task[25] (my max freq task) was
			// already picked. as in: A _ _ A _ _ A
			for(int i = 24; i >= 0; i--) {
				// fill in the tasks in the idleSpots and minimize idleSpots count accordingly.
				// Notice that here, I pick the min of chunk and freq of task. 
				// if task freq > chunk => pick chunk because, the idea is, I can always distribute/fit in the remaining tasks in the chunks plus
				// the end of the schedule (since the size of chunks (chunk*n) was set to ensure max freq fit, so all other tasks will also fit in),
				// so here I am saying I'm going to fill in the tasks in the chunks like that => AB_AB_AB and subtract from idleSpots. Notice how I
				// put 2B in chunks and the 3rd B on the end of the schedule. thus subtract 2 from the idleSpots (number of idleSpots used by 2Bs)
				// if task freq < chunk => pick freq as I can simply put it anywhere.
				idleSpots -= Math.Min(chunk, f[i]);
			}

			// if the idleSpots was negative which is a special case when all tasks have the same frequency and n<=count of tasks.
			// e.g. ["A","A","A","B","B","B"] n=0 OR ["A","B","C","D","A","B","C","D","A","B","C","D"] n = 4. then just return the task length
			// as that means the idleSpot (chunk * n) which is the span between the letters, is smaller than the letters count due to the small n
			// which means the letters separation is enough to accommodate the idle condition. like ABCDA, notice BCDA (equals n which equals to 4) 
			// otherwise return task lenght + idleSpots remaining.
			return idleSpots < 0 ? tasks.Length : idleSpots + tasks.Length;
		}
	}
}