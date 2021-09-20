using System;
using System.Collections.Generic;

// https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string-ii/
namespace _csharp
{
	public class _1209_remove_all_adjacent_duplicates_in_string_II
	{
		public string RemoveDuplicates(string s, int k) {
			Stack<Node> stack = new Stack<Node>();

			foreach(char c in s){
				if(stack.Count == 0){
					stack.Push(new Node(c,1));
					continue;
				}

				Node pk = stack.Peek();
				if(pk.Key == c){
					if(pk.Value + 1 == k){
						stack.Pop();
					}
					else{
						++stack.Peek().Value;
					}
				}
				else{
					stack.Push(new Node(c,1));   
				}
			}

			string result = "";
			while(stack.Count > 0){
				Node node = stack.Pop();
				for(int i=0;i<node.Value;++i){
					result = node.Key + result;    
				}            
			}        
			return result;
		}

		private class Node{
			public char Key {get;set;}
			public int Value {get;set;}

			public Node(char k, int v){
				this.Key=k; this.Value=v;
			}
		}
	}
}