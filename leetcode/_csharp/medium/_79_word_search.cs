using System;

// https://leetcode.com/problems/word-search/
namespace _csharp
{
	public class _79_word_search
	{
		public bool Exist(char[][] board, string word) {
			for(int i=0;i<board.Length;++i){
				for(int j=0;j<board[0].Length;++j){
					if(board[i][j] == word[0]){
						bool result = rc(i,j,0,board,word);
						if(result) return true;
					}
				}
			}

			return false;
		}

		private bool rc(int x, int y, int i, char[][] board, string word){
			if(i == word.Length)
				return true;

			if(x >= board.Length || y>= board[0].Length || x<0 || y<0)
				return false;

			char c = board[x][y];

			if(c!=word[i])
				return false;

			board[x][y] = '#';
			bool result =  
				rc(x+1,y,i+1,board,word) ||
				rc(x,y+1,i+1,board,word) ||
				rc(x-1,y,i+1,board,word) ||
				rc(x,y-1,i+1,board,word);

			board[x][y] = c;
			return result;        
		}
	}
}