using System;

// https://leetcode.com/problems/slowest-key/
namespace _csharp
{
	public class _1629_slowest_key
	{
		public char SlowestKey(int[] releaseTimes, string keysPressed) {
			int n = releaseTimes.Length;

			int prev = 0; int maxDuration = -1; char maxPressedKey = 'a';
			for(int i=0;i<n;++i){
				char c = keysPressed[i];

				int duration = releaseTimes[i]-prev;
				prev = releaseTimes[i];

				if(duration > maxDuration){
					maxDuration = duration;
					maxPressedKey = c;
				}
				else if(duration == maxDuration){
					maxPressedKey = c > maxPressedKey ? c : maxPressedKey;
				}
			}

			return maxPressedKey;
		}
	}
}