using System;
using System.Collections.Generic;

// https://leetcode.com/problems/sliding-puzzle/
namespace _csharp
{
	public class _773_sliding_puzzle
	{
		class Node{
			public int zero_index {get;set;}
			public char[] state {get;set;}
			public Node(int i, char[] st){
				this.zero_index = i; this.state=st;
			}
		}

		public int SlidingPuzzle(int[][] board) {
			Queue<Node> qu = new Queue<Node>();
			var visited = new HashSet<string>();
			int z_idx = -1; 
			var init_state = new char[6];

			for(int i=0;i<2;++i){
				for(int j=0;j<3;++j){
					int idx = (i*3) + j;

					if(board[i][j] == 0){
						z_idx = idx;
					}

					init_state[idx] = Convert.ToChar(board[i][j] + '0');
				}
			}                

			int moves = 0;
			qu.Enqueue(new Node(z_idx, init_state));
			while(qu.Count > 0){
				int n = qu.Count;
				for(int i=0;i<n;++i){
					var node = qu.Dequeue();
					var zero_index = node.zero_index;
					var state = node.state;

					if(zero_index == 5 && new String(state) == "123450")
						return moves;

					// up
					if(zero_index >= 3){
						int x = zero_index-3;
						handleNewState(x,zero_index,state,qu,visited);                    
					}

					// down
					if(zero_index < 3){
						int x = zero_index+3;
						handleNewState(x,zero_index,state,qu,visited);
					}

					// left
					if( ((zero_index)%3)-1 >=0){
						int x = zero_index-1;
						handleNewState(x,zero_index,state,qu,visited);
					}

					// right
					if(((zero_index)%3)+1 < 3){
						int x = zero_index+1;
						handleNewState(x,zero_index,state,qu,visited);
					}               
				}

				moves++;
			}

			return -1;
		}

		private void handleNewState(int x, int zero_index, char[] state, Queue<Node> qu, HashSet<string> visited){
			var new_state = new char[6];
			Array.Copy(state,new_state,6);

			char temp = new_state[x];
			new_state[x] = '0';
			new_state[zero_index] = temp;
			string s = new String(new_state);
			if(!visited.Contains(s)){
				qu.Enqueue(new Node(x, new_state));
				visited.Add(new String(new_state));
			}
		}
	}
}