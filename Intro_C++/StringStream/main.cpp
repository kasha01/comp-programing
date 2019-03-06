#include <sstream>
#include <vector>
#include <iostream>

using namespace std;

/* https://www.hackerrank.com/challenges/c-tutorial-stringstream */

vector<int> parseInts(string str) {
   // Complete this function
    vector<int> vec;
    stringstream ss(str);
    char ch;
    int t=0;
    while(!ss.eof()){
        ss >> t >> ch;
        vec.push_back(t);
    }
    return vec;
}

int main() {
    string str;
    cin >> str;
    vector<int> integers = parseInts(str);
    for(int i = 0; i < integers.size(); i++) {
        cout << integers[i] << "\n";
    }

    return 0;
}
