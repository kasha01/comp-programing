#ifndef WORD_BREAK_2_H_INCLUDED
#define WORD_BREAK_2_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/word-break-part-2/0
void dp(int i, int n, string s, vector<string> &q, set<string> dic){
    if(i==n){
        // this is the last word (word == entire string) - append queue to list
        int sz = q.size();
        string qq = "";
        for(int j=0;j<sz;j++){
            // construct a sentense of all the words in the q vector with spaces between them.
            qq = qq + " " + q[j];
        }
        if(qq != ""){
            cout << "(" << qq.substr(1) << ")";
            // vec.push_back(qq.substr(1));
        }
        else{
            cout << "Empty";
        }
        return;
    }
    string temp = "";
    for(int k=i;k<n;k++){       // k is the counter where space is inserted
        temp= temp+s[k];
        if(dic.find(temp)!=dic.end()){
            q.push_back(temp);  // temp word is found in dictionary, append it to q vector
            dp(k+1,n,s,q, dic); // recurssively do the remaining of the string
            q.erase(q.end()-1); // remove printed word from the queue
        }
    }
}

void driver(){
    vector<string> q;
    vector<string> vec;
    string s = "ilikesamsung";
    set<string> dic = {"i", "like", "sam", "sung", "samsung", "mobile", "ice", "cream", "icecream", "man", "go", "mango"};
    //string s = "snakesandladder";
    //set<string> dic = {"snake", "snakes", "and", "sand", "ladder"};
    dp(0,s.length(),s, q, dic);
}

#endif // WORD_BREAK_2_H_INCLUDED
