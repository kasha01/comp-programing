#ifndef DRIVERS_H_INCLUDED
#define DRIVERS_H_INCLUDED
#include "myheader.h"
#include "myhelper.h"

using namespace std;

void Find_first_and_last_occurrence_of_x_Driver(){
//code
	int t = 0; int n=0;
    cin >> t;
    while(t > 0){
        t--;
        cin >> n;
        int arr[n] = {};
        for(int i=0;i<n;i++){
            //int arr[] = {1, 3, 5, 5, 5, 5 ,7, 123 ,125};
            cin >> arr[i];
        }
        int fi = -1; int la=-1;
        int v = 0;
        cin >> v;
        Find_first_and_last_occurrence_of_x(0,n-1,v,fi,la,arr);
        if(fi == -1){
            cout << fi << endl;
        }else{
            cout << fi << " " << la << endl;
        }
    }
}

void Roman_Number_to_Integer_Driver(){
    int t = 0;
    cin >> t;

    string rom;
    while(t>0){
        t--;
        cin >> rom;
        Roman_Number_to_Integer(rom);
    }

}

void Find_all_four_sum_number(){
    int t = 0;
    //int c = 27; int sum = 179;
    //int arr[c] = {88,84,3,51,54,99,32,60,76,68,39,12,26,86,94,39,95,70,34,78,67,1,97,2,17,92,52};
    cin >> t;
    while(t > 0){
        t--;
        int c = 0; int sum = 0;
        cin >> c >> sum;
        int arr[c];
        for(int i=0; i< c; i++){
            cin >> arr[i];
        }
        merge_sort(arr,c);
        findSums(arr, sum, c);
    }
}

void DecodeThePatternDriver(){
    int t = 0;
    int counter = 0;
    cin >> t;
    while(t>0){
        t--;
        cin >> counter;
        DecodeThePattern(counter);
    }
};

void FindMedianInAStreamDriver(){
    MaxHeap heap;
    int c=0;
    cin >> c;
    int n = 0;
    while (c>0){
        c--;
        cin >> n;
        heap.buildMaxHeap(n);
        //heap.display();
        //cout << endl;
        heap.heapsort();
        //heap.display();
        //cout << endl;
        //int m = heap.getMedian();
        cout << heap.getMedian() << endl;
        //cout << endl;
};

#endif // DRIVERS_H_INCLUDED
