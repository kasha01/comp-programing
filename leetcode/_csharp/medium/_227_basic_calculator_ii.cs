using System;
using System.Collections.Generic;

// https://leetcode.com/problems/basic-calculator-ii/
namespace _csharp
{
	public class _227_basic_calculator_ii
	{
		// HUGE THANKS TO: https://leetcode.com/problems/basic-calculator-ii/discuss/1646099/C%2B%2BPython-Simple-Solutions-w-Explanation-or-Postfix-%2B-Stack-%2B-Without-Stack
		public int Calculate_NoStack(string s) {
			int currentNum = 0; int prevNum=0; int prevOp='+'; int ans=0;
			s = s + "##";   // so we can compute after an operator is hit

			foreach(char c in s){
				if(c==' ') continue;

				if(c>='0' && c<='9'){
					currentNum = currentNum*10 + (c-'0');
				}
				else{
					// I hit an operator. compute (prevOp) operation
					if(prevOp == '*'){
						prevNum = prevNum * currentNum;
					}
					else if(prevOp == '/'){
						prevNum = prevNum / currentNum;
					}
					else{
						// here currentNum cannot be included in the operations as the operator before currentNum
						// (prevOp) is + or -. 
						ans = ans + prevNum;
						prevNum = prevOp == '+' ? currentNum : currentNum*(-1);	// set the sign of prevNum
					}

					currentNum=0;
					prevOp = c;
				}
			}

			return ans;
		}


		private int i=0;
		public int Calculate(string s) {
			Stack<char> operators = new Stack<char>();
			Stack<long> oprands = new Stack<long>();

			while(i<s.Length){
				char c = s[i];
				if(isOperator(c)){
					int priority = getPrecedence(c);
					while(operators.Count > 0 && priority <= getPrecedence(operators.Peek()) ){
						long b = oprands.Pop();
						long a = oprands.Pop();
						char op = operators.Pop();
						long result = calculate_op(a,b,op);
						oprands.Push(result);                
					}

					operators.Push(c);
					++i;
				}
				else if(isOprand(c)){
					oprands.Push(scanNumber(s));
				}
				else{
					++i; // skip spaces
				}
			}

			while(operators.Count > 0){
				long b = oprands.Pop();
				long a = oprands.Pop();
				char op = operators.Pop();
				long result = calculate_op(a,b,op);
				oprands.Push(result);
			}

			return (int)oprands.Pop();
		}

		private long scanNumber(string s){
			long ret = 0;
			while(i<s.Length && isOprand(s[i])){
				ret = (ret*10) + (s[i]-'0');
				++i;
			}
			return ret;
		}

		private bool isOperator(char c){
			return c=='+' || c=='*' || c=='-' || c=='/';
		}

		private bool isOprand(char c){
			return c >= '0' && c<= '9';
		}

		private long calculate_op(long a, long b, char op){
			if(op == '*') return a*b;
			if(op == '/') return a/b;
			if(op == '+') return a+b;
			if(op == '-') return a-b;

			return 0;
		}

		private int getPrecedence(char c){
			if(c=='+') return 1;
			if(c=='-') return 1;
			if(c=='*') return 2;
			if(c=='/') return 2;
			if(c=='(') return 10;

			return -1;
		}
	}
}

