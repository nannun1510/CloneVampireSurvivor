using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int coinAcquired = 0;
    [SerializeField] TMPro.TextMeshProUGUI coinsCountText;

    private void Start()
    {
        coinsCountText.text = "Coins:" + coinAcquired.ToString();
    }
    public void Add(int count)
    {
        coinAcquired += count;
        coinsCountText.text = "Coins:" + coinAcquired.ToString();
    }
}
