#ifndef WORD_BOOGLE_COM_INCLUDED
#define WORD_BOOGLE_COM_INCLUDED

// https://practice.geeksforgeeks.org/problems/word-boggle/0
bool bt(int x, int y, int i, string &word, bool** arr, char** boogle, int &n, int &m){

    if(i>=word.length()){
        return true;
    }

    if(x>=n || x<0 || y>=m || y<0){return false;}

    if(arr[x][y]){return false;}

    if(word[i] != boogle[x][y]){
        return false;
    }

    arr[x][y] = true;
    bool result =
    bt(x,y+1,i+1,word,arr,boogle,n,m) ||
    bt(x,y-1,i+1,word,arr,boogle,n,m) ||
    bt(x+1,y,i+1,word,arr,boogle,n,m) ||
    bt(x-1,y,i+1,word,arr,boogle,n,m) ||
    bt(x+1,y+1,i+1,word,arr,boogle,n,m) ||
    bt(x+1,y-1,i+1,word,arr,boogle,n,m) ||
    bt(x-1,y+1,i+1,word,arr,boogle,n,m) ||
    bt(x-1,y-1,i+1,word,arr,boogle,n,m);

    arr[x][y] = false;

    return result;
}

void driver(){

    vector<string> dic =  {"GEEKS", "FOR", "QUIZ", "GO"};
    char mychar[] = {'G' ,'I' ,'Z' ,'U' ,'E' ,'K' ,'Q' ,'S' ,'E'};

    // to locate where to begin in the Boogle Matrix, it is a map of mychar value and its index
    map<char,vector<pair<int,int>>> mp;
    set<string> boogle; // stores unique results

    int n=3; int m=3;
    char** boog = new char*[n];
    bool** arr = new bool*[n];

    for(int i=0;i<n;i++){
        boog[i] = new char[m];
        arr[i] = new bool[m];
        for(int j=0;j<m;j++){
            arr[i][j] = false;
            char myc = mychar[(i*n) + j];
            mp[myc].push_back(make_pair(i,j));
            boog[i][j] = myc;
        }
    }

    int dsize = dic.size();
    for(int i=0;i<dsize;++i){
        string myword = dic[i];
        if(mp.find(myword[0]) != mp.end()){
            // first letter found
            vector<pair<int,int>> v = mp[myword[0]];

            for(int j=0;j<v.size();++j){
                // get first pair
                int x = v[j].first;
                int y = v[j].second;

                if(bt(x,y,0,myword,arr,boog,n,m)){
                    //cout << myword << endl;
                    boogle.insert(myword);
                }
            }
        }
    }

    if(boogle.empty()){
        cout << -1;
    }
    else{
        for(set<string>::iterator it=boogle.begin(); it!=boogle.end(); ++it){
            cout << *(it) << " ";
        }
    }

    for(int i=0;i<n;++i){
        delete[] arr[i];
        delete[] boog[i];
    }
    delete arr;
    delete boog;
}

#endif // WORD_BOOGLE_COM_INCLUDED
