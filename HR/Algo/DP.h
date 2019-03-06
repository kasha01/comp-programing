#ifndef DP_H_INCLUDED
#define DP_H_INCLUDED

using namespace std;

int score(vector<int> a) {

    int s=a.size(); int i=0,j=s-1,count=1;vector<int> v1; vector<int> v2; long sum1=0,sum2=0;
  while(count<=s){
        if(sum1>sum2) {
            sum2+=a[j]; v2.push_back(a[j]); j--;
        } else {
            sum1+=a[i]; v1.push_back(a[i]); i++;
        }
    count++;
}
if(sum1!=sum2)return 0;
if(sum1==0&&sum2==0) return s-1;
return 1+max(score(v1),score(v2));
}

void max_contiguous_and_non_contiguous_sum_subarray(){
    int arr[]  = { -10,-1,-2,-3,-4,-5};

    //Kadane Algo.
        long global_positive=0;
        long p=0;
        long cur_max=0; long global_max=0;
        cur_max = arr[0];
        global_max = cur_max;

        global_positive = cur_max;

        for(int i=1; i<6;i++){
            p = arr[i];
            global_positive = max(p,max(global_positive,global_positive+p));
            cur_max = max (p,cur_max + p);
            global_max = max(cur_max,global_max);
        }
        cout << global_max << " " << global_positive << endl;
}

void SubSetSum(){
    int sum = 23;
    int arr[7] = {10, 2, 3, 4, 5, 7, 8};
    int sz = sizeof(arr)/sizeof(arr[0]);
    bool sub[sz+1][sum+1];

    for(int k=0; k<sz+1;k++){
        sub[k][0] = true;
    }

    for(int k=1; k<sum+1; k++){
        sub[0][k] = false; // empty set and sum != 0 that is why I started from 1
    }

    for(int j = 1; j < sz+1; j++){
        for(int i=1; i<sum+1; i++){
            // get the thing above me
            sub[j][i] = sub[j-1][i];

            // if it is NOT set
            if(!sub[j][i]){
                if(i-arr[j-1] >=0){ // to prevent exception
                    sub[j][i] = sub[j-1][i-arr[j-1]];
                }
            }
        }
    }

    if(sub[sz][sum]){
        cout << "True" << endl << endl;
    }

    cout << "   ";
    for(int i=0; i< sum+1;i++){
        if(i<10){cout << i << "  ";}
        else {cout << i << " ";}
    }
    cout << endl;

    for(int j=0; j<sz+1;j++){

        if(j==0){cout << 'x' << "  ";}
        else if(arr[j-1]<10){cout << arr[j-1] << "  ";}
        else {cout << arr[j-1] << " ";}

        for(int i=0; i< sum+1;i++){
            cout << sub[j][i] << "  ";
        }
        cout << endl;
    }

}

#endif // DP_H_INCLUDED
