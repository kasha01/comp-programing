#ifndef _215_KTH_LARGEST_ELEMENT_IN_AN_ARRAY_H_INCLUDED
#define _215_KTH_LARGEST_ELEMENT_IN_AN_ARRAY_H_INCLUDED

// https://leetcode.com/problems/kth-largest-element-in-an-array/

class mycomparer{
	public:
	int operator() (const int p1, const int p2){
		return p1 >= p2;
	}
};

int findKthLargest(vector<int>& nums, int k) {
	int n = nums.size();

	priority_queue<int,vector<int>,mycomparer> pq;

	for(int i=0;i<n;++i){
		pq.push(nums[i]);

		if(pq.size()>k)
			pq.pop();
	}

	return pq.top();
}
};

#endif // _215_KTH_LARGEST_ELEMENT_IN_AN_ARRAY_H_INCLUDED
