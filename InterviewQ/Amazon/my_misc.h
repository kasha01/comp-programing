#ifndef MY_MISC_H_INCLUDED
#define MY_MISC_H_INCLUDED

// http://www.geeksforgeeks.org/count-ways-reach-nth-stair/
/*
check doc for explanation
*/
int countWaysUtil(int n, int m)
{
    int res[n];
    res[0] = 1; res[1] = 1;
    for (int i=2; i<n; i++)
    {
       res[i] = 0;
       for (int j=1; j<=m && j<=i; j++)
         res[i] += res[i-j]; // this is like for(int j=i-1;j>=i-m && j>=0;j-- I mean count all the steps that is m before
         // my current i step. because I can jump from them straight to i. keep in mind, for all res[j], the
         // count includes the dynamic programmed (sub solution) considering m jumps --> this will become
         //for(int j=i-1; j>=i-m && j>=0;j--)
         //res[i] += res[j];
    }
    return res[n-1];
}

// Returns number of ways to reach s'th stair. a person can climb up to m stairs
// Using Fibonacci starting at Index 1
int countWays(int s, int m)
{
    return countWaysUtil(s+1, m);
};

#endif // MY_MISC_H_INCLUDED
