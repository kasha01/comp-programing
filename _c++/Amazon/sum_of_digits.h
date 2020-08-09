#ifndef SUM_OF_DIGITS_H_INCLUDED
#define SUM_OF_DIGITS_H_INCLUDED

// http://www.geeksforgeeks.org/count-of-n-digit-numbers-whose-sum-of-digits-equals-to-given-sum/
// ex: n=2; sum=5 ==> result => 14, 23, 32, 41 and 50
using namespace std;

int** table;

// recurssive
int dp(int n, int sum, int& c){
    c++;
    if(n==2 && sum <= 9*n){return sum;}
    int s=0;
    for(int i=1; i<=sum; i++){
        s = s + dp(n-1,sum-i, c) + 1;
    }
    return s;
}

// optimized top down
int dp2(int n, int sum, int& c){
    c++;
    // base cases
    if(n==1 && sum <= 9*n){table[sum][n] = sum; return sum;}
    if(n==2 && sum <= 9*n){table[sum][n] = sum; return sum;}

    if(table[sum][n] != -1){return table[sum][n];}

    int s=0;
    for(int i=1; i<=sum; i++){
        s = s + dp2(n-1,sum-i, c) + 1;
    }
    table[sum][n] = s;
    return table[sum][n];
}

void driver()
{
    int n = 5; int sum = 8;
    table = new int*[sum+1];

    for(int i=0; i<=sum; i++){
        table[i] = new int[n+1];
        memset(table[i], -1,(n+1)*sizeof(int));
    }

    int c=0;
    cout << dp(n,sum,c) << endl;
    cout << c;
    return 0;
};


#endif // SUM_OF_DIGITS_H_INCLUDED
