using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyManager : MonoBehaviour
{
    [SerializeField] private int _startNum = 60;
    [SerializeField] private int _maxCol = 6;
    [SerializeField] private GameObject _sodierPrefab;

    private int _num;
    [SerializeField]
    private GameObject[] _clone;
    [SerializeField]
    private bool _flag = false;

    private float _sodierWidth = 0.75f;
    private float _sodierLength = 0.75f;
    private float _sodierHeight = 0.75f;


    // Start is called before the first frame update
    void Start()
    {
        _num = _startNum;
        StartLineUp(_startNum);
    }

    // Update is called once per frame
    void Update()
    {
        Rearrange();
    }

    private void StartLineUp(int num)
    {
        _clone = new GameObject[num];
        for (int i = 0; i < num; i++)
        {
            int rowIndex = i / _maxCol;
            int colIndex = i % _maxCol;
            Vector3 position = new Vector3(-0.75f + colIndex * _sodierWidth, _sodierHeight, -rowIndex * _sodierLength);
            _clone[i] = Instantiate(_sodierPrefab, position, Quaternion.identity);

        }
    }

    private void Rearrange()
    {
        // kiem tra xem co thang linh nao bi diet ko de sap xep
        for (int i = 0; i < _num; i++)
        {
            if (_clone[i] == null)
            {
                _flag = true;
                break;
            }
        }

        // neu co
        if (_flag == true)
        {
            int row = _num / 6;
            for (int i = 0; i < _num; i++)
            {
                if (_clone[i] == null)
                {
                    for (int j = 0; j < row; j++)
                    {
                        Destroy(_clone[i + j * _maxCol]);
                        _clone[i + j * _maxCol] = new GameObject();
                    }
                }

            }
        }
    }

}
