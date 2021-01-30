using System;

// https://leetcode.com/problems/bag-of-tokens/
namespace _csharp
{
	public class _948_bag_of_tokens
	{
		public int BagOfTokensScore(int[] tokens, int P) {
			int n = tokens.Length;

			// sort to guarantee I can start with tokens that consumes the least power to earn
			// score of +1
			Array.Sort(tokens);

			int score = 0;
			int i=0; int j=n-1;
			while(i<=j){
				if(P >= tokens[i])
				{
					// if I have power. I should play token up to get a score
					P = P - tokens[i];
					score++;
					++i;
				}
				else if (score > 0 && i+1 < j){
					// if I don't have power, I should play token down to get more power.
					// given that there is at least one token a head of me, so I can compensate
					// my lost scores
					P = P + tokens[j];
					score--;
					--j;
				}
				else{
					// otherwise exit. there is nothing i can do.
					break;
				}
			}

			return score;
		}
	}
}

