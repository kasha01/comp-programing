#ifndef RELATIVE_SORTING_H_INCLUDED
#define RELATIVE_SORTING_H_INCLUDED

map<int,int> mp;
bool compare(int x, int y){

    if(mp.find(x) != mp.end() && mp.find(y) != mp.end()){
        int a = mp[x]; int b=mp[y];
        return mp[x] <= mp[y];
    }
    else if(mp.find(x)!=mp.end() && mp.find(y) == mp.end()){
        return true;
    }
    else if(mp.find(x)==mp.end() && mp.find(y) != mp.end()){
        return false;
    }
    else{
        return x<=y;
    }
}

void driver(){

    vector<int> vec1 = {2, 1, 2, 5, 7, 1, 9, 3, 6, 8, 8};
    vector<int> vec2 = {2,1,8,3};
    int n = 4;
    for(int i=0;i<n;i++){
        mp[vec2[i]] = i;
    }

    sort(vec1.begin(), vec1.end(),compare);

    for(int i=0;i<vec1.size();i++){
        cout << vec1[i] << " ";
    }
}


#endif // RELATIVE_SORTING_H_INCLUDED
