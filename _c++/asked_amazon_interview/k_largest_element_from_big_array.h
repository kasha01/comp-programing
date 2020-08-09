#ifndef K_LARGEST_ELEMENT_FROM_BIG_ARRAY_H_INCLUDED
#define K_LARGEST_ELEMENT_FROM_BIG_ARRAY_H_INCLUDED

void print_array(int* arr, int sz){
    for(int i=0;i<sz;i++){
        cout << arr[i] << " ";
    }
    cout << endl;
}

int quicksort(int lo, int hi, int* ar){
    int pivot = ar[hi];
    int i = lo;
    if(lo<hi){
        for(int j=lo; j< hi; j++){
            if(ar[j]>pivot){
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

void partition_k(int s, int e, int* ar, int k){
    if(s<e){
        int index = quicksort(s,e,ar);
        //print_array(ar,7);
        if(index>k){partition_k(s,index-1,ar,k);}
        else if(index<k){partition_k(index + 1,e,ar,k);}
    }
}

void partition_q(int s, int e, int* ar,int sz){
    if(s<e){
    int index = quicksort(s,e,ar);
    //print_array(ar,sz);
    partition_q(s,index-1,ar,sz);
    partition_q(index + 1,e,ar,sz);
    }
}

void driver()
{
    int n=42; int k=30;
    int arr[] = {335,501,170,725,479,359,963,465,706,146,282,828,962,492,996,943,828,437,392,605,903,154,293,383,422,717,719,896,448,727,772,539,870,913,668,300,36,895,704,812,323,334};

    // sort till the k-th element (this gives me the largest k elements, but those elements are not sorted among
    // each other
    partition_k(0,n-1,arr,k-1);

    // now sort the k-long array descendingly (in case he wanted the elements sorted not just listed)
    partition_q(0,k-1,arr,k);

    for(int i=0;i<k;i++){
        cout << arr[i] << " ";
    }
}


#endif // K_LARGEST_ELEMENT_FROM_BIG_ARRAY_H_INCLUDED
