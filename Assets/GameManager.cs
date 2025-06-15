using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Ins;
    public DataManager DataManager;
    public GameAssets GameAssets;
    public LoadLevelController LoadLevelController;
    private void Awake()
    {
        if (Ins == null)
            Ins = this;
        else
            DestroyImmediate(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}
