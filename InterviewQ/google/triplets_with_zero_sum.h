#ifndef TRIPLETS_WITH_ZERO_SUM_H_INCLUDED
#define TRIPLETS_WITH_ZERO_SUM_H_INCLUDED

#include<algorithm>

void mt()
{
    int arr[] = { 0 ,-1 ,2 ,-3 ,1};
    vector<int> v(arr,arr + sizeof(arr)/sizeof(int));
    sort(v.begin(), v.end());
    bool flag=false; int s; int k; int j;
    for(int i=0;i<v.size()-2;i++){
        s=v[i]; j=i+1; k=v.size()-1;
        while(j<k){
            int sum = s+v[j]+v[k];
            if(sum==0){
                flag=true;
                break;
            }
            else if(sum>0){
                k--;
            }
            else if(sum <0){
                j++;
            }
        }
        if(flag){break;}
    }

    if(flag){cout << s << " " << v[j] << " " << v[k];}
    else{cout << "no such triplets exist";}
    return 0;
}


#endif // TRIPLETS_WITH_ZERO_SUM_H_INCLUDED
