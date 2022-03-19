#ifndef _AMAON_OA_JON_BACKYARD_TREE_CUTTING_H_INCLUDED
#define _AMAON_OA_JON_BACKYARD_TREE_CUTTING_H_INCLUDED

// https://leetcode.com/discuss/interview-question/1171979/a-good-question-of-amazon-sde
/*
There are N trees in Jon's backyard and height of tree i is h[i]. Jon doesn't like the appearance of it and is planning to increase and decrease the height of trees such that the new heights are in strictly increasing order. Every day he can pick one tree and increase or decrease the height by 1 unit. Heights can be 0 or even negative (it's a magical world).

Jon has guests coming after X days, hence he wants to know if it is possible to make heights strictly increasing in no more than X days?

Input format:

First line contains one integer N<=2000 number of trees, X<=5000 number of days Jon has.
Second line contains N space separated integers where ith integer is h[i]

Output Format:

YES or NO, if it is possible to make tree heights in strictly ascending order in no more than X days, if YES, also print the number of days it will take.

Sample Input 1:

5 13
5 4 3 2 1

Sample Output 1:

YES 12
*/
void solve(){
    int nums[] = { 7 ,1 ,4 ,12 ,5 ,8 ,10};	// ans:13
    // int nums[] = { 5,4,3,2,1};
    int X = 12;
    int N = sizeof(nums)/sizeof(int);

    int minn = INT_MAX;
    int maxn = INT_MIN;
    for(int i=0;i<N;++i){
		minn = min(nums[i], minn);
		maxn = max(nums[i], maxn);
    }

    // Observe that making any element of our array less than the minimum or more than maximum would result in extra useless operation, hence j can be in the range of [min(nums), max(nums)], both inclusive. Here we can subtract min values from each element in array just to make the code more readable
    for(int i=0;i<N;++i){
	    nums[i] = nums[i] - minn;
	}

    // dp[i][j] is the minimum number of operations required to make nums[:i+1](till ith index) strictly sorted with nums[i] == j.
    // Hence, our recurrence relation would be: dp[i][j] = abs(nums[i]-j) + min(dp[i-1][:j])
    // This 2D table can be easily converted to 1D dp[j], since we only ever need to know the i-1th state for computing ith state.
    int dp[N][maxn];

    // Initialize base case
    for(int i=0;i<N;++i){
		for(int j=0;j<maxn;++j){
			if(i==0)
				dp[0][j] = abs(nums[0]-j);
			else
				dp[i][j] = INT_MAX;
		}
    }

    for (int i=1;i<N;++i){
		int min_so_far = INT_MAX;
		for(int m=0;m<i;++m){
			min_so_far = min(min_so_far, dp[i-1][m]);
		}

        for (int j=i;j<maxn;++j){ // starting from i to ensure strictly increasing order
            int kk = abs(nums[i]-j) + min_so_far;
            dp[i][j] = abs(nums[i]-j) + min_so_far;
            min_so_far = min(min_so_far, dp[i-1][j]);
		}
    }

    int minStep = INT_MAX;
    for (int k = 0; k<maxn; k++) {
        minStep = min(minStep, dp[N - 1][k]);
    }

    cout << minStep;
}


#endif // _AMAON_OA_JON_BACKYARD_TREE_CUTTING_H_INCLUDED
