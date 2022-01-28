#include <bits/stdc++.h>

using namespace std;

class mycompare{
public:
	bool operator()(const pair<int,int>& a, const pair<int,int>& b){
		int av = a.first; int bv = b.first;
		return av>bv;
	}
};

int offerings(int N, int arr[]){
	if(N==0) return 0;
	if(N==1) return 1;

	priority_queue<pair<int,int>,vector<pair<int,int>>,mycompare> qu;

	vector<int> v;
	for(int i=0;i<N;++i){
		v.push_back(0);
		pair<int,int> p = make_pair(arr[i],i);
		qu.push(p);
	}

	int offerings=0;
	while(!qu.empty()){
		pair<int,int> p = qu.top();
		qu.pop();

		int idx = p.second;
		if(idx>0 && idx<N){
			int vl=0; int vr=0;
			if(arr[idx] > arr[idx-1]) vl=v[idx-1];
			if(arr[idx] > arr[idx+1]) vr=v[idx+1];
			v[idx] = max(vl,vr)+1;
		}
		else if(idx==0){
			int vr=0;
			if(arr[idx] > arr[idx+1]) vr=v[idx+1];
			v[idx] = vr+1;
		}
		else{
			int vl=0;
			if(arr[idx] > arr[idx-1]) vl=v[idx-1];
			v[idx] = vl+1;
		}

		offerings = offerings + v[idx];
	}

	return offerings;
}

int main()
{
	int arr[] = {5,3,7,3};
	cout << offerings(4,arr);
    return 0;
}
