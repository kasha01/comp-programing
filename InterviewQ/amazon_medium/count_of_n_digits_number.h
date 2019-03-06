#ifndef COUNT_OF_N_DIGITS_NUMBER_H_INCLUDED
#define COUNT_OF_N_DIGITS_NUMBER_H_INCLUDED

// i don't know why this is not working1!!
// https://practice.geeksforgeeks.org/problems/count-of-n-digit-numbers-whose-sum-of-digits-equals-to-given-sum/0

 long long int memo[101][501];

 long long int rc(int n, int sum){

    if(n==0){return sum == 0;}

    if(memo[n][sum]!=-1){return memo[n][sum];}

     long long int x=0;
    for(int i=0; i<=9 && i<=sum;i++){
        if(sum-i>=0){
            x= x+rc(n-1,sum-i);
        }
    }
    x = x%1000000007;
    memo[n][sum] = x;
    return x;
}

void mt(){
     long long int x=0;
    int n=94;
    int sum=336;

    memset(memo, -1, sizeof memo);

    for(int i=1;i<=9 && i<=sum;i++){
        if(sum-i>=0){
            x=x+rc(n-1,sum-i);
        }
    }
    cout << x;

    // 1000000007
}


#endif // COUNT_OF_N_DIGITS_NUMBER_H_INCLUDED
