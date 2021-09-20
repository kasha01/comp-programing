#ifndef _767_REORGANIZE_STRING_H_INCLUDED
#define _767_REORGANIZE_STRING_H_INCLUDED

// https://leetcode.com/problems/reorganize-string/

class myComparator{
public:
	int operator() (const pair<char,int> p1, const pair<char,int> p2)
	{
		return p1.second < p2.second;
	}
};

string reorganizeString(string s) {
	int n = s.size();
	map<char,int> mp;
	priority_queue<pair<char,int>, vector<pair<char,int>>, myComparator> pq;

	for(int i=0;i<n;++i){
		mp[s[i]]++;
	}

	for(map<char,int>::iterator it=mp.begin(); it!=mp.end(); ++it){
		pair<char,int> p = make_pair(it->first, it->second);
		pq.push(p);
	}

	string result = "";
	char prev = '\0';
	while(!pq.empty()){
		auto t = pq.top();
		pq.pop();
		char ch = t.first;
		int _count = t.second;
		if(ch != prev){
			prev = ch;
			if(_count > 1){
				pq.push(make_pair(t.first, _count-1));
			}
		}
		else {
			if(pq.empty()){
				return "";
			}
			auto secondTop = pq.top();
			pq.pop();
			ch = secondTop.first;
			int _count = secondTop.second;
			prev = ch;
			if(_count > 1){
				pq.push(make_pair(secondTop.first, _count-1));
			}
			pq.push(t);
		}

		result = result + ch;
	}

	return result;
}

#endif // _767_REORGANIZE_STRING_H_INCLUDED
