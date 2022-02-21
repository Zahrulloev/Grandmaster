using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class Reader : MonoBehaviour
{
    // Для хранения XML документа с задачами. 
    private XmlDocument _pgnDocument = new XmlDocument();

    private void Start()
    {
        //ReadXml();  
    }

    // Создает столько игровых обектов с PGNobject скриптом сколько задач в файле XML
    public void ReadXml()
    {
        //Адресс где находяться наши задачи.
        string path = "XML/Task.xml";
        string FullPath = Application.dataPath + "//" + path;
        
        // Загружаем XML документ
        _pgnDocument.Load(FullPath);

        // Берем корневой элемент. 
        XmlElement root = _pgnDocument.DocumentElement;

        if (root.HasChildNodes)
        {
            XmlNodeList Tasks = root.ChildNodes;

            foreach (XmlElement Task in Tasks)
            {
                GameObject pgnObject= new GameObject();
                pgnObject.AddComponent<PGNobject>();
                pgnObject.gameObject.tag = "PGN";
                pgnObject.GetComponent<PGNobject>().PgnToAnnotationAndMoves(Task.InnerText);
            }
        }
    }
}
