using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public DataBox DataBox;
    public int CurrentLevel
    {
        get { return PlayerPrefs.GetInt("CurrentLevel", 1); }
        set
        {
            PlayerPrefs.SetInt("CurrentLevel", value);
        }
    }
}
