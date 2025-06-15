using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private BoxController _boxController;
    [SerializeField] private List<BoxLevelInfo> _listBoxes;
    [SerializeField] private List<BoxController> _listBoxController;
    [Button]
    private void ForceLevel()
    {
        _listBoxController.Clear();
        var arr = GetComponentsInChildren<BoxController>();
        foreach (var item in arr)
        {
            item.InitBox();
        }
        foreach (var item in _listBoxController)
        {
            _listBoxController.Add(item);
        }
    }
    [Button]
    private void Spawn()
    {
        if(_listBoxController.Count > 0)
        {
            foreach (var item in _listBoxController)
            {
                DestroyImmediate(item.gameObject);
            }
        }
        _listBoxController.Clear();
        foreach (var item in _listBoxes)
        {
            BoxController boxControllerClone = Instantiate(_boxController);
            boxControllerClone.transform.SetParent(transform);
            boxControllerClone.InitBox(item.TypeColor, item.TypeDir, item.TypeSize);
            _listBoxController.Add(boxControllerClone);
        }
    }
}
[System.Serializable]
public class BoxLevelInfo
{
    public TypeDirBox TypeDir;
    public TypeBox TypeColor;
    public TypeSizeBox TypeSize;
}
