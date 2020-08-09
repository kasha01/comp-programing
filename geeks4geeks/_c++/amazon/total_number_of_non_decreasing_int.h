#ifndef TOTAL_NUMBER_OF_NON_DECREASING_INT_H_INCLUDED
#define TOTAL_NUMBER_OF_NON_DECREASING_INT_H_INCLUDED

// http://www.geeksforgeeks.org/total-number-of-non-decreasing-numbers-with-n-digits/

// This is also combination with repetition allowed formula.
// r = number of digits/seats
// n = 10 (0-9)
// There is repetition as, 99, 88 are valid answers.
// This is the confusing part, although this is not entirely a combination but the formula does work according
// to this intepretation. consider {1,2}
// 12 is valid but 21 is not a valid answer, but since I am using Combination (order does not matter), this
// will eliminate my wrong result, I mean 12 and 21 will be counted as one result, in other words
// by ignoring the order we are ignoring the invalid 21 result and only counting the 12 valid result.
// Repetition is allowed, that is okay too, as 11 and 22 are valid results.

int** table;

int dp2(int n, int x){
    if(n==1){table[n][x]=10-x; return table[n][x];}

    if(table[n][x] != 0){return table[n][x];}

    int sum = 0;
    for(int i=x; i<=9; i++){
        sum = sum + dp2(n-1,i);
    }
    table[n][x] = sum;
    return table[n][x];
}


int dp(int n, int x){
    if(n==1){return 10-x;}

    int sum = 0;
    for(int i=x; i<=9; i++){
        sum = sum + dp(n-1,i);
    }
    return sum;
}

void driver()
{
    int n = 2;
    table = new int*[n+1];

    for(int i=0; i<=n; i++){
        table[i] = new int[10+1];
        memset(table[i], 0,(11)*sizeof(int));
    }

    int res = dp2(n,0);
    // int res = dp(n,0); // not memoized
    cout << res;
    return 0;
};

#endif // TOTAL_NUMBER_OF_NON_DECREASING_INT_H_INCLUDED
