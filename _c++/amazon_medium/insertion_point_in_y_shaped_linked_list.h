#ifndef INSERTION_POINT_IN_Y_SHAPED_LINKED_LIST_H_INCLUDED
#define INSERTION_POINT_IN_Y_SHAPED_LINKED_LIST_H_INCLUDED

// https://practice.geeksforgeeks.org/problems/intersection-point-in-y-shapped-linked-lists/1
int intersectPoint(Node* head1, Node* head2)
{
    set<Node*> st;
    st.clear();

    bool mergeFound = false;
    int mergePoint = -1;
    while(head1 && !mergeFound){
        if(st.find(head1) == st.end()){
            // not found
            st.insert(head1);
            head1=head1->next;
        }
        else{
            // found
            mergeFound = true;
            mergePoint = head1->data;
        }
    }


    while(head2 && !mergeFound){
        if(st.find(head2) == st.end()){
            // not found
            st.insert(head2);
            head2=head2->next;
        }
        else{
            // found
            mergeFound = true;
            mergePoint = head2->data;
        }
    }


    if(mergeFound){
        // clear set
        for(set<Node*>::iterator it=st.begin(); it!=st.end(); ++it){
            delete *it;
        }
    }

    return mergePoint;

}

#endif // INSERTION_POINT_IN_Y_SHAPED_LINKED_LIST_H_INCLUDED
