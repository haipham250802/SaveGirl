using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static GameplayController Ins;
    public PosHandler PosHandler;
    private void Awake()
    {
        if (Ins == null)
            Ins = this;
        else
            DestroyImmediate(gameObject);
    }
    private void Start()
    {
        GameManager.Ins.LoadLevelController.LoadLevelById(GameManager.Ins.DataManager.CurrentLevel);
    }
}
