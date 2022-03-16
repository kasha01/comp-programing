#ifndef _1353_MAXIMUM_NUMBER_OF_EVENTS_THAT_CAN_BE_ATTENDED_H_INCLUDED
#define _1353_MAXIMUM_NUMBER_OF_EVENTS_THAT_CAN_BE_ATTENDED_H_INCLUDED

// https://leetcode.com/problems/maximum-number-of-events-that-can-be-attended/

// THIRD PASS - NOT MY SOLUTION
class Solution {
public:
    class MyComparer{
        public:
        bool operator()(int& a, int& b){
            // sort by ending time. I want to attend events ending first.
            return a > b;
        }
    };

    static bool sortEvents(vector<int>& a, vector<int>& b){
        // sort ascn by start date. much faster than adding everything to priority queue and sift.
        return a[0] < b[0];
    }

    int maxEvents(vector<vector<int>>& events) {

        // sort by start date, faster to sort here than to insert all in priority queue.
        sort(events.begin(), events.end(),sortEvents);

        int current_day = 1;
        priority_queue<int, vector<int>, MyComparer> pq;

        int attended_events=0;
        int i=0; int n=events.size();

        // or I can do while(current_day <= 100000) => This will be faster, but for big endDay will be a problem.
        while(i<n || !pq.empty()){
            // clean up priority queue of overdued events (events that have already ended)
            while(!pq.empty() && pq.top() < current_day)
                pq.pop();

            // insert events that I can attend (events starting at current day)
            while(i<n && events[i][0] == current_day){
                pq.push(events[i][1]);
                ++i;
            }

            if(i<n && pq.empty()){
                // fastforward current day
                current_day = events[i][0]; continue;
            }

            if(!pq.empty()){
                pq.pop();
                ++attended_events;
            }

            ++current_day;
        }

        return attended_events;
    }
};


#endif // _1353_MAXIMUM_NUMBER_OF_EVENTS_THAT_CAN_BE_ATTENDED_H_INCLUDED
