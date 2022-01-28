#ifndef _692_TOP_K_FREQUENT_WORDS_H_INCLUDED
#define _692_TOP_K_FREQUENT_WORDS_H_INCLUDED

// https://leetcode.com/problems/top-k-frequent-words/
class Solution {
  class MyCompare {
  	public:
  	bool operator()(const pair<string,int>& p1, const pair<string,int>& p2){
  		int freq1 = p1.second; int freq2 = p2.second;
  		string word1 = p1.first; string word2 = p2.first;
  		if(freq1==freq2){
			// if true (word1<word2) flips. so word with higher lexigraphical order will be at top.
  			return word1.compare(word2) < 0;
  		}

  		// if true flips. this will make the item with lower freq at top, so it can be popped first.
  		return freq1>freq2;
  	}
  };

  static bool sortbysec(const pair<string,int> &p1, const pair<string,int> &p2){
  	int freq1 = p1.second; int freq2 = p2.second;
  	string word1 = p1.first; string word2 = p2.first;
  	if(freq1==freq2){
		// if true keeps. so word with lower lexigraphical order will come first.
  		return word1.compare(word2) < 0;
  	}

  	// if true. KEEPS. so item with higher freq will be first.
  	return freq1>freq2;
  }

public:
  vector<string> topKFrequent(vector<string>& words, int k) {
  	map<string,int> mp;

  	int n = words.size();
  	for(int i=0;i<n;++i){
  		mp[words[i]]++;
  	}

  	priority_queue<pair<string,int>,vector<pair<string,int>>,MyCompare> pq;

  	for(map<string,int>::iterator it=mp.begin();it!=mp.end();++it){
  		pq.push(make_pair(it->first,it->second));

  		if(pq.size()>k){
  			pq.pop();
  		}
  	}

  	vector<pair<string,int>> v;
  	while(!pq.empty()){
  		v.push_back(pq.top());
  		pq.pop();
  	}

  	sort(v.begin(), v.end(), sortbysec);

  	vector<string> res;
  	for(int i=0;i<v.size();++i){
  		res.push_back(v[i].first);
  	}

  	return res;
  }
};

#endif // _692_TOP_K_FREQUENT_WORDS_H_INCLUDED
