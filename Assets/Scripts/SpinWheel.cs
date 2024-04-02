using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;
[CreateAssetMenu(fileName = "SpinWheel", menuName = "SpinWheel/CreateSpinWheel")]
public class SpinWheel : ScriptableObject
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject WheelTile;
    [SerializeField] private WheelDataContainer wheelData;

    [SerializeField] private List<GameObject> wheeltilelist;
    public int numberOfTiles ;
    public float radius ;


    [Button]
    void MakeSpinWheel()
    {
        float angleStep = 360f / numberOfTiles;
        
        for (int i = 0; i < numberOfTiles; i++)
        {
            float angle = i * angleStep;

            Vector3 tilePosition = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad) * radius, Mathf.Cos(angle * Mathf.Deg2Rad) * radius, 0f);
            GameObject tile = Instantiate(WheelTile,parent);
            tile.transform.rotation = Quaternion.Euler(0f, 0f, -angle);
            wheeltilelist.Add(tile);
        }
    }

}
