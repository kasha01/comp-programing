#ifndef SORTING_H_INCLUDED
#define SORTING_H_INCLUDED

using namespace std;

void print_array(int* ar,int ar_size){
    for(int i=0;i<ar_size;i++){
        cout << ar[i] << " ";
    }
    cout << endl;
}

void merge_sort(int ar[], int sz){

    if (sz < 2)
    {
        return;
    }

    int mid = sz / 2;
    int left[mid];
    int right[sz-mid];
    for(int ii = 0; ii < mid; ii++)
    {
        left[ii] = ar[ii];
    }
    for (int jj = mid; jj < sz; jj++)
    {
        right[jj - mid] = ar[jj];
    }

    merge_sort(left,mid);
    merge_sort(right, sz-mid);

    int k = 0;
    int i = 0; int j = 0;
    while(i < mid && j < sz-mid)
    {
        if(left[i] < right[j])
        {
            ar[k] = left[i]; i++;
        }
        else
        {
            ar[k] = right[j]; j++;
        }
        k++;
    }

    while (i < mid)
    {
        ar[k] = left[i]; i++; k++;
    }
    while (j < sz-mid)
    {
        ar[k] = right[j]; j++; k++;
    }
}

//https://www.hackerrank.com/challenges/insertion-sort
//using merge sort - count the shifts
long count_shifts_in_insertion_sort(long ar[], int sz){

    if (sz < 2)
    {
        return 0;
    }

    long mid = sz / 2;
    long left[mid];
    long right[sz-mid];
    for(long ii = 0; ii < mid; ii++)
    {
        left[ii] = ar[ii];
    }
    for (long jj = mid; jj < sz; jj++)
    {
        right[jj - mid] = ar[jj];
    }
    long counter=0;
    counter = counter + count_shifts_in_insertion_sort(left,mid);
    counter = counter + count_shifts_in_insertion_sort(right, sz-mid);

    long k = 0;
    long i = 0; long j = 0;

    while(i < mid && j < sz-mid)
    {
        if(left[i] <= right[j])
        {
            ar[k] = left[i]; i++;
        }
        else
        {
            counter = counter + (mid - i); // mid-i is the unsorted remainder of the left array, that right elements have to pass in shifting
            ar[k] = right[j]; j++;
        }
        k++;
    }

    while (i < mid)
    {
        ar[k] = left[i]; i++; k++;
    }
    while (j < sz-mid)
    {
        ar[k] = right[j]; j++; k++;
    }
    return counter;
}

void sortme(int* ar, int ar_size){
//https://www.hackerrank.com/challenges/insertionsort2
    int count = 0;
    for(int i=1; i< ar_size; i++){
        int temp = ar[i];
        int j = i;
        while((j>0) && (temp < ar[j-1])){
            ar[j] = ar[j-1];
            j--;
            count ++;
        }
        ar[j]=temp;
        //print_array(ar,ar_size);
    }
    cout << count << endl;
}

void sortme2(int* ar, int ar_size){
//https://www.hackerrank.com/challenges/insertionsort1
    for(int i=ar_size-1; i>0; i--){
        int temp = ar[i];
        int j = i;
        while((j>0) && (temp < ar[j-1])){
            ar[j] = ar[j-1];
            j--;
            print_array(ar,ar_size);
        }
        ar[j]=temp;
    }
    print_array(ar,ar_size);
}

//Lomuto Quick Sort Algo
//https://www.hackerrank.com/challenges/quicksort3
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
    print_array(ar,sz);
    partition(s,index-1,ar,sz);
    partition(index + 1,e,ar,sz);
    }
}

//****************************************************//

//struct for FullCountingSort
// https://www.hackerrank.com/challenges/countingsort4
struct myobj{
public:
    string name;
    int order;
};

void FullCountingSort(){
    int n = 0;int p=0; string s="";
    cin >> n;
    int half_n = n/2;
    map<int,vector<myobj>> mp;

    for(int i = 0; i<n;i++){
        cin >> p >> s;
        myobj ob;
        ob.name=s;
        ob.order = i;
        mp[p].push_back(ob);
    }

    for(map<int,vector<myobj>>::iterator it=mp.begin(); it!=mp.end(); it++){
        int count = it->second.size();
        for(int j=0;j<count;j++){
            if(it->second[j].order < half_n){
                cout << "-" << " ";
            }
            else{
                cout << it->second[j].name << " ";
            }
            //cout << it->first << " " << it->second[j].name << " " << it->second[j].order << endl;
        }
    }

}

//*********************************************************//

// https://www.hackerrank.com/domains/algorithms/arrays-and-sorting
//Quick Sort - Hoare - used with FindMinDifference
long sort_q(long s, long e, long* ar){
    long i=s;
    long j=e;
    long pivot = ar[(s+e)/2];
    while(i<=j){
        while(ar[i]<pivot){i++;}
        while(ar[j]>pivot){j--;}

        if(i<=j){
            long temp = ar[i];
            ar[i] = ar[j];
            ar[j] = temp;
            i++;
            j--;
        }
    }
    return i;
}

