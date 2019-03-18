#include <bits/stdc++.h>

using namespace std;

int main()
{
    ifstream fin;
    fin.open("sample.txt");

    int t=0;
    fin >> t;
    cout << t;

    ofstream fo;
    fo.open("new.txt");

    fo << t;
    return 0;
}
