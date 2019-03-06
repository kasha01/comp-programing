#ifndef STICKLER_THIEF_H_INCLUDED
#define STICKLER_THIEF_H_INCLUDED

//https://practice.geeksforgeeks.org/problems/stickler-theif/0
// Stickler is a thief and wants to loot money from a society of n houses placed in a line. He is a weird person and
//follows a rule while looting the houses and according to the rule he will never loot two consecutive houses.
// At the same time, he wants to maximize the amount he loots

// not dp solution
int solve(int* arr, int n, bool b){
	if(n<0){
		return 0;
	}

	if(b){
		return max(arr[n]+solve(arr,n-1,false), solve(arr,n-1,true));
	}
	else{
		return solve(arr,n-1,true);
	}
}

// dp solution
long long int dp(int* arr, int n){

	long long int mx = -1;
	long long int memo[n+1][2];
	memo[0][0] = memo[0][1] = 0;
	// first column: this house was selected.
	// second column: this house was skipped

	for(int i=1;i<=n;++i){
		for(int j=0;j<2;++j){
			if(j==0){
				// True column: this house was selected. I can only sum up with the result from column 2 (previous hoouse
				// was skipped)
				memo[i][0] = arr[i-1] + memo[i-1][1];
			}
			else{
				// false column: this house was not selected. I have the freedom to get the result from the previous house
				// whether it was selected column[0] or skipped column[1]
				memo[i][1] = max(memo[i-1][0],memo[i-1][1]);
			}
		}
		mx = max(mx,max(memo[i][0],memo[i][1]));
	}

	cout << mx;
}


#endif // STICKLER_THIEF_H_INCLUDED
