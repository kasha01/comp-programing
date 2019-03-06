#ifndef MAXIMUM_INDEX_H_INCLUDED
#define MAXIMUM_INDEX_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/maximum-index/0
//  find the maximum of j - i subjected to the constraint of A[i] <= A[j].
//A : [3 5 4 2] ==> output 2 = pair(3,4)
class Point{
public:
    int value;
    int index;

};

int myfunction(Point p1, Point p2){
    // if values are equal, I need to compare their indexes to make sure the value of the lower index comes first
    // so to be included in calculating the distance.
    if(p1.value == p2.value){return p1.index < p2.index;}
    return p1.value < p2.value;
}

void driver(){

    int arr[] = {99,36,24,91,92,45,90,41,49,85,24,64,29,24,24,60,77,81,45,58,19,88,91,25,27,71,63,24,17,4,35,67,91,10,57,82,54,98,22,3,34,97,18,62,73,41,73,1,21,18,58,39,57,100,63,35,70,78,10,38,33,96,5,23,6,13,4,11,63,77,13,48,25,30,62,49,22,86,49,94,3,58,85,12,57,99,98,27,28,8,64,60,3,20,82,8,85,37,71,47,65,83,94,42,65,7,90,38,93,39,32,47,96,68,58,53,66,56,31,94,15,46,53,17,66,87,77,2,23,47,48,40,81,93,81,97,100,70,35,92,60,18,38,8,85,48,60,50,55,42,43,69,87,48,37,4,34,65,5,8,11,52,47,44,97,79,40,48,1,74,91,12,91,80,19,75,27,30,77,33,71,71,53,58,18,90,61,3,54,66,11,17,69,9,60,65,88,51,64,40,25,54,51,67,34,70,94,12,99,70,45,70,92,97,79,10,38,39,12,92,56,74,60,25,83,71,41,22,21,5,61,97,58,63,64,43,32,9,55,83,30,51,4,21,47,82,82,37,72,46,28,28,19,39,52,53,9,44,74,81,48,86,78,58,49,93,52,32,1,6,14,82,8,17,2,55,50,36,91,22,81,70,49,99,60,52,52,68,95,77,100,95,15,77,4,15,69,55,46,21,13,12,2,20,80,56,26,30,91,68,51,71,89,51,21,48,2,72,67,48,1,67,42,15,43,97,29,64,52,26,84,16,37,38,35,69,45,61,98,35,80,100,57,69,2,77,16,3,1,35,2,1,1,96,15,95,92,95,10,95,20,94,10,57,83,45,25,27,57,74,13,36,25,69,56,26,45,72,80,97,58,81,97,58,76,63,4,20,57,14,14,77,59,24,85,41,20,61,19,76,86,31,63,10,99,19,87,95,42,18,44,99};

    int sz = sizeof(arr)/sizeof(arr[0]);
    vector<Point> vec;
    for(int i=0;i<sz;i++){
        Point p; p.index=i;p.value=arr[i];
        vec.push_back(p);
    }

    // by sorthing the array I guarantee that A[j]>=A[i]
    sort(vec.begin(), vec.end(), myfunction);

    int dist=0;
    int mn=vec[0].index;
    for(int i=1;i<sz;i++){
        int ind = vec[i].index;
        mn = min(mn,ind);
        if(ind>mn){dist = max(dist,ind - mn);}
    }
    cout << dist;
}

#endif // MAXIMUM_INDEX_H_INCLUDED
