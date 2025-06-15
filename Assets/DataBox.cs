using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/DataBox", fileName = "DataBox")]
public class DataBox : ScriptableObject
{
    public List<BoxColorInfo> ListBoxColorInfos = new();
    public List<BoxSizeInfo> ListBoxSizeInfo = new();
    public List<BoxDirInfo> ListDirBoxInfo = new();

    public BoxDirInfo GetDirBoxInfoOfType(TypeDirBox typeBox)
    {
        foreach (var item in ListDirBoxInfo)
        {
            if (item.TypeDir == typeBox)
                return item;
        }
        return null;
    }
    public BoxColorInfo GetBoxColorInfoOfType(TypeBox typeBox)
    {
        foreach (var item in ListBoxColorInfos)
        {
            if (item.Type == typeBox)
                return item;
        }
        return null;
    }
    public BoxSizeInfo GetBoxSizeInfoOfType(TypeSizeBox typeBox)
    {
        foreach (var item in ListBoxSizeInfo)
        {
            if (item.TypeSizeBox == typeBox)
                return item;
        }
        return null;
    }
}
[System.Serializable]
public class BoxColorInfo
{
    public TypeBox Type;
    public Color Color;
}
[System.Serializable]
public class BoxSizeInfo
{
    public TypeSizeBox TypeSizeBox;
    public Sprite Box;
}
[System.Serializable]
public class BoxDirInfo
{
    public TypeDirBox TypeDir;
    public Sprite Arrow;
}

public enum TypeBox
{
    Red,
    Green,
    Blue,
    Black,
    Orange
}
public enum TypeDirBox
{
   Top,
   Bottom,
   Right,
   Left
}
public enum TypeSizeBox
{
    Small,
    Medium,
    Big,
}
