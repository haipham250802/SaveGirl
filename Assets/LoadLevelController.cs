using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelController : MonoBehaviour
{
    public void LoadLevelById(int Level)
    {
        string path = $"Level{Level}"; // Level = 1=> path Level1
        GameObject objClone = Resources.Load<GameObject>(path);
        Instantiate(objClone);
    }
}
