#ifndef GENERATE_BINARY_STRING_H_INCLUDED
#define GENERATE_BINARY_STRING_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/generate-binary-string/0
// 1??0?101 ==> 10000101 10001101 10100101 10101101 11000101 11001101 11100101 11101101
void dp(string s, int n, const string arr, const int sz){

    if(n==sz){
        if(s != ""){cout << s << endl;}
        return;
    }

    if(arr[n] != '?'){dp(s+arr[n],n+1,arr, sz);}
    else{
        dp(s+'0',n+1, arr, sz);
        dp(s+'1',n+1, arr, sz);
    }
}

void driver()
{
    int t=0; cin >> t;
    while(t>0){
        t--;
        string mystring = ""; cin >> mystring;
        int l = mystring.length();
        dp("",0,mystring,l);
    }
}

#endif // GENERATE_BINARY_STRING_H_INCLUDED
