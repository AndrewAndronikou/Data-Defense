using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static int BuildAmount;
    public static int BuildCapacity;
    public int startBuildCapacity = 25;

    public static int Rounds;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        BuildAmount = 0;
        BuildCapacity = startBuildCapacity;

        Rounds = 0;
    }
}
