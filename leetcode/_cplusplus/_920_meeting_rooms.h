#ifndef _920_MEETING_ROOMS_H_INCLUDED
#define _920_MEETING_ROOMS_H_INCLUDED

// https://www.lintcode.com/problem/920/description

/**
 * Definition of Interval:
 * classs Interval {
 *     int start, end;
 *     Interval(int start, int end) {
 *         this->start = start;
 *         this->end = end;
 *     }
 * }
 */

class Solution {
public:
    /**
     * @param intervals: an array of meeting time intervals
     * @return: if a person could attend all meetings
     */
    static bool cmp( const Interval &v1, const Interval &v2) {
        return v1.start < v2.start;
    }

    bool canAttendMeetings(vector<Interval> &intervals) {
       int n = intervals.size();
       if(n<=1) return true;

       sort(intervals.begin(), intervals.end(), cmp);

       int lastEnd = intervals[0].end;
       for(int i=1;i<n;++i){
           if(intervals[i].start < lastEnd) return false;
           lastEnd = intervals[i].end;
       }

       return true;
    }
};

#endif // _920_MEETING_ROOMS_H_INCLUDED
