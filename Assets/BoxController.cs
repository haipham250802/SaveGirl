using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BoxController : MonoBehaviour
{
    public TypeBox TypeBox;
    public TypeDirBox TypeDirBox;
    public TypeSizeBox TypeSizeBpx;
    public BoxElement BoxElement;
    public void Shake()
    {
        Debug.Log("shake");
        transform.DOShakePosition(1, .1f, 6, 11.3f, false, true, ShakeRandomnessMode.Harmonic);
    }
    public void InitBox(TypeBox typeBox, TypeDirBox typeDir, TypeSizeBox typeSize)
    {
        TypeDirBox = typeDir;
        TypeSizeBpx = typeSize;
        TypeBox = typeBox;
        switch (TypeSizeBpx)
        {
            case TypeSizeBox.Small:
                SpawnBox(GameManager.Ins.GameAssets.BoxSmall);
                break;
            case TypeSizeBox.Medium:
                SpawnBox(GameManager.Ins.GameAssets.BoxMedium);
                break;
            case TypeSizeBox.Big:
                SpawnBox(GameManager.Ins.GameAssets.BoxBig);
                break;
            default:
                break;
        }
        BoxElement.SetColorBox(GameManager.Ins.DataManager.DataBox.GetBoxColorInfoOfType(TypeBox).Color);
        BoxElement.Arrow.sprite = GameManager.Ins.DataManager.DataBox.GetDirBoxInfoOfType(typeDir).Arrow;
        BoxElement.BoxController = this;
    }
    public void InitBox()
    {
        if (BoxElement)
            DestroyImmediate(BoxElement.gameObject);
        switch (TypeSizeBpx)
        {
            case TypeSizeBox.Small:
                SpawnBox(GameManager.Ins.GameAssets.BoxSmall);
                break;
            case TypeSizeBox.Medium:
                SpawnBox(GameManager.Ins.GameAssets.BoxMedium);
                break;
            case TypeSizeBox.Big:
                SpawnBox(GameManager.Ins.GameAssets.BoxBig);
                break;
            default:
                break;

        }

        BoxElement.SetColorBox(GameManager.Ins.DataManager.DataBox.GetBoxColorInfoOfType(TypeBox).Color);
        BoxElement.Arrow.sprite = GameManager.Ins.DataManager.DataBox.GetDirBoxInfoOfType(TypeDirBox).Arrow;
    }
    public void SpawnBox(BoxElement box)
    {
        GameObject objClone = Instantiate(box.gameObject);
        objClone.transform.SetParent(transform);
        BoxElement = objClone.GetComponent<BoxElement>();
    }
}
