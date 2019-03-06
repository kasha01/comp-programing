#include <iostream>
#include<vector>
#include<algorithm>
#include<stack>
#include<queue>

using namespace std;

void print(string prefix, string s){
    int n = s.length();
    for(int i=1;i<n;i++){
        string s1 = s.substr(0,n-i);
        string s2 = s.substr(n-i);
        cout << prefix << s1 << " " << s2 << endl;
        print(prefix + s1 + " ", s2);
    }
}



int main()
{
	print("","abc");
    return 0;
}
