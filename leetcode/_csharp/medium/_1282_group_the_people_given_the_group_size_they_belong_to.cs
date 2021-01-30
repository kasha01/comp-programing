using System;
using System.Collections.Generic;

// https://leetcode.com/problems/group-the-people-given-the-group-size-they-belong-to/
namespace _csharp
{
	public class _1282_group_the_people_given_the_group_size_they_belong_to
	{
		public IList<IList<int>> GroupThePeople(int[] groupSizes) {

			List<List<int>> result = new List<List<int>>();

			// key:groupSize | value:index of group in result
			Dictionary<int,int> map = new Dictionary<int,int>();

			int n = groupSizes.Length;
			for(int person=0;person<n;++person){
				int groupSize = groupSizes[person];
				if(!map.ContainsKey(groupSize)){
					// i need to create group for size groupSize
					int nextIndex = result.Count;
					map.Add(groupSize,nextIndex);

					// create a new group in result
					result.Add(new List<int>());
				}

				int indexInResult = map[groupSize];
				result[indexInResult].Add(person);

				// check to see if the group is filled. if yes. remove filled group from map
				if(result[indexInResult].Count == groupSize){
					map.Remove(groupSize);
				}
			}

			return result.ToArray();
		}		
	}
}

