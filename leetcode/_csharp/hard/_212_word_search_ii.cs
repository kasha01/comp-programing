using System;
using System.Collections.Generic;

// https://leetcode.com/problems/word-search-ii/
namespace _csharp
{
	public class _212_word_search_ii
	{
		public IList<string> FindWords(char[][] board, string[] words) {
			Node root = new Node();
			var list = new List<string>();
			int n = board.Length; int m = board[0].Length;

			foreach(string word in words){
				addToTrie(root,word);
			}

			for(int i=0;i<n;++i){
				for(int j=0;j<m;++j){
					find(i,j,n,m,board,root,"",list);
				}
			}

			return list.ToArray();
		}

		private void find(int i, int j, int n, int m, char[][] board, Node root, string s, List<string> list){
			if(root == null) return;

			// if the last char is on the edge of the board, then isEndWord won't be true until I go to the next
			// child in which i,j will be out of bound. So I need to make this check here first.
			if(root.isEndWord){
				// when we reach the end of word, we set it to false to avoid duplication. b/c notice in the
				// recursion, we are passing the node 4 times, this causes each word to be repeated 4 times in the
				// result. So when we reach it the word, counted once and falisfy its isEndWord.
				root.isEndWord = false;
				list.Add(s);
			}

			if(i<0 || j<0 || i>=n || j>=m) return;

			char c = board[i][j];
			if(c=='#') return;    // visited

			string cc = s + c;
			int ci = c - 'a';

			if(root.children[ci] == null) return;

			board[i][j] = '#';

			find(i+1,j,n,m,board,root.children[ci],cc,list);
			find(i-1,j,n,m,board,root.children[ci],cc,list);
			find(i,j+1,n,m,board,root.children[ci],cc,list);
			find(i,j-1,n,m,board,root.children[ci],cc,list);

			board[i][j] = c;
		}

		private void addToTrie(Node root, string word){
			Node temp = root;
			foreach(char c in word){
				if(temp.children[c-'a'] == null){
					temp.children[c-'a'] = new Node();
				}

				temp = temp.children[c-'a'];
			}

			temp.isEndWord = true;
		}

		public class Node{
			public Node[] children {get;set;}        
			public bool isEndWord {get;set;}

			public Node(){
				this.isEndWord = false;
				this.children = new Node[26];
			}
		}
	}
}