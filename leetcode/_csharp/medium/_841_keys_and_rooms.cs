using System;
using System.Collections.Generic;

// https://leetcode.com/problems/keys-and-rooms/
namespace _csharp
{
	public class _841_keys_and_rooms
	{
		public bool CanVisitAllRooms(IList<IList<int>> rooms) {
			int n = rooms.Count;
			bool[] visited = new bool[n];
			Queue<int> qu = new Queue<int>();
			qu.Enqueue(0);

			int totalVisited = 0;
			while(qu.Count > 0){
				int room = qu.Dequeue();    
				if(!visited[room]){
					++totalVisited;
				}
				visited[room] = true;

				var neighbors = rooms[room];
				for(int i=0;i<neighbors.Count;++i){
					int neighbor = neighbors[i];

					if(visited[neighbor]){
						continue;
					}
					qu.Enqueue(neighbor);
				}
			}

			return totalVisited == n;
		}
	}
}

