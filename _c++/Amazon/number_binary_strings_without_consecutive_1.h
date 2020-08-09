#ifndef NUMBER_BINARY_STRINGS_WITHOUT_CONSECUTIVE_1_H_INCLUDED
#define NUMBER_BINARY_STRINGS_WITHOUT_CONSECUTIVE_1_H_INCLUDED

// Many thanks to Snehabewafa
// http://www.geeksforgeeks.org/count-number-binary-strings-without-consecutive-1s/
// http://ideone.com/fEQpKe
// this problem can also be solved with fibonacci: count of binary strings = Fib[n+2]
// check--> https://en.wikipedia.org/wiki/Fibonacci_number#Use_in_mathematics
/*
initial condition
n=0 => 0 binary strings
n=1 => 2 binary strings ==> 0,1
n=2 => 3 binary strings ==> 00, 01, 10 (11 has consecutive 1s so it is excluded from count)
n=3 ?
I have 3 empty slots _ _ _
the last bit can either be 0 or 1:
- if last bit is 0 ==> 0_ _ ==> count of binary strings I can have without consecutive 1s in 2 bits slot is dp[2] = 3(initial condition)
- if last bit is 1 ==> 1 _ _ ==> the second bit cannot be 1, it must be zero ==> 00_ ==> count of binary strings I can have
without consecutive 1s in 1 bit slot is dp[1] = 2(initial condition)
so dp[3] = d[2] + dp[1] = 2 + 3 = 5

and so on for dp[4]...etc
*/
void count_number_binary_strings_without_consecutive_1()
{
    int t,n;
    cin>>t;
    while(t--)
    {
        cin>>n;
        int dp[n+1];
        dp[0]=0;
        dp[1]=2;
        dp[2]=3;
        for(int i=3;i<=n;i++){
            dp[i]=dp[i-1]+dp[i-2];
        }
        cout<<dp[n]<<endl;
    }
}

#endif // NUMBER_BINARY_STRINGS_WITHOUT_CONSECUTIVE_1_H_INCLUDED
