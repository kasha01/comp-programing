#ifndef SPECIAL_MATRIX_H_INCLUDED
#define SPECIAL_MATRIX_H_INCLUDED

/**NOT MY SOLUTION*/

/**
SOLUTION OF abhishek Handacse (abhishekhandacse)
https://github.com/abhishekhandacse/NotesAlgorithmsDS.cpp/commit/f76fb6acb3eaed38c3ace525a5720bf05a05677f
*/

// https://practice.geeksforgeeks.org/problems/special-matrix/0
#define MOD 1000000007

using namespace std;

// top down
int ways(vector<vector<int>> &mat){
	int n=mat.size();
	int m=mat[0].size();
	vector<vector<int>> dp(n,vector<int>(m,0));
//	First Row
	for(int j=0;j<m;j++)
		if(mat[0][j])
			break;
		else dp[0][j]=1;
// First Col
	for(int i=0;i<n;i++)
		if(mat[i][0])
			break;
		else dp[i][0]=1;
// Main dp table
	for(int i=1;i<n;i++){
		for(int j=1;j<m;j++){
			if(!mat[i][j])
				dp[i][j]=((dp[i-1][j]+dp[i][j-1])%MOD);
		}
	}
	return dp[n-1][m-1];
}

int main(){

	int tc;
	cin>>tc;
	while(tc--){
		int N,M,K;
		cin>>N>>M>>K;
		vector<vector<int>> mat(N,vector<int>(M,0));

		int i,j;
		while(K--){
			cin>>i>>j;
			i--;j--;
			mat[i][j]=1;
		}

		cout<<ways(mat)<<endl;
	}



	return 0;
}

#endif // SPECIAL_MATRIX_H_INCLUDED
