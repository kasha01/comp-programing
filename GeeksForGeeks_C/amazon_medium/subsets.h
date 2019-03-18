#ifndef SUBSETS_H_INCLUDED
#define SUBSETS_H_INCLUDED

// print all subsets, in lexographical order, no duplicate subsets.
// [1,2,2] ==>  ()(1)(1 2)(1 2 2)(2)(2 2)
// [1,2,3,3]=>  ()(1)(1 2)(1 2 3)(1 2 3 3)(1 3)(1 3 3)(2)(2 3)(2 3 3)(3)(3 3)

// https://practice.geeksforgeeks.org/problems/subsets/0
// kind of back tracking
set<string> st;
void bt(int n, int const m, vector<string> &vec, string s){
    if(n>=m){
        s = s.substr(0,s.length()-1);
        if(st.find(s) == st.end()){
            st.insert(s);
        }
        return;
    }

    bt(n+1,m,vec,s);
    bt(n+1,m,vec,s + vec[n] + " ");
}

void mt(){

    int arr[] = {1,2,3};

    vector<string> vec = {"2","1","2"};
    sort(vec.begin(), vec.end());

    bt(0,3,vec,"");

    while(!st.empty()){
        cout << '(' << *st.begin() << ')';
        st.erase(st.begin());
    }
}


#endif // SUBSETS_H_INCLUDED
