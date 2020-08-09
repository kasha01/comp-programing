#ifndef FID_ALL_PAIRS_WITH_A_GIVEN_SUM_H_INCLUDED
#define FID_ALL_PAIRS_WITH_A_GIVEN_SUM_H_INCLUDED

// similar question with 1 array. ex:  {1, 5, 7, -1}, sum=6 -> there are 2 pairs
// http://www.geeksforgeeks.org/count-pairs-with-given-sum/
// between two arrays
int quicksort(int lo, int hi, int* ar){
    int pivot = ar[hi];
    int i = lo;
    if(lo<hi){
        for(int j=lo; j< hi; j++){
            if(ar[j]<pivot){
                int temp = ar[j];
                ar[j] = ar[i];
                ar[i]=temp;
                i++;
            }
        }
    }
    ar[hi] = ar[i];
    ar[i] = pivot;
    return i;
}

void partition(int s, int e, int* ar,int sz){
    if(s<e){
    int index = quicksort(s,e,ar);
    //print_array(ar,sz);
    partition(s,index-1,ar,sz);
    partition(index + 1,e,ar,sz);
    }
}

void find_all_pairs_with_a_given_sum(){
    vector<pair<int,int>> v;

    int a = 0; int b = 0; int x = 0;
    int t = 0; cin >>t;
    while(t>0){
        t--; v.clear();
        cin >> a >> b >> x;
        int arr1[a]; int arr2[b];
        for(int i=0; i<a;i++){cin >> arr1[i];}
        for(int j=0; j<b;j++){cin >> arr2[j];}

        partition(0,a-1,arr1,a);    // sort arr1 asc
        partition(0,b-1,arr2,b);    // sort arr2 desc

        // logic
        int pa = 0; int pb = b-1; int sum = 0;
        while(pa<a && pb >= 0){
            sum = arr1[pa] + arr2[pb];
            if(sum == x){
                // count similar pa
                int arr_a = arr1[pa]; int sa = 0;
                while(pa < a && arr1[pa] == arr_a){
                    sa++;pa++;
                }

                // count similar pb
                int arr_b = arr2[pb]; int sb = 0;
                while(pb >= 0 && arr2[pb] == arr_b){
                    sb++; pb--;
                }

                int ts = sa*sb;
                while(ts>0){
                    ts--;
                    //cout << arr_a << " " << arr_b << endl;
                    v.push_back(make_pair(arr_a,arr_b));
                }
            }
            else if(sum > x){pb--;}
            else if(sum < x){pa++;}
        }

        // print
        if(v.size()>0){
            for(int i=0; i< v.size()-1;i++){
                cout << v[i].first << " " << v[i].second << ", ";
            }
            cout << v[v.size()-1].first << " " << v[v.size()-1].second;
        }
        else {cout << -1;}
        cout << endl;
    }
}

#endif // FID_ALL_PAIRS_WITH_A_GIVEN_SUM_H_INCLUDED
