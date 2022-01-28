#ifndef _1249_MINIMUM_REMOVE_TO_MAKE_VALID_PARENTHESES_H_INCLUDED
#define _1249_MINIMUM_REMOVE_TO_MAKE_VALID_PARENTHESES_H_INCLUDED

// https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/
// kinda my solution but i cheated a little bit
string minRemoveToMakeValid(string s) {
	stack<int> st;

	for(int i=0;i<s.size();++i){
		if(s[i]=='('){
			st.push(i);
		}
		else if(s[i]==')'){
			if(!st.empty()){
				st.pop();
			}
			else{
				s[i] = '*'; // no matching '(', so this ')' at location i is deemed for deletion.
							// mark it as '*'
			}
		}
	}

	while(!st.empty()){
		s[st.top()] = '*';    // no match for '('. mark it for deletion
		st.pop();
	}

	// erase-remove idiom
	// https://stackoverflow.com/questions/799314/difference-between-erase-and-remove
	s.erase(remove(s.begin(), s.end(), '*'), s.end());
	return s;
}

#endif // _1249_MINIMUM_REMOVE_TO_MAKE_VALID_PARENTHESES_H_INCLUDED
