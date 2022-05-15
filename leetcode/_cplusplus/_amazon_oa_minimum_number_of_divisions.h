#ifndef _AMAZON_OA_MINIMUM_NUMBER_OF_DIVISIONS_H_INCLUDED
#define _AMAZON_OA_MINIMUM_NUMBER_OF_DIVISIONS_H_INCLUDED

// https://leetcode.com/discuss/interview-question/1200301/Amazon-OA

class MyComparer{
public:
	bool operator()(int& a, int& b){
		return a<b;	// max heap
	}
};

void findMinDision(){
	int arr[] = {16,18,20,30};
	int target= 2;
	int d = 2;
	int n = sizeof(arr)/sizeof(int);

	// key: number | value: priority queue of the count of steps that were required to bring "target" numbers
	// to the same value of "number/key"
	map<int, priority_queue<int, vector<int>, MyComparer>> mp;

	for(int i=0;i<n;++i){
        int x = arr[i];

        // divide x by divider d
        int steps=0;
        while(x>0){
			priority_queue<int, vector<int>, MyComparer> pq;
			if(mp.find(x) != mp.end()){
				pq = mp[x];
			}

			pq.push(steps);
			if(pq.size() > target){
				// if have more numbers than target
				pq.pop();
			}

			mp[x] = pq;

			++steps;
			x=x/d;
        }
	}

	// look for the minimum steps sum for each num quotient
	int ans = INT_MAX;
	map<int, priority_queue<int, vector<int>, MyComparer>>::iterator it;
	for(it = mp.begin(); it!=mp.end(); ++it){
		int steps_sum = 0;
		priority_queue<int, vector<int>, MyComparer> pq = it->second;

		if(pq.size() < target) continue;	// count of quotient (it->first) doesn't equal target

		while(!pq.empty()){
			steps_sum = steps_sum + pq.top();
			pq.pop();
		}

        ans = min(ans, steps_sum);
	}

	cout << (ans == INT_MAX ? -1 : ans) << "\n";
}


#endif // _AMAZON_OA_MINIMUM_NUMBER_OF_DIVISIONS_H_INCLUDED
