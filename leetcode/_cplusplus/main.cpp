#include <bits/stdc++.h>

using namespace std;
#define MAX 100
#define RANGE 255


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
		int ask_l = ask[i][0];
		int ask_r = ask[i][1];

		int l = getEqualOrGreater(maxRooms, ask_l);
		int r = getSmaller(maxRooms, ask_r);

		result.push_back(false);

		if(l>=0 && l>=ask_l && l<ask_r)
			result[i] = false;
		else if(r>=0 && r>ask_l && r<ask_r)
			result[i] = false;
		else
			result[i] = true;

		cout << (result[i] ? "true" : "false") << " ";
	}


	return result;
}

int main()
{
    vector<vector<int>> intervals =  {{1, 3}, {4, 6}, {6, 8}, {9, 11}, {6, 9}, {1, 3}, {4, 10}};
    vector<vector<int>> ask = {{1, 9}, {2, 6}, {7, 9}, {3, 5}, {3, 9}, {2, 4}, {7, 10}, {5, 9}, {3, 10}, {9, 10}};
    auto result = meetingRoomIII(intervals, 3, ask);
	return 0;
}
