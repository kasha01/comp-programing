#ifndef _300_MEETING_ROOM_IV_H_INCLUDED
#define _300_MEETING_ROOM_IV_H_INCLUDED

// https://www.lintcode.com/problem/300/description

class Solution {
public:
    /**
     * @param meeting: the meetings
     * @param value: the value
     * @return: calculate the max value
     */

    // recurssion+memo won't work as meeting vector can be large. so we have to loop by max end time.
    // courtesy of https://www.lintcode.com/user/%E5%BD%A9%E8%9D%B6%E5%AF%BB%E6%A2%A6/
    int maxValue(vector<vector<int>> &meeting, vector<int> &value) {
        int n = meeting.size();
        int max_end_time = -1;

        // end time | list of pair(start time, value)
        map<int,vector<pair<int,int>>> mp;
        for(int i=0;i<n;++i){
            mp[meeting[i][1]].push_back(make_pair(meeting[i][0], value[i]));
            max_end_time = max(max_end_time, meeting[i][1]);
        }

        int dp[max_end_time+1];
        dp[0] = 0;

        for(int i=1;i<=max_end_time;++i){
            dp[i] = dp[i-1];

            if(mp.find(i) == mp.end()) continue;

            // loop through all meetings that end at end time i and pick the meeting that can get me the largest value
            auto v = mp[i];
            for(int j=0;j<v.size();++j){
                int meeting_start = v[j].first;
                int meeting_value = v[j].second;
                dp[i] = max(dp[i], meeting_value + dp[meeting_start]);
            }
        }

        return dp[max_end_time];
    }


    // solution using recurssion+memoization. But it times out b/c meeting is too large.
    int rc(int start, int prevMeetingEnd, int n, vector<pair<vector<int>,int>> v, vector<vector<int>> &memo){
        if(start >= n) return 0;

        if(memo[start][prevMeetingEnd]) return memo[start][prevMeetingEnd] - 1;

        // skip meeting
        int sum = rc(start+1,prevMeetingEnd,n,v,memo);

        for(int i=start;i<n;++i){
            vector<int> meeting = v[i].first;
            int value = v[i].second;

            if(meeting[0] < prevMeetingEnd) continue; // cannot go to this meeting

            int s = value + rc(i+1,meeting[1],n,v,memo);
            sum = max(sum, s);
        }

        memo[start][prevMeetingEnd] = sum+1;
        return sum;
    }

	int maxValue_rc(vector<vector<int>> &meeting, vector<int> &value) {
        int n = meeting.size();

        // meething | value
        vector<pair<vector<int>,int>> v;
        for(int i=0;i<n;++i){
            v.push_back(make_pair(meeting[i],value[i]));
        }

        sort(v.begin(), v.end());

        vector<int> t(50001,0);
        vector<vector<int>> memo(n,t);

        int ans = rc(0, 0, n, v, memo);
        return ans;
    }
};

#endif // _300_MEETING_ROOM_IV_H_INCLUDED
