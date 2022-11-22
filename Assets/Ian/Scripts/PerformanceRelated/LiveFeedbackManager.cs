using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this should be in the performance scene load, since it should be refreshed every performance and unique to each time player performances
public class LiveFeedbackManager : MonoBehaviour
{
    private List<feedbackPair<int, string>> feedbackPairs = new List<feedbackPair<int, string>>();
    
    public void LoadLiveFeedback(LiveFeedback fb)
    {
        foreach (feedbackPair<int, string> pair in fb.feedbackPairs)
        {
            feedbackPairs.Add(pair);
        }
    }

    public void CheckForFeedback(int id)
    {
        for (int i=feedbackPairs.Count - 1; i>= 0; i--)
        {
            feedbackPair<int, string> pair = feedbackPairs[i];
            if (id == pair.key)
            {
                // found it
                // DO SOMETHING WITH pair.val
                // temporary


                // remove the pair from feedbackPairs
                feedbackPairs.Remove(pair);
            }
        }
    }
}
