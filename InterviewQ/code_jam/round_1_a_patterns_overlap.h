#ifndef ROUND_1_A_PATTERNS_OVERLAP_H_INCLUDED
#define ROUND_1_A_PATTERNS_OVERLAP_H_INCLUDED

bool check_all_remaining_is_star(int i, int n, string s){
    for(int k=i;k<n;k++){
        if(s[k]!='*'){
        return false;
        }
    }
    return true;
}

bool mt(int i, int j, int n, int m, string s1, string s2){
    if(i>=n && j>=m){
        return true;
    }

    //if((i==n && check_all_remaining_is_star(j,m,s2)) || (j==m && check_all_remaining_is_star(i,n,s1))){
    //    return true;
    //}

    //if(i>=n || j>=m){return false;}

    if(i<n && j<m && s1[i] == s2[j]){
        bool result = mt(i+1,j+1,n,m,s1,s2);
        if(result){return true;}
    }

    if(i<n && j<m && s1[i] != s2[j] && s1[i] != '*' && s2[j] != '*'){
        return false;
    }

    if(i<n && s1[i]=='*'){
        for(int x=0;x<=4;++x){
            bool result = mt(i+1,j+x,n,m,s1,s2);
            if(result){return true;}
        }
    }

    if(j<m && s2[j]=='*'){
        for(int x=0;x<=4;++x){
            bool result = mt(i+x,j+1,n,m,s1,s2);
            if(result){return true;}
        }
    }

    return false;
}

void readfile(){
    unordered_set<char> tempset;
    ofstream fo; fo.open("output.txt");
    int tt = 0;
    ifstream fin; fin.open("source.txt");
    fin >> tt;
    string result = "";
    for(int t=1; t<=tt; ++t){
        string A,B="";
        fin >> A >> B;

        int n=A.size();
        int m=B.size();
        //std::transform(A.begin(), A.end(), A.begin(), ::tolower);
        //std::transform(B.begin(), B.end(), B.begin(), ::tolower);
        //cout << A << B;
        bool r = mt(0,0,n,m,A,B);
        if(r){result = "TRUE";}
        else{result="FALSE";}

        fo << "Case #" << t << ": " << result << endl;
    }
}

void test(){
    string s1="GoneGirl*";
    string s2="GoneGirlWind";
    int n=s1.size();
    int m=s2.size();

    bool result = mt(0,0,n,m,s1,s2);
    cout << result;
}


#endif // ROUND_1_A_PATTERNS_OVERLAP_H_INCLUDED
