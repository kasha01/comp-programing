using System;

// https://leetcode.com/problems/maximize-the-confusion-of-an-exam/
namespace _csharp
{
	public class _2024_maximize_the_confusion_of_an_exam
	{
		public int MaxConsecutiveAnswers(string answerKey, int k) {
			int i=0; int j=0; int n = answerKey.Length; int kk = k; int mx = 0;

			// check for all true
			while(j<n){
				char c = answerKey[j];
				if(c != 'T'){
					--kk;
				}

				// need to shrink right window
				while(i<j && kk<0){
					if(answerKey[i] == 'F'){
						++kk;
					}
					++i;
				}

				mx = Math.Max(mx,j-i+1);
				++j;
			}

			// check for all false
			i=0; j=0; kk=k;
			while(j<n){
				char c = answerKey[j];
				if(c != 'F'){
					--kk;
				}

				// need to shrink right window
				while(i<j && kk<0){
					if(answerKey[i] == 'T'){
						++kk;
					}
					++i;
				}

				mx = Math.Max(mx,j-i+1);
				++j;
			}

			return mx;
		}
	}
}