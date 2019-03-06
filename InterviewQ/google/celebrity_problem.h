#ifndef CELEBRITY_PROBLEM_H_INCLUDED
#define CELEBRITY_PROBLEM_H_INCLUDED


// http://practice.geeksforgeeks.org/problems/the-celebrity-problem/1

int matrix[3][3]={
                {0,1,0},
                {0,0,0},
                {0,1,0}
    };

class obj{
public:
    bool iknowsomeone;
    int peopleknowme;
    obj(){
        this->iknowsomeone=false;
        this->peopleknowme=0;
    }
};

void mt()
{
    int n=3;
    obj* arr = new obj[3]();

    int index=-1;
    for(int i=0;i<n;i++){
        for(int j=0;j<n;j++){
            if(matrix[i][j]){
                arr[i].iknowsomeone=true;
                arr[j].peopleknowme = arr[j].peopleknowme+1;
            }
        }
    }

    for(int i=0;i<n;i++){
        if(!arr[i].iknowsomeone && arr[i].peopleknowme == n-1){
            index=i;
        }
    }
    delete[] arr;   //delete memory block allocated in the heap
    cout << index;
    return 0;
}

//========================================================================================
// better solution - Thanks to Sissi Peng

bool knows(int a, int b)
{
    return matrix[a][b];
}

// Returns id of celebrity
int findCelebrity(int n)
{
    // Initialize two pointers as two corners. Person a, person b
    // a, a+1, a+2, a+3......a+n-1. a points to first person, b points to last person
    int a = 0;
    int b = n - 1;

    // if a knows b --> A can't be a celebrity, B is potentially a Celebrity.
    // if a does not know b --> B cannot be a celeb (everybody knows the celeb), A is potentially a celeb.
    while (a < b)
    {
        if (knows(a, b))
            a++;
        else
            b--;
    }

    // Check if a is actually a celebrity or not (there might not be a celebrity in the room)
    for (int i = 0; i < n; i++)
    {
        // If any person doesn't know 'a' or 'a'
        // doesn't know any person, return -1
        if ( (i != a) &&
                (knows(a, i) || !knows(i, a)) )
            return -1;
    }

    return a;
}


#endif // CELEBRITY_PROBLEM_H_INCLUDED
