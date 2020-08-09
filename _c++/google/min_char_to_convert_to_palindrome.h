#ifndef MIN_CHAR_TO_CONVERT_TO_PALINDROME_H_INCLUDED
#define MIN_CHAR_TO_CONVERT_TO_PALINDROME_H_INCLUDED

// Thanks to ...
// http://practice.geeksforgeeks.org/problems/form-a-palindrome/0
int solveme(string s){
    int n = s.length();
    int dp[n][n];

    for(int i=0; i<n;i++){
        dp[i][i] = 0;
    }

    for(int l=2;l<=n;l++){
        for(int i=0; i<=n-l;i++){
            int j = i+l-1;

            if(l==2){
                if(s[i] == s[j]){dp[i][j]=0;}
                else{dp[i][j]=1;}
            }
            else{
                if(s[i]==s[j]){
                    dp[i][j] = dp[i+1][j-1];
                }
                else{
                    // take the min of whether a char was inserted to the left or to the right + 1
                    // 1 is the char that will make the string palindrome. (to turn ab to palindrome you need)
                    // 1 char (aba or bab). with the same token, a.....b (dots representing the dynamic programmig)
                    // sub problems, so I need the min solution of the sub problems, any subproblem can have
                    // two solution either inserting a char to the left (ab --> bab) or inserting a char to the right
                    // (ab-->aba)...so I pick the minimum
                    dp[i][j] = min(dp[i][j-1], dp[i+1][j]) + 1;
                }
            }
        }
    }

    return dp[0][n-1];
}


#endif // MIN_CHAR_TO_CONVERT_TO_PALINDROME_H_INCLUDED
