using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] _points;
    public Transform[] Points { get { return _points; } }
    [SerializeField]
    private GameObject[] _gears;
    public GameObject[] Gears { get { return _gears; } }
}
