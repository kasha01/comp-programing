using System;
using System.Collections.Generic;

// https://leetcode.com/problems/insert-delete-getrandom-o1/
namespace _csharp
{
	public class _80_insert_delete_getRandom_o_1
	{
		public class RandomizedSet {
			// key:number | value:index
			Dictionary<int,int> map;
			List<int> list;
			Random rd;

			/** Initialize your data structure here. */
			public RandomizedSet() {
				map = new Dictionary<int,int>();
				list = new List<int>();
				rd = new Random();
			}

			/** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
			public bool Insert(int val) {
				if(map.ContainsKey(val)){
					return false;
				}

				list.Add(val);
				map.Add(val,list.Count-1);
				return true;
			}

			/** Removes a value from the set. Returns true if the set contained the specified element. */
			public bool Remove(int val) {
				if(!map.ContainsKey(val)) return false;

				var last_item_index = list.Count - 1;
				var last_item_value = list[last_item_index];
				var item_to_remove_index = map[val];

				// swap last item with item to remove
				list[item_to_remove_index] = list[last_item_index];
				map[last_item_value] = item_to_remove_index;

				// remove
				map.Remove(val);
				list.RemoveAt(last_item_index);

				return true;
			}

			/** Get a random element from the set. */
			public int GetRandom() {
				var random_list_index = rd.Next(0,list.Count);
				return list[random_list_index];
			}
		}

		/**
		 * Your RandomizedSet object will be instantiated and called as such:
		 * RandomizedSet obj = new RandomizedSet();
		 * bool param_1 = obj.Insert(val);
		 * bool param_2 = obj.Remove(val);
		 * int param_3 = obj.GetRandom();
		 */
	}
}