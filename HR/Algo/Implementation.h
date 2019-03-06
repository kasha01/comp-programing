#ifndef IMPLEMENTATION_H_INCLUDED
#define IMPLEMENTATION_H_INCLUDED

using namespace std;

void divisible_sum_pairs(){
// https://www.hackerrank.com/challenges/divisible-sum-pairs
    int n;
    int k;
    int sum=0;
    cin >> n >> k;
    vector<int> a(n);
    for(int a_i = 0;a_i < n;a_i++){
       cin >> a[a_i];
    }

    for(int i=0;i<n-1;i++){
        for(int j=i+1;j<n;j++){
            if((a[i]+a[j])%k==0){
              sum++;
            }
        }
    }
    cout << sum;
}

#endif // IMPLEMENTATION_H_INCLUDED
