#ifndef _FIND_ALL_PAIRS_WITH_A_GIVEN_SUM__H_INCLUDED
#define _FIND_ALL_PAIRS_WITH_A_GIVEN_SUM__H_INCLUDED

// https://practice.geeksforgeeks.org/problems/find-all-pairs-whose-sum-is-x5808/1#
vector<pair<int,int>> allPairs(int A[], int B[], int N, int M, int X)
{
	// Your code goes here
	sort(A,A+N); sort(B,B+M);

	int i=0; int j=M-1;

	vector<pair<int,int>> ans;
	while(i<N && j>=0){
		int sum = A[i]+B[j];
		if(sum==X){
			std::pair<int,int> p (A[i],B[j]);
			ans.push_back(p); --j; ++i;
		}
		else if(sum > X){
			--j;
		}
		else{
			++i;
		}
	}

	return ans;
}


#endif // _FIND_ALL_PAIRS_WITH_A_GIVEN_SUM__H_INCLUDED
