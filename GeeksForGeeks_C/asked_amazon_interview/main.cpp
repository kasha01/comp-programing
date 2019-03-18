#include<iostream>
#include<vector>
#include<cmath>
#include<algorithm>
#include<climits>
#include<sstream>

using namespace std;

int main22(){
    int i = 0x123456;

    int* i_p = &i;

    cout << *(i_p) << endl;


    char* start = (char*) &i;
    printf("%.2x", start[0]);
    return 0;
}
