using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="New Item/item")]
public class Item : ScriptableObject
{ 
    public string itemName; // 아이템 이름
    public Sprite itemImage;    // 아이템 이미지(인벤토리 표시)
    public GameObject itemPrefab;   // 아이템 프리팹
}
