using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoSingleton<Controller> {

    public List<GameObject> m_listAnimalTracked = new List<GameObject>();

    void Start()
    {

    }

    public void DoZoomIn()
    {
        if(m_listAnimalTracked.Count<=0)
        {
            return;
        }
        for(int i=0;i<m_listAnimalTracked.Count;i++)
        {
            m_listAnimalTracked[i].GetComponent<AnimalManager>().DoZoomIn();
        }
    }

    public void DoZoomOut()
    {
        if (m_listAnimalTracked.Count <= 0)
        {
            return;
        }
        for (int i = 0; i < m_listAnimalTracked.Count; i++)
        {
            m_listAnimalTracked[i].GetComponent<AnimalManager>().DoZoomOut();
        }
    }
}
