#ifndef _295_FIND_MEDIAN_FROM_DATA_STREAM_H_INCLUDED
#define _295_FIND_MEDIAN_FROM_DATA_STREAM_H_INCLUDED

// https://leetcode.com/problems/find-median-from-data-stream/

// NOT FULLY MY SOLUTION - 2ND PASS.
class MedianFinder {
    class MyMaxCompare{
        public:
        bool operator()(const int& a, const int& b){
            return a<b;
        }
    };

    class MyMinCompare{
        public:
        bool operator()(const int& a, const int& b){
            return a>b;
        }
    };

public:
    int n=0;
    priority_queue<int,vector<int>,MyMaxCompare> max_qu;
    priority_queue<int,vector<int>,MyMinCompare> min_qu;

    MedianFinder() {

    }

    void addNum(int num) {
        ++n;
        if(n%2==0){
            // even
            max_qu.push(num);
            int a = max_qu.top();
            min_qu.push(a);
            max_qu.pop();
        }
        else{
            min_qu.push(num);
            int a = min_qu.top();
            max_qu.push(a);
            min_qu.pop();
        }
    }

    double findMedian() {
        if(n%2==0)
            return double(max_qu.top() + min_qu.top())/2;
        else
            return max_qu.top();
    }
};


#endif // _295_FIND_MEDIAN_FROM_DATA_STREAM_H_INCLUDED
