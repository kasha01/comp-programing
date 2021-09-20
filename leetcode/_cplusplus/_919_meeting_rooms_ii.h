#ifndef _919_MEETING_ROOMS_II_H_INCLUDED
#define _919_MEETING_ROOMS_II_H_INCLUDED

// https://www.lintcode.com/problem/919/

class Solution {
public:
    int minMeetingRooms(vector<Interval> &intervals) {
        // Write your code here
        vector<int> start; vector<int> end;
        int n = intervals.size();
        for(int i=0;i<n;++i){
            start.push_back(intervals[i].start);
            end.push_back(intervals[i].end);
        }

        sort(start.begin(),start.end());
        sort(end.begin(),end.end());

        int i=0; int j=0; int maxRooms = 0; int finalRooms=0;
        while(i<n && j<n){
            if(start[i] < end[j]){
                ++maxRooms; ++i;
            }
            else{
                --maxRooms; ++j;
            }
            finalRooms = max(maxRooms,finalRooms);
        }
        return finalRooms;
    }
};

#endif // _919_MEETING_ROOMS_II_H_INCLUDED
