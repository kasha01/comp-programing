#ifndef NUMBER_FOLLOWING_PATTERN_H_INCLUDED
#define NUMBER_FOLLOWING_PATTERN_H_INCLUDED


//https://practice.geeksforgeeks.org/problems/number-following-a-pattern/0
void mt(){
    vector<int> vec;
    string s = "DDIDDIID";
    int n = s.length();

    for(int i=1;i<=n+1;++i){
        vec.push_back(i);
    }

    int vi=1;
    int j=0;
    for(int i=0;i<n;++i){
        if(s[i] == 'I'){
            j=vi;
        }
        else if(s[i] == 'D'){
            // sort
            sort(vec.begin()+j,vec.begin()+vi+1,std::greater<int>());
        }
        vi++;
    }

    for(int i=0;i<=n;++i){
        cout << vec[i] << " ";
    }
}

#endif // NUMBER_FOLLOWING_PATTERN_H_INCLUDED
