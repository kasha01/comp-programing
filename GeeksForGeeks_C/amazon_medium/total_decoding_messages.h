#ifndef TOTAL_DECODING_MESSAGES_H_INCLUDED
#define TOTAL_DECODING_MESSAGES_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/total-decoding-messages/0
int dp(int n, string const s, int const N){

    if(n>=N){
        return 1;
    }

    int a = s[n]-'0';
    if(a==0){return 0;}

    int r1 = dp(n+1,s,N);

    int r2=0;
    if(n+1<N){
        int b = (a*10)+(s[n+1] - '0');
        if(b<=26){
            r2 = dp(n+2,s,N);
        }
    }

    return r1+r2;
}

void driver()
{
    string s = {"1234"};
    int res = dp(0,s,4);
    cout << res;
}


#endif // TOTAL_DECODING_MESSAGES_H_INCLUDED
