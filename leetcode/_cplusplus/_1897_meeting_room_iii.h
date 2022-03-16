#ifndef _1897_MEETING_ROOM_III_H_INCLUDED
#define _1897_MEETING_ROOM_III_H_INCLUDED

// https://www.lintcode.com/problem/1897/
class Solution {
public:
    /**
     * @param intervals: the intervals
     * @param rooms: the sum of rooms
     * @param ask: the ask
     * @return: true or false of each meeting
     */

// courtesy of vivek_bansal
// https://leetcode.com/discuss/interview-question/613816/Google-or-Onsite-or-Meeting-Rooms-3

    int getEqualOrGreater(vector<int> v, int target){
        int lo = 0; int hi=v.size()-1; int ans=-1;

        while(lo<=hi){
            int mid = lo + ((hi-lo)/2);

            if(v[mid] > target){
                ans = v[mid];
                hi = mid-1;
            }
            else if(v[mid] < target){
                lo = mid + 1;
            }
            else{
                return v[mid];
            }
        }

        return ans;
    }

    int getSmaller(vector<int> v, int target){
        int lo = 0; int hi=v.size()-1; int ans=-1;

        while(lo<=hi){
            int mid = lo + ((hi-lo)/2);

            // excluding target because that is the end of meeting.
            if(v[mid] < target){
                ans = v[mid];
                lo = mid+1;
            }
            else{
                hi = mid - 1;
            }
        }

        return ans;
    }

    vector<bool> meetingRoomIII(vector<vector<int>> &intervals, int rooms, vector<vector<int>> &ask) {
        int maxPoint = -1;
        for(int i=0;i<intervals.size();++i){
            maxPoint = max(maxPoint, intervals[i][1]);
        }

        vector<int> meetings(maxPoint+1,0);
        for(int i=0;i<intervals.size();++i){
            meetings[intervals[i][0]]++;
            meetings[intervals[i][1]]--;
        }

        vector<int> maxRooms;
        for(int i=1;i<=maxPoint;++i){
            meetings[i] = meetings[i] + meetings[i-1];
            if(meetings[i] == rooms){
                // at this point i, the count of rooms occupied reached max limit rooms
                maxRooms.push_back(i);
            }
        }

        vector<bool> result;
        for(int i=0;i<ask.size();++i){
            int l = getEqualOrGreater(maxRooms, ask[i][0]);
            int r = getSmaller(maxRooms, ask[i][1]);

            int ask_l = ask[i][0];
            int ask_r = ask[i][1];

            result.push_back(false);

            if(l>=0 && l>=ask_l && l<ask_r)
                result[i] = false;
            else if(r>=0 && r>=ask_l && r<ask_r)
                result[i] = false;
            else
                result[i] = true;
        }

        return result;
    }
};

#endif // _1897_MEETING_ROOM_III_H_INCLUDED
