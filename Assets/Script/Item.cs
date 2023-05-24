using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="New Item/item")]
public class Item : ScriptableObject
{ 
    public string itemName; // ������ �̸�
    public Sprite itemImage;    // ������ �̹���(�κ��丮 ǥ��)
    public GameObject itemPrefab;   // ������ ������
}