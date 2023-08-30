using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveU : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] row;
    [SerializeField] private Button moveRow;
    [SerializeField] private float spriteLenght, rowLength, rowStart;

    private void Start()
    {
        Button btn = moveRow.GetComponent<Button>();
        btn.onClick.AddListener(MoveRight);
    }

    private void MoveRight()
    {
        for (int i = 0; i < row.Length; i++)
        {
            row[i].gameObject.transform.position += new Vector3(0, 1, 0);
            if (row[i].gameObject.transform.position.y > rowLength) row[i].gameObject.transform.position = new Vector3(579, 0, 0);
        }
    }
}
