#ifndef MAX_HEAP_HH_INCLUDED
#define MAX_HEAP_HH_INCLUDED


struct Node{
  int data;
  Node* left;
  Node* right;
};

class MaxHeap{

public:
    int size = 7;
    int arr[7] = {4,7,2,1,6,8,9};

    void buildMaxHeap(){
        for(int i=(floor(7/2))-1; i>=0; i--){
            heapify(i);
        }
    };

    void display(){
        for(int i=0; i<7; i++){
            cout << arr[i] << " ";
        }
    };

private:
    void heapify(int i){
        int largest = i;
        int l = getLeft(i);
        int r = getRight(i);

        if(l<size && arr[l]>arr[largest]){largest = l;}
        if(r < size && arr[r]>arr[largest]){largest=r;}

        if(i != largest)
        {
            swap(i,largest);
            heapify(largest);
        }
    }

    swap(int a, int b){
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }

    int getLeft(int i){return (2*i) + 1;}
    int getRight (int i){return (2*i) + 2;}
};

#endif // MAX_HEAP_HH_INCLUDED
