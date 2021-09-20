#include <bits/stdc++.h>

using namespace std;

 long long sum(int n){
        long long ans = 0;
        if(n<=0) return 0;
        ans = n+1;
        ans = ans*n;
        ans = ans/2;
        return ans;
    }

int main()
{
	cout << sum(5);
	vector<int> v = {3,2,1,5,6,4};
    return 0;
}
