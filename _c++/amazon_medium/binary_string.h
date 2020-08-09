#ifndef BINARY_STRING_H_INCLUDED
#define BINARY_STRING_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/binary-string/0

// f(x) = f(x-1) + (x-1) or nC2, where n=number of 1s, choosing a subset of 2 elements from a set of n elements.
// this will work although it is an invalid combo as we want substring (continguous),
// but it will still work because it will be like this: the far left 1 will combine with the last 1 (r=2 seats),
// which basically can be interpreted as the string from 1st 1 to last 1 i.e. "1000011".
void mt(){
    string s = "";
    int n = s.length();
    int count_one = 0;

    for(int i=0;i<n;++i){
        if(s[i] == '1'){
            count_one++;
        }
    }

    int arr[1001];
    int sz = sizeof(arr);
    memset(arr,0,sz);

    arr[0]=0;
    arr[1]=0;

    for(int i=2;i<=count_one;++i){
        arr[i] = (i-1) + arr[i-1];
    }

    cout << arr[count_one];
}

#endif // BINARY_STRING_H_INCLUDED
