#ifndef TOTAL_DECODING_MESSAGES_H_INCLUDED
#define TOTAL_DECODING_MESSAGES_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/total-decoding-messages/0

// O(n) solution
// ex: 123
int decode(string s){
	int n = s.size();
    int memo[n+1];

    memo[0] = 1;

    for(int i=1;i<=n;++i){
		memo[i] = 0;
        int a = s[i-1] - '0';

        if(a > 0){
            // true means separation of a,b,c and ab,c are allowed
            memo[i] = memo[i-1];
        }

        if(i-2 >= 0){
            int b = s[i-2] - '0';
            if( b > 0){
                int x = b*10 + a;
                if(x<=26){
                    // means separation of a,bc is also allowed. add its result (result of memo[i-2]) to total count
                    memo[i] = memo[i] + memo[i-2];
                }
            }
        }
    }

    return memo[n];
}

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
