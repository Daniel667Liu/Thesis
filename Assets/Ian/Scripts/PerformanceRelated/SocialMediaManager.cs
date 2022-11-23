using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SocialMediaManager : MonoBehaviour
{
    public int follower;

    public GameObject followerUI;

    public void AddFollower(int newFollowers)
    {
        follower += newFollowers;
    }

    public void UpdateFollowerUI()
    {
        followerUI.GetComponent<TMP_Text>().text = follower.ToString();
    }

    public void DisplayFollowerUI()
    {
        followerUI.SetActive(true);
    }

    public void HideFollowerUI()
    {
        followerUI.SetActive(false);
    }
}
