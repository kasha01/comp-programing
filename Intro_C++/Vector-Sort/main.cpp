#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;

/*see: https://www.hackerrank.com/challenges/vector-sort */

int main() {
    /* Enter your code here. Read input from STDIN. Print output to STDOUT */
    int n = 0;
    cin >> n;
    int input=0;
    vector<int> v;
    for(int i=0;i<n;i++){
        cin >> input;
        v.push_back(input);
    }
    //sort(v.begin(),v.end());
    int r;
    for(int i=0; i<n;i++){
        r=v[i];
        cout << r;
    }
    return 0;
}
