#ifndef EQUILIBRIUM_POINT_H_INCLUDED
#define EQUILIBRIUM_POINT_H_INCLUDED

// http://practice.geeksforgeeks.org/problems/equilibrium-point/0

/*Given an array A your task is to tell at which position the equilibrium first occurs in the array.
Equilibrium position in an array is a position such that the sum of elements below it is equal to the sum of elements after it.*/
void equilibrium_point(){
    int t = 0; cin >> t;
    while(t>0){
        t--;
        int c = 0; cin >> c; int arr[c];
        for(int i=0 ; i<c;i++){
        cin >> arr[i];
        }

        //code
        int eq=-1;
        int i=0; int j = c-1; int ni = arr[i]; int nj=arr[j];
        while(i<=j){
            if(ni < nj){i++; ni = ni + arr[i];}
            else if(ni > nj){j--; nj = nj + arr[j];}
            else if(ni==nj){
                if(i==j){/*found*/ eq = i+1; break;}
                else {i++;j--; ni=ni+arr[i]; nj=nj+arr[j];}
            }
        }
        cout << eq << endl;
    }
};

#endif // EQUILIBRIUM_POINT_H_INCLUDED
