using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveL : MonoBehaviour
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
            row[i].gameObject.transform.position += new Vector3(-1, 0, 0);
            if (row[i].gameObject.transform.position.x > rowLength) row[i].gameObject.transform.position = new Vector3(982, 0, 0);
        }
    }
}
