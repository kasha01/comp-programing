#ifndef _903_RANGE_ADDITION_H_INCLUDED
#define _903_RANGE_ADDITION_H_INCLUDED

// https://www.lintcode.com/problem/903/
vector<int> getModifiedArray(int length, vector<vector<int>> &updates) {
	// Write your code here
	vector<int> v;
	map<int,int> mp;

	int n = updates.size();
	for(int i=0;i<n;++i){
		int start = updates[i][0];
		int end = updates[i][1] + 1;
		int inc = updates[i][2];

		mp[start] = mp[start] + inc;
		mp[end] = mp[end] - inc;
	}

	int current_inc = 0;
	for(int i=0;i<length;++i){
		if(mp.find(i) != mp.end()){
			current_inc = current_inc + mp[i];
		}
		v.push_back(current_inc);
	}

	return v;
}

#endif // _903_RANGE_ADDITION_H_INCLUDED
