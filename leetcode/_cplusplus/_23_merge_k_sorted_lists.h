#ifndef _23_MERGE_K_SORTED_LISTS_H_INCLUDED
#define _23_MERGE_K_SORTED_LISTS_H_INCLUDED

// https://leetcode.com/problems/merge-k-sorted-lists/
// tags: merge lists

/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode() : val(0), next(nullptr) {}
 *     ListNode(int x) : val(x), next(nullptr) {}
 *     ListNode(int x, ListNode *next) : val(x), next(next) {}
 * };
 */
class Solution {
    class MyComparer{
        public:
        bool operator()(ListNode* a, ListNode* b){
            int va = a->val;
            int vb = b->val;

            return va>vb;
        }
    };

public:
    ListNode* mergeKLists(vector<ListNode*>& lists) {
        priority_queue<ListNode*,vector<ListNode*>,MyComparer> pq;

        int k = lists.size();
        for(int i=0;i<k;++i){
            if(lists[i])
                pq.push(lists[i]);
        }

        ListNode* head = nullptr;
        ListNode* current = nullptr;
        while(!pq.empty()){
            auto node = pq.top();
            pq.pop();

            if(!head){
                current = new ListNode(node->val);
                head = current;
            }
            else{
                current->next = new ListNode(node->val);
                current = current->next;
            }

            if(node->next){
                pq.push(node->next);
            }
        }

        return head;
    }
};

#endif // _23_MERGE_K_SORTED_LISTS_H_INCLUDED
