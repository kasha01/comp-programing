#ifndef COMMON_ELEMENTS_H_INCLUDED
#define COMMON_ELEMENTS_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/common-elements/0
void solve(const vector<long> arr1, const vector<long> arr2, vector<long> arr3, long ni, long nj, long nk){
    long i = 0; long j = 0; long k = 0;

    unordered_set<long> set;

    while (i<ni && j<nj && k<nk) {
        if (arr1 [i] == arr2 [j] && arr1 [i] == arr3 [k] && set.find(arr1[i]) == set.end()) {
            set.insert(arr1 [i]);
            cout << arr1 [i] << " ";
            i++;j++;k++;
            continue;
        }

        if (arr1 [i] <= arr2 [j] && arr1 [i] <= arr3 [k]) {
            i++;
        }
        else if (arr2 [j] <= arr1 [i] && arr2 [j] <= arr3 [k]) {
            j++;
        }
        else if (arr3 [k] <= arr1 [i] && arr3 [k] <= arr2 [j]) {
            k++;
        }
    }

    if(set.empty()){
        cout << -1;
    }
}

void test_input()
{
    int t = 0; cin >> t;
    while (t > 0) {
        t--;
        int n = 0;
        int m = 0;
        int k = 0;
        cin >> n >> m >> k;

        vector<long> arr1;
        for (int i = 0; i < n; ++i) {
            long x = 0; cin >> x;
            arr1.push_back(x);
        }

        vector<long> arr2;
        for (int i = 0; i < m; ++i) {
            long x = 0; cin >> x;
            arr2.push_back(x);
        }

        vector<long> arr3;
        for (int i = 0; i < k; ++i) {
            long x = 0; cin >> x;
            arr3.push_back(x);
        }

        solve(arr1,arr2,arr3,n,m,k);
        cout << endl;
    }
}


void test()
{
    vector<long> arr1 = { 1, 5, 10, 25, 40, 83, 100 };
    vector<long> arr2 = { 6, 7, 20, 80, 100, 230 };
    vector<long> arr3 = { 3, 4, 15, 20, 30, 70, 80, 100 };

    solve (arr1, arr2, arr3,6,5,8);
}


#endif // COMMON_ELEMENTS_H_INCLUDED