void partition_q(long s, long e, long* ar){
    long index = sort_q(s,e,ar);
    if(index -1 > s){
        partition_q(s, index-1, ar);
    }
    if(index < e){
        partition_q(index, e, ar);
    }
}

void FindMinDifference(){
    long n=0; long p=0;
    cin >> n;
    long ar[n];
    for(long i=0;i<n;i++){
        cin >> p;
        ar[i] = p;
    }

    //sort array - quick sort
    partition_q(0,n-1,ar);

    // Examine min diff
    vector<long> mypairs;
    long mn = abs(ar[1] - ar[0]);
    mypairs.push_back(ar[0]);
    mypairs.push_back(ar[1]);
    for(long i=1;i<n-1;i++){
        long nbs = abs(ar[i] - ar[i+1]);
        if(nbs==mn){
            mypairs.push_back(ar[i]);
            mypairs.push_back(ar[i+1]);
        }
        else if(nbs<mn){
            mn = nbs;
            mypairs.clear();
            mypairs.push_back(ar[i]);
            mypairs.push_back(ar[i+1]);
        }
    }

    for(long i=0; i<mypairs.size(); i++){
        cout << mypairs[i] << " ";
    }
}

//**************************************************//

//find median - using partial selection sort O(kn)
void findMedian(){
    int ar[7] = {0, 1 ,2 ,4 ,6 ,5 ,3};

    //selection sort to k
    int n= sizeof(ar)/sizeof(ar[0]);
    int k = (sizeof(ar)/sizeof(ar[0]))/2;
    //to find the Kth element, set k to (0:smallest E., n-1:largest E., 2:3rd smallest E.)
    for(int i=0; i<=k; i++){
        int minindex = i;
        int minval = ar[i];

        for(int j= i+1; j<n; j++){
            if(ar[j]<minval){
                minval = ar[j];
                minindex = j;
            }
        }

        if(minindex != i){
            ar[minindex] = ar[i];
            ar[i] = minval;
        }
    }

    cout << ar[k];
}

//find median using partial quick sort (Lomuto) O(n + k log k)
// https://www.hackerrank.com/challenges/insertion-sort?h_r=next-challenge&h_v=zen
// This also find the kth element, where s:0, e:last index, k:index of element to find
void partition_find_kth_elemnt_with_lomuto(int s, int e, int* ar, int k){
    if(s<e){
    int index = quicksort(s,e,ar);
    //print_array(ar,sz);
    if(index>k){partition_find_kth_elemnt_with_lomuto(s,index-1,ar,k);}
    else if(index<k){partition_find_kth_elemnt_with_lomuto(index + 1,e,ar,k);}
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
// 3 partition quick sort
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

int part_main(int s, int e, int* ar, int lim){
    int index = 0;
    if(s<e){
    index = quicksort(s,e,ar);
    if(ar[index]<lim){return part_main(index+1,e,ar,lim);}
    if(ar[index]>lim){return part_main(s,index-1,ar,lim);}
    else if(ar[index] == lim){
            return index;
        }
    }
    return 0;
}

void 3_partition_quick_sort(){
    int arr[] = {1, 14, 5, 20, 4, 2, 54, 20, 87, 98, 3, 1, 32};
    int loval=14; int hival=20; int sz = sizeof(arr)/sizeof(arr[0]);

    int ll = part_main(0,sz-1,arr,loval);

    cout << ll << endl;
    for(int i=0;i<sz;i++){
        cout << arr[i] << " ";
    }
    cout << endl;
    part_main(ll+1,sz-1,arr,hival);

    for(int i=0;i<sz;i++){
        cout << arr[i] << " ";
    }
}

// 3 parition sort - dutch flag algo way
void better_way()
{
    int arr[] = {1, 14, 5, 20, 4, 2, 54, 20, 87,
                98, 3, 1, 32};
    int sz = sizeof(arr)/sizeof(arr[0]);

    int lo=10; int hi=20;
    int s=0; int e = sz-1; int i=0;
    while(i<e){
        if(arr[i]<lo){
            swap(arr[i],arr[s]);
            s++; i++;
        }
        else if(arr[i]>hi){
            swap(arr[i],arr[e]);
            e--;  // i dont increment i, in case the swamped in element is also greater than hi
        }
        else{
            // if element == hi or element == lo  --> skip element ++i
            i++;
        }
    }

    for(int i=0;i<sz;i++){
        cout << arr[i] << " ";
    }
    return 0;
}
////////////////////////////////////////////////////////////////////////////////////////////////////////


#endif // SORTING_H_INCLUDED
