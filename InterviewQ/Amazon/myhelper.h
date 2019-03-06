#ifndef MYHELPER_H_INCLUDED
#define MYHELPER_H_INCLUDED

using namespace std;

struct Node
{
public:
    int data;
    Node* left;
    Node* right;
};

class MaxHeap
{

public:
    int heap_size = 0;
    //int vec[7] = {4,7,2,1,6,8,9};
    vector<int> vec;

    void buildMaxHeap(int n)
    {
        vec.push_back(n);
        heap_size = vec.size();
        for(int i=(floor(heap_size/2))-1; i>=0; i--)
        {
            heapify(i);
        }
    };

    void display()
    {
        int s = vec.size();
        for(int i=0; i<s; i++)
        {
            cout << vec[i] << " ";
        }
    };

    void heapsort()
    {
        for (int i = heap_size - 1; i >= 0; i--)
        {
            //swap - heap allows O(1) access to max(max heap)/min(min heap). so we always swap to put the Max at the end. then we heapfiy to rebalance the heap and DECREASE THE heap_size OF THE HEAP, so we don't alter the max value and continue
            int temp = vec[i];
            vec[i] = vec[0];
            vec[0] = temp;
            heap_size = heap_size - 1;
            heapify(0);
        }
    };

    int getMedian()
    {
        int sz = vec.size();
        int mod = sz%2;
        int s = sz/2;
        if(sz>0 && mod==0)
        {
            return (vec[s] + vec[s-1])/2;
        }
        else if(sz >0 && mod != 0)
        {
            return vec[s];
        }
        return -1;
    }

private:
    void heapify(int i)
    {
        int largest = i;
        int l = getLeft(i);
        int r = getRight(i);

        if(l<heap_size && vec[l]>vec[largest])
        {
            largest = l;
        }
        if(r < heap_size && vec[r]>vec[largest])
        {
            largest=r;
        }

        if(i != largest)
        {
            swap(i,largest);
            heapify(largest);
        }
    }

    void swap(int a, int b)
    {
        int temp = vec[a];
        vec[a] = vec[b];
        vec[b] = temp;
    }

    int getLeft(int i)
    {
        return (2*i) + 1;
    }
    int getRight (int i)
    {
        return (2*i) + 2;
    }
};



#endif // MYHELPER_H_INCLUDED
