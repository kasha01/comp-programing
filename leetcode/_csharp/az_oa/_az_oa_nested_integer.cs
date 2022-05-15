using System;
using System.Collections.Generic;

// https://leetcode.com/discuss/interview-question/1911645/NestedInteger-implementation-or-Amazon
namespace _csharp
{
	public class _az_oa_nested_integer
	{
		interface INestedInteger {
			// @return true if this NestedInteger holds a single integer, rather than a nested list.
			bool isInteger();

			// @return the single integer that this NestedInteger holds, if it holds a single integer
			// Return null if this NestedInteger holds a nested list
			int getInteger();

			// Set this NestedInteger to hold a single integer.
			void setInteger(int value);

			// Set this NestedInteger to hold a nested list and adds a nested integer to it.
			void add(NestedInteger ni);

			// @return the nested list that this NestedInteger holds, if it holds a nested list
			// Return empty list if this NestedInteger holds a single integer
			List<NestedInteger> getList();
		}

		class NestedInteger : INestedInteger{
			public int val { get; set;}
			public List<NestedInteger> list { get; set;}

			public NestedInteger(){
				this.list = new List<NestedInteger>();
			}

			public NestedInteger(int v){
				this.val = v; this.list = new List<NestedInteger>();
			}

			public bool isInteger(){
				return list.Count == 0;
			}

			public int getInteger(){
				return this.val;
			}

			public void setInteger(int v){
				this.val = v;
			}

			public void add(NestedInteger ni){
				list.Add(ni);
			}

			public List<NestedInteger> getList(){
				return list;
			}
		}

		int depthSum(List<NestedInteger> nestedList) {
			// Write your code here
			return rc(1,nestedList);
		}

		int rc(int level,List<NestedInteger> nestedList){
			int n = nestedList.Count;

			int sum = 0;
			for(int i=0;i<n;++i){
				var nestedInt = nestedList[i];
				if(nestedInt.isInteger()){
					sum = sum + (level * nestedInt.getInteger());
				}
				else{
					sum = sum + rc(level+1,nestedInt.getList());
				}
			}

			return sum;
		}

		public void init ()
		{
			// build NestedInteger [[1,1],2,[1,1]]
			var nested1 = new NestedInteger ();
			var nested1_1 = new NestedInteger (1);
			var nested1_2 = new NestedInteger (1);
			nested1.add (nested1_1);
			nested1.add (nested1_2);

			var nested2 = new NestedInteger (2);

			var nested3 = new NestedInteger ();
			var nested3_1 = new NestedInteger (1);
			var nested3_2 = new NestedInteger (1);
			nested3.add (nested3_1);
			nested3.add (nested3_2);

			var root = new NestedInteger();
			root.add (nested1);
			root.add (nested2);
			root.add (nested3);

			// get depth sum https://www.lintcode.com/problem/551
			int sum = depthSum (root.getList());
			Console.WriteLine (sum);
		}
	}
}

