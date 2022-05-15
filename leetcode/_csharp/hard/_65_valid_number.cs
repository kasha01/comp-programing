using System;
using System.Collections.Generic;

// courtesy of: https://leetcode.com/problems/valid-number/discuss/23728/A-simple-solution-in-Python-based-on-DFA
// https://leetcode.com/problems/valid-number/
// tags: DFA Determinstic Finite Automation
namespace _csharp
{
	public class _65_valid_number
	{
		public bool IsNumber(string s) {
			// current state -> available next states by char [char -> next state]
			var map = new Dictionary<string,int>[9];
			map[0] = new Dictionary<string,int>();

			map[1] = new Dictionary<string,int>(){
				{"sign", 2},
				{"digit", 3},
				{"dot", 4}
			};

			map[2] = new Dictionary<string,int>(){
				{"digit", 3},
				{"dot", 4}
			};

			map[3] = new Dictionary<string,int>(){
				{"digit", 3},
				{"dot", 5},
				{"e", 6}
			};

			map[4] = new Dictionary<string,int>(){
				{"digit", 5},
			};

			map[5] = new Dictionary<string,int>(){
				{"digit", 5},
				{"e", 6},
			};

			map[6] = new Dictionary<string,int>(){
				{"sign", 7},
				{"digit", 8},
			};

			map[7] = new Dictionary<string,int>(){
				{"digit", 8},
			};

			map[8] = new Dictionary<string,int>(){
				{"digit", 8},
			};

			int currentState = 1;
			foreach(char c in s){

				string stateKey = "";
				if(c=='+' || c=='-'){
					stateKey = "sign";
				}
				else if(c >='0' && c<= '9'){
					stateKey = "digit";
				}
				else if(c=='e' || c=='E'){
					stateKey = "e";
				}
				else if(c=='.'){
					stateKey = "dot";
				}
				else{
					return false;
				}

				var state_map = map[currentState];
				if(!state_map.ContainsKey(stateKey)){
					return false;
				}

				int nextState = state_map[stateKey];
				currentState = nextState;
			}

			// valid terminal states
			if(currentState == 3 || currentState == 5 || currentState == 8) return true;

			return false;
		}
	}
}