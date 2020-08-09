#ifndef MINIMIZE_STRING_VALUE_H_INCLUDED
#define MINIMIZE_STRING_VALUE_H_INCLUDED

void solve(){
    map<char,int> mp;

    std::priority_queue<int> mypq;

    int k=1;
    string st = "abccc";
    int n = st.length();

    for(int i=0;i<n;++i){
        mp[st[i]]++;
    }

    map<char,int>::iterator it;
    for(it = mp.begin(); it!=mp.end(); ++it){
        //cout << it->second << " ";
        mypq.push(it->second);
    }

    while(!mypq.empty() && k >0){
        int tp = mypq.top();
        mypq.pop();
        tp--;
        if(tp>0){
            mypq.push(tp);
        }
        k--;
    }

    int sum=0;
    while(!mypq.empty()){
        sum = sum + pow(mypq.top(),2);
        mypq.pop();
    }

    cout << sum;
}

#endif // MINIMIZE_STRING_VALUE_H_INCLUDED
