#ifndef SMALLEST_RANGE_K_LIST_H_INCLUDED
#define SMALLEST_RANGE_K_LIST_H_INCLUDED

struct obj{
    int list_name=0;
    int index=0;
    int data=0;

    obj(int i, int d){
        list_name = i;  // up to k lists, list 0, list 1...list k
        index=0;        // index of the minimum item in the list k
        data=d;         // the value of the item
    }
};

bool compare(obj* a, obj* b){
    return a->data <= b->data;
}

void mt(){

    int k = 3;
    int n=5;

    int arr[][n] = {{4, 7, 9, 12, 15},
                    {0, 8, 10, 14, 20},
                    {6, 12, 16, 30, 50}};

    vector<obj*> vec;   // vec is a vector of k objects, carrying the index of minimum item in each list

    for(int i=0;i<k;i++){
        vec.push_back(new obj(i,arr[i][0]));
    }

    int minrange=0;
    int maxrange = INT_MAX;


    while(true){
        // sort vec to get min - this can be optimized to O(n) to get min and max items in the list
        sort(vec.begin(), vec.end(),compare);
        int mn = vec[0]->data;
        int mx = vec[k-1]->data;

        if(mx-mn < maxrange-minrange){
            maxrange = mx;
            minrange = mn;
        }

        vec[0]->index = vec[0]->index + 1;
        if(vec[0]->index >= n){break;}
        vec[0]->data = arr[vec[0]->list_name][vec[0]->index];
    }

    cout << minrange << " " << maxrange;

    for(int i=0;i<k;i++){
        delete vec[i];
    }

    return 0;
}


#endif // SMALLEST_RANGE_K_LIST_H_INCLUDED
