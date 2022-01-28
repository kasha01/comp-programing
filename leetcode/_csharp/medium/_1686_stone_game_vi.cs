using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

// https://leetcode.com/problems/stone-game-vi/

/* intuition is: Alice wants to achieve the following formula:
 * a1-b2 >= a2-b1 ==> a1+b1>=a2+b2
 * notice a1-b2. meaning if Alice picks a1 (yielding b1 invalid for pick) and bob picks b2, I want this delta to be larger than the other alternative
 * which is Alice picking a2 and bob picking b1 (a2-b1).
 * */
namespace _csharp
{
	public class _1686_stone_game_vi
	{
		public int StoneGameVI(int[] aliceValues, int[] bobValues) {
			int n = aliceValues.Length;
			int[] keys = Enumerable.Range(0, n).ToArray();

			Array.Sort(keys, (i1,i2) => compare(i1,i2,aliceValues,bobValues));

			int sum_alice=0; int sum_bob=0; bool alice_turn=true;
			foreach(int x in keys){
				if(alice_turn){
					sum_alice = aliceValues[x] + sum_alice;
				}
				else{
					sum_bob = bobValues[x] + sum_bob;
				}           
				alice_turn = !alice_turn;
			}

			if(sum_alice > sum_bob) return 1;
			if(sum_alice < sum_bob) return -1;

			return 0;
		}

		public static int compare(int i1, int i2, int[] aliceValues, int[] bobValues){
			int a = aliceValues[i1] + bobValues[i1];
			int b = aliceValues[i2] + bobValues[i2];

			if(a > b)
				return -1;

			if(a < b)
				return 1;

			return 0;
		}
	}
}