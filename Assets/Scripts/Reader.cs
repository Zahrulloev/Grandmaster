using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class Reader : MonoBehaviour
{
    // ��� �������� XML ��������� � ��������. 
    private XmlDocument _pgnDocument = new XmlDocument();

    private void Start()
    {
        //ReadXml();  
    }

    // ������� ������� ������� ������� � PGNobject �������� ������� ����� � ����� XML
    public void ReadXml()
    {
        //������ ��� ���������� ���� ������.
        string path = "XML/Task.xml";
        string FullPath = Application.dataPath + "//" + path;
        
        // ��������� XML ��������
        _pgnDocument.Load(FullPath);

        // ����� �������� �������. 
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
