#ifndef SHORTEST_COMMON_SUBSEQUENCE_H_INCLUDED
#define SHORTEST_COMMON_SUBSEQUENCE_H_INCLUDED

// http://www.geeksforgeeks.org/shortest-common-supersequence/
char* a = "AB";
char* b = "AF";

// n=2, m=2
int dp(int n, int m){

    if(n==0){return m;}
    if(m==0){return n;}

    if(a[n-1]==b[m-1]){return 1 + dp(n-1,m-1);}
    else {
        return 1+min(dp(n,m-1), dp(n-1,m));
        // min: because I want the shortest subsequence.
        // +1: is for the difference character, that was left out of the min subsequence returned.
        // If I did max: I will get the longest common subsequence which might have a duplicate in the 2nd string.
        // "AB", "AF"...if I used max, I will get wrong result of 4, because:
        // when using max: dp(AB,A) --> will return 2 which is max subsequence (AB), +1 representing A will get 3
        // when using min: dp(AB,A) --> will return 1 which is min subsequence (A), +1 representing the left over character B will get me 2
        // which is correct Lenght of shortest subsequence. Notice when using max, I am counting A TWICE, once included with the max
        // subsequence (AB), and +1 as the left over character which is also SHARED in sequence 1.
    }
}

/* GEEKSFORGEEKS IMPLEMENTATION
 Returns length of LCS for X[0..m-1], Y[0..n-1] */
int lcs( char *X, char *Y, int m, int n)
{
   int L[m+1][n+1];
   int i, j;

   /* Following steps build L[m+1][n+1] in bottom up fashion.
      Note that L[i][j] contains length of LCS of X[0..i-1]
      and Y[0..j-1] */
   for (i=0; i<=m; i++)
   {
     for (j=0; j<=n; j++)
     {
       if (i == 0 || j == 0)
         L[i][j] = 0;

       else if (X[i-1] == Y[j-1])
         L[i][j] = L[i-1][j-1] + 1;

       else
         L[i][j] = max(L[i-1][j], L[i][j-1]);
     }
   }

   /* L[m][n] contains length of LCS for X[0..n-1] and
      Y[0..m-1] */
   return L[m][n];
}

#endif // SHORTEST_COMMON_SUBSEQUENCE_H_INCLUDED
