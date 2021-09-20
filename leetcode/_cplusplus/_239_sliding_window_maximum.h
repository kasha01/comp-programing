#ifndef _239_SLIDING_WINDOW_MAXIMUM_H_INCLUDED
#define _239_SLIDING_WINDOW_MAXIMUM_H_INCLUDED

// https://leetcode.com/problems/sliding-window-maximum/
vector<int> maxSlidingWindow(vector<int>& nums, int k) {
	deque<int> dq;

	int n = nums.size();
	vector<int> result;
	for(int i=0;i<=k-2;++i){
		int x = nums[i];
		while(!dq.empty() && x >= nums[dq.back()]){
			dq.pop_back();
		}
		dq.push_back(i);
	}

	for(int i=k-1;i<n;++i){
		int x = nums[i];

		// remove any item that is less than or equal the current item (x). as they will never be used.
		while(!dq.empty() && x >= nums[dq.back()]){
			dq.pop_back();
		}

		// make sure that the front (max) item is within the k index.
		while(!dq.empty() && dq.front()<=i-k){
			dq.pop_front();
		}

		dq.push_back(i);

		result.push_back(nums[dq.front()]);
	}

	return result;
}

#endif // _239_SLIDING_WINDOW_MAXIMUM_H_INCLUDED
