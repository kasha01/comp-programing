#ifndef _1801_NUMBER_OF_ORDERS_IN_THE_BACKLOG_H_INCLUDED
#define _1801_NUMBER_OF_ORDERS_IN_THE_BACKLOG_H_INCLUDED

// https://leetcode.com/problems/number-of-orders-in-the-backlog/

class SellComparer{
	public:
		bool operator()(const pair<int,int>& p1, const pair<int,int>& p2){
			return get<0>(p1) > get<0>(p2);
		}
};

class BuyComparer{
	public:
		bool operator()(const pair<int,int>& p1, const pair<int,int>& p2){
			return get<0>(p1) < get<0>(p2);
		}
};

public:
    int getNumberOfBacklogOrders(vector<vector<int>>& orders) {
        priority_queue<pair<int,int>, vector<pair<int,int>>, SellComparer> pq_sell;
        priority_queue<pair<int,int>, vector<pair<int,int>>, BuyComparer> pq_buy;

        int n = orders.size();

        for(int i=0;i<n;++i){
            int price = orders[i][0];
            int remainingAmount = orders[i][1];
            int type = orders[i][2];
            int sell_price = 0;
            int buy_price = 0;

            if(type==0){
                // buy
                while(!pq_sell.empty() && remainingAmount > 0){
                    auto p = pq_sell.top();
                    sell_price = get<0>(p);
                    int sell_amount = get<1>(p);
                    pq_sell.pop();

                    if(sell_price > price){
                        // insert the poped item back as we cannot use it.
                        pq_sell.push(make_pair(sell_price,sell_amount));
                        break;
                    }

                    remainingAmount = remainingAmount - sell_amount;
                }

                if(remainingAmount > 0){
                    // there are more stuff in the order
                    pq_buy.push(make_pair(price,remainingAmount));
                }
                else if(remainingAmount < 0){
                    // all order items were used. but there are sell_amount that is remianing
                    pq_sell.push(make_pair(sell_price,remainingAmount*-1));
                }
            }
            else{
                // sell
                while(!pq_buy.empty() && remainingAmount > 0){
                    auto p = pq_buy.top();
                    buy_price = get<0>(p);
                    int buy_amount = get<1>(p);
                    pq_buy.pop();

                    if(buy_price < price){
                        pq_buy.push(make_pair(buy_price,buy_amount));
                        break;
                    }

                    remainingAmount = remainingAmount - buy_amount;
                }

                if(remainingAmount > 0){
                    // there are more stuff in the order
                    pq_sell.push(make_pair(price,remainingAmount));
                }
                else if(remainingAmount < 0){
                    // all order items were used. but there are sell_amount that is remianing
                    pq_buy.push(make_pair(buy_price,remainingAmount*-1));
                }
            }
        }

        long total = 0;
        while(!pq_sell.empty()){
            auto pr = pq_sell.top();
            total = total + get<1>(pr);
            pq_sell.pop();
        }

        while(!pq_buy.empty()){
            auto pr = pq_buy.top();
            total = total + get<1>(pr);
            pq_buy.pop();
        }

        return (total)%1000000007;
    };

#endif // _1801_NUMBER_OF_ORDERS_IN_THE_BACKLOG_H_INCLUDED
