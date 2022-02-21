using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    // Cоздаем делегат с нужной нам сигнатурой.
    public delegate void Read();

    // На основе делегата создаем событие. 
    public event Read StartRead;

    [SerializeField]
    private Reader _reader;

    private void Awake()
    {
        // Подписываем к событию нужные нам метод.
        StartRead += _reader.ReadXml;
    }

    public void StartGame()
    {
        StartRead();
    }

}
