#ifndef STAR_ELEMENT_INCLUDED
#define STAR_ELEMENT_INCLUDED

// https://practice.geeksforgeeks.org/problems/start-elements/0

// The task is to find all the star and super star elements in the array. Star are those elements which are strictly
// greater than all the elements on its right side. Super star are those elements which are strictly greater than all
// the elements on its left and right side.
void solve(){
    stack<int> st;
    int arr[] = {8,6,5};
    int n=3;

    int super_star_element=-1;
    bool super_star_is_dirty = false;
    for(int i=n-1;i>=0;--i){
        if(arr[i] > super_star_element){
            super_star_element = arr[i];
            super_star_is_dirty = false;
        }
        else if(arr[i] == super_star_element){
            super_star_is_dirty = true;
        }

        // push star elements
        if(st.empty()){
            st.push(arr[i]);
        }
        else if(st.top()< arr[i]){
            st.push(arr[i]);
        }
    }

    if(!super_star_is_dirty){
        cout << "super star is: " << super_star_element << endl;
    }
    else{
        cout << -1 << endl;
    }

    while(!st.empty()){
        cout << st.top() << " ";
        st.pop();
    }
}

#endif // STAR_ELEMENT_INCLUDED
