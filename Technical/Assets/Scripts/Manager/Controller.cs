using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoSingleton<Controller> {

    public List<GameObject> m_listAnimalTracked = new List<GameObject>();

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

    public void AddAnimalTracked(GameObject _animal)
    {
        if (!m_listAnimalTracked.Contains(_animal))
        {
            m_listAnimalTracked.Add(_animal);
        }
        StateButton.Instance.EnableButton();
    }

    public void RemoveAnimalTracked(GameObject _animal)
    {
        if (m_listAnimalTracked.Contains(_animal))
        {
            m_listAnimalTracked.Remove(_animal);
        }

        if(m_listAnimalTracked.Count<=0)
        {
            StateButton.Instance.DisableButton();
        }
    }
}
