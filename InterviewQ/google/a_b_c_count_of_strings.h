#ifndef A_B_C_COUNT_OF_STRINGS_H_INCLUDED
#define A_B_C_COUNT_OF_STRINGS_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/count-of-strings-that-can-be-formed-using-a-b-and-c-under-given-constraints/0

// Given a length n, count the number of strings of length n that can be made using
// ‘a’, ‘b’ and ‘c’ with at-most one ‘b’ and two ‘c’s allowed.

// The equation is:
/*
Number of Strings consisting of only A's = 1 (aaaaaaaa)
Number of Strings consisting of only 1 B and rest is A = n (number of ways to arrange B in N slots)
Number of Strings consisting of only 1 C and rest is A = n (number of ways to arrange C in N slots)
Number of Strings consisting of only 2 C and rest is A = n(n-1)/2 (number of ways to arrange C in N slots is n
and to arrange second there is n-1 slots left, we divide by 2 because both Cs are interchangeable)
Number of Strings consisting of only 1 B and 1 C and rest is A = n(n-1).
Number of Strings consisting of only 1 B and 2 C and rest is A = n(n-1)(n-2)/2.

result = 1 + n + n + n(n-1)/2 + n(n-1) + n(n-1)(n-2)
*/

int countstr(int dp[][2][3], int n,int bcount=1,int ccount=2){
    if(bcount<0 || ccount<0){
        return 0;
    }
    if(n==0){
        return 1;
    }
    if(bcount==0 && ccount==0){
        return 1;
    }
    if(dp[n][bcount][ccount]!=-1){
        return dp[n][bcount][ccount];
    }
    int res=countstr(dp,n-1,bcount,ccount);
    res=res+countstr(dp,n-1,bcount-1,ccount);
    res+=countstr(dp,n-1,bcount,ccount-1);
    return (dp[n][bcount][ccount]=res);
}

// optimized - DP
int dp22(int n){
    int dp[n+1][2][3];
    memset(dp,-1,sizeof(dp));
    return countstr(dp,n);
}


int dp(int b, int c, int n){
    if(n==0){return 1;}

    int _count = dp(b,c,n-1);
    if(b>0){_count = _count + dp(b-1,c,n-1);}
    if(c>0){_count = _count + dp(b,c-1,n-1);}
    return _count;
}

void driver()
{
    table[0]=1;
    table[1]=-1; table[2]=-1; table[3]=-1;

    int res = dp2(1,2,2);
    cout << res;
    return 0;
}

#endif // A_B_C_COUNT_OF_STRINGS_H_INCLUDED
