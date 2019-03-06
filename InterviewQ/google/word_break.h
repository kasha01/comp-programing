#ifndef WORD_BREAK_H_INCLUDED
#define WORD_BREAK_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/word-break/0
bool dp(int i, int n, string s, set<string> dic){
    if(dic.find(s.substr(i,n-i)) != dic.end()){return true;}
    string temp = "";
    for(int k=i;k<n;k++){
        temp= temp+s[k];
        if(dic.find(temp)!=dic.end() && dp(k+1,n,s,dic)){
            return true;
        }
    }
    return false;
}

void driver(){
    string q = "ilikesamsung";
    set<string> dic = {"i", "like", "sam", "sung", "samsung", "mobile", "ice", "cream", "icecream", "man", "go", "mango"};
    dic.insert("fff");
    cout << dp(0,q.length(),q, dic);
}

#endif // WORD_BREAK_H_INCLUDED
