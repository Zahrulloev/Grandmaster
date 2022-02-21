using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    // C������ ������� � ������ ��� ����������.
    public delegate void Read();

    // �� ������ �������� ������� �������. 
    public event Read StartRead;

    [SerializeField]
    private Reader _reader;

    private void Awake()
    {
        // ����������� � ������� ������ ��� �����.
        StartRead += _reader.ReadXml;
    }

    public void StartGame()
    {
        StartRead();
    }

}
