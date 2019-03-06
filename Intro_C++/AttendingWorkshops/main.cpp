#include<bits/stdc++.h>

/*see: https://www.hackerrank.com/challenges/attending-workshops */
/*UNFINISHED - NOT DONE*/

using namespace std;
//Begin My Code
typedef struct{
public:
    int startTime=0;
    int endTime=0;
    int duration=0;
}Workshop;

typedef struct{
public:
    int size=0;
    Workshop* workshop_array;
}Available_Workshops;

Available_Workshops* initialize (int start_time[], int duration[], int n){
    static Available_Workshops* ptr = new Available_Workshops();

    ptr->workshop_array = new Workshop[n];
    ptr->size = n;

    for(int i=0;i<n;i++){
            ptr->workshop_array[i].startTime = start_time[i];
            ptr->workshop_array[i].duration = duration[i];
            ptr->workshop_array[i].endTime= start_time[i] + duration[i];
        }
    return ptr;
};

int CalculateMaxWorkshops(Available_Workshops* ptr){
    int ptr_size = ptr->size;
    int cur_end = 0;
    static int maxWorkshops = 0;
    for(int i=0; i< ptr_size; i++){
        if(ptr->workshop_array[i].startTime >= cur_end){
            cur_end = ptr->workshop_array[i].endTime;
            maxWorkshops++;
        }
    }
    return maxWorkshops;
};

//End My Code


int main(int argc, char *argv[]) {
    int n; // number of workshops
    cin >> n;
    // create arrays of unknown size n
    int* start_time = new int[n];
    int* duration = new int[n];

    for(int i=0; i < n; i++){
        cin >> start_time[i];
    }
    for(int i = 0; i < n; i++){
        cin >> duration[i];
    }

    Available_Workshops * ptr;
    ptr = initialize(start_time,duration, n);
    cout << CalculateMaxWorkshops(ptr) << endl;
    return 0;
}
