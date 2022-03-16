#ifndef _919_MEETING_ROOMS_II_H_INCLUDED
#define _919_MEETING_ROOMS_II_H_INCLUDED

// https://www.lintcode.com/problem/919/

class Solution {
public:
    /**
     * @param intervals: an array of meeting time intervals
     * @return: the minimum number of conference rooms required
     */
    int minMeetingRooms(vector<Interval> &intervals) {
        // Write your code here
        vector<pair<int,int>> v;
        int n = intervals.size();
        for(int i=0;i<n;++i){
            v.push_back(make_pair(intervals[i].start,1));
            v.push_back(make_pair(intervals[i].end,-1));
        }

        sort(v.begin(),v.end());

        int maxRooms = 0; int sum=0;
        for(int i=0;i<v.size();++i){
            sum = sum + v[i].second;
            maxRooms = max(maxRooms, sum);
        }

        return maxRooms;
    }
};

#endif // _919_MEETING_ROOMS_II_H_INCLUDED
