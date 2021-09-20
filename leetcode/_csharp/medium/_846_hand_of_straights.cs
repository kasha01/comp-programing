using System;
using System.Collections.Generic;

// https://leetcode.com/problems/hand-of-straights/
namespace _csharp
{
	public class _846_hand_of_straights
	{
		public bool IsNStraightHand(int[] hand, int W) {
			int n = hand.Length;
			if(n%W != 0)
				return false;

			SortedDictionary<int,int> map = new SortedDictionary<int,int>();
			List<int> cards = new List<int>();

			foreach(int x in hand){
				if(!map.ContainsKey(x)){
					map.Add(x,0);
					cards.Add(x);
				}
				++map[x];
			}

			cards.Sort();
			int head = 0;
			int m = cards.Count;
			int prev = -1;

			while(head < m){
				prev = -1;

				int w = W;
				int i = head;
				while(w > 0){
					--w;

					if(i>=m)
						return false;

					int cardNumber = cards[i];
					if(prev!=-1 && prev+1 != cardNumber){
						return false;
					}

					prev = cardNumber;
					--map[cardNumber];
					if(map[cardNumber] == 0){
						++head;
					}
					++i;
				}
			}

			return true;
		}
	}
}

