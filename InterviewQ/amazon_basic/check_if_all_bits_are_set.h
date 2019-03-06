#ifndef CHECK_IF_ALL_BITS_ARE_SET_H_INCLUDED
#define CHECK_IF_ALL_BITS_ARE_SET_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/check-set-bits/0
void mt(){

    // check if n+1 is a power of 2
    int n=7; n = n+1;
    int v = v && (!(n&(n-1)));
    if(v){cout << "YES";}
    else{cout << "NO";}
}

#endif // CHECK_IF_ALL_BITS_ARE_SET_H_INCLUDED
