#ifndef _GENERATE_PARENTHESES_H_INCLUDED
#define _GENERATE_PARENTHESES_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/generate-all-possible-parentheses/1#
vector<string> ans;
void backtrack(int open, int closed, vector<string>& temp){
	if(open == 0 && closed == 0){
		// print
		int n = temp.size();
		for(int i=0;i<n;++i){
			cout << temp[i];
		}
		cout << "\n";
	}

	if(closed < open) return;

	// open
	if(open > 0){
		temp.push_back("(");
		backtrack(open-1,closed,temp);
		temp.pop_back();
	}

	// close
	temp.push_back(")");
	backtrack(open,closed-1,temp);
	temp.pop_back();
}

void driver()
{
	vector<string> v;
	backtrack(3,3,v);
}


#endif // _GENERATE_PARENTHESES_H_INCLUDED
