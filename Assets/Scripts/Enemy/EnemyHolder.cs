using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHolder : MonoBehaviour
{
    public List<GameObject> objectsList;
    private int currentIndex = 0;

    void Start()
    {
        if (objectsList.Count > 0)
        {
            objectsList[currentIndex].SetActive(true);
        }
    }

    void Update()
    {
        // ���������, ���� ������� ������ �� �������, ���������� ��������� ������ �� ������
        if (objectsList[currentIndex] == null || !objectsList[currentIndex].activeSelf)
        {
            currentIndex = (currentIndex + 1) % objectsList.Count;

            for (int i = 0; i < objectsList.Count; i++)
            {
                if (objectsList[i] != null)
                {
                    if (i == currentIndex)
                    {
                        objectsList[i].SetActive(true);
                    }
                    else
                    {
                        objectsList[i].SetActive(false);
                    }
                }
            }
        }
    }
}
