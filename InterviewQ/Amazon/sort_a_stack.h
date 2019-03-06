#ifndef SORT_A_STACK_H_INCLUDED
#define SORT_A_STACK_H_INCLUDED

using namespace std;


//////////////////////////////////// MY IMPLEMENTATION //////////////////////////////////////////////////
// https://practice.geeksforgeeks.org/problems/sort-a-stack/1
class SortedStack{
public:
	stack<int> s;
	void sort();
	void sort_in_place();
};

void SortedStack::sort_in_place(){
    if (s.size()< 2)
        return;

    int p = s.top(); s.pop();
    if (p < s.top())
    {
        // swap
        int b = s.top(); s.pop();
        s.push(p);
        p = b;
    }
    sort();
    if (p < s.top())
    {
        s.push(p);
        sort();
    }
    else
    {
        s.push(p);
    }
};

void SortedStack :: sort(){
    // this is slightly faster than in place!
    int temp;
    int sz =s.size();
    int i = 0;
    int arr[sz];
    while(sz > 0)
    {
        int j = i;
        arr[i] = s.top();
        s.pop();
        while(j>0 && arr[j] < arr[j-1])
        {
            // swap
            temp = arr[j];
            arr[j] = arr[j - 1];
            arr[j - 1] = temp;
            j--;
        }
        i++; sz--;
    }

    int az = sizeof(arr)/sizeof(arr[0]);
    for (int k=0; k< az ; k++)
    {
        s.push(arr[k]);
    }
};
////////////////////////////////////////////////////////////////////////////////////////////////////////////


////////////////////////////////////GEEKS FOR GEEKS IMPLEMENTATION USING RECURSSION ////////////////////////
// Recursive function to insert an item x in sorted way
// https://www.geeksforgeeks.org/sort-a-stack-using-recursion/
void sortedInsert(struct stack **s, int x)
{
    // Base case: Either stack is empty or newly inserted
    // item is greater than top (more than all existing)
    if (isEmpty(*s) || x > top(*s))
    {
        push(s, x);
        return;
    }

    // If top is greater, remove the top item and recur
    int temp = pop(s);
    sortedInsert(s, x);

    // Put back the top item removed earlier
    push(s, temp);
}
// Function to sort stack
void sortStack(struct stack **s)
{
    // If stack is not empty
    if (!isEmpty(*s))
    {
        // Remove the top item
        int x = pop(s);

        // Sort remaining stack
        sortStack(s);

        // Push the top item back in sorted stack
        sortedInsert(s, x);
    }
}
//////////////////////////////////////////////////////////////////////////////////////////////////////

void Driver()
{
    int t = 0;
    cin >> t;

    SortedStack st;
    while(t>0){
        t--;
        int n = 0;
        int c = 0; cin >> c;
        while(c>0){
            c--;
            cin >> n;
            st.s.push(n);
        }
        st.sort();
        // print
        int p = 0;
        while(!st.s.empty()){
            p = st.s.top();
            st.s.pop();
            cout << p << " ";
        }
    }
};

#endif // SORT_A_STACK_H_INCLUDED
