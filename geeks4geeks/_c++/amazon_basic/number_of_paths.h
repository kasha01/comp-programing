#ifndef NUMBER_OF_PATHS_H_INCLUDED
#define NUMBER_OF_PATHS_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/number-of-paths/0
int dp(int i, int j, int n, int m){
    if(i>=n || j>=m){return 0;}

    if(i==n-1 && j==m-1){return 1;}

    return dp(i+1,j,n,m) + dp(i,j+1,n,m);
}


#endif // NUMBER_OF_PATHS_H_INCLUDED
