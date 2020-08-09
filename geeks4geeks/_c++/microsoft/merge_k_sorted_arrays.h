#ifndef MERGE_K_SORTED_ARRAYS_H_INCLUDED
#define MERGE_K_SORTED_ARRAYS_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/merge-k-sorted-arrays/1

struct item{
	int value;
	int i;
	int j;
};

// notice here, since this is a priority queue I need to sort descendingly i.e. the largest item comes first. Why?
// b/c priority queue pop returns the last item in the heap and since i want a min priority queue (pop returns
// the smallest item, i sort descendingly
bool operator<(const item& p1, const item& p2)
{
   return p1.value>p2.value;
}

void solve()
{
    int arr[3][3] = {{1, 2, 4},
                    {4, 5, 6},
                    {7, 8, 9}};

    std::priority_queue<item> mypq;

    int k = 3;
    for(int i=0;i<k;++i){
        item myitem;
        myitem.value=arr[i][0];
        myitem.i=i;
        myitem.j=0;
        mypq.push(myitem);
    }


    int c=0;
    int* result = new int[k*k];
    while(!mypq.empty()){
        item _item = mypq.top();
        mypq.pop();

        result[c] = _item.value;
        c++;
        if((_item.j+1) < k){
            int next = arr[_item.i][_item.j+1];
            item new_item;
            new_item.value = next;
            new_item.i = _item.i;
            new_item.j = _item.j+1;
            mypq.push(new_item);
        }
    }

    for(int i=0;i<k*k;++i){
        cout << result[i] << " ";
    }
}


#endif // MERGE_K_SORTED_ARRAYS_H_INCLUDED
