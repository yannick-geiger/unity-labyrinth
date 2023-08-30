using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveR1 : MonoBehaviour
{
    [Header("Layer Masks")]
    [SerializeField] private LayerMask whatIsTable;
    [SerializeField] private float raycastLength;
    private RaycastHit2D layerHit;
    [Header("General References")]
    [SerializeField] private Button moveRow;
    [SerializeField] private int numberOfRowItems;
    [SerializeField] private float spriteLenght, rowLength, rowStart, rowDetectionDelay;
    [SerializeField] private SpriteRenderer[] row;
    private int j;
    private float resetDelay;

    [Header("Debug")]
    [SerializeField] private bool showRaycast;
    [SerializeField] private bool outputRaycastOrigin;

    private void Start()
    {
        Button btn = moveRow.GetComponent<Button>();
        btn.onClick.AddListener(MoveRight);
        resetDelay = rowDetectionDelay; //store the delay value so that it can be rested witout having to change it manually
        row = new SpriteRenderer[0];
    }

    private void Update()
    {
        /*DEBUG RAY*/
        if (showRaycast)
        {
            if (row.Length == 0) UnityEngine.Debug.DrawRay(moveRow.transform.position, moveRow.gameObject.transform.right * raycastLength, Color.green);
            else UnityEngine.Debug.DrawRay(row[j - 1].gameObject.transform.position, row[j - 1].gameObject.transform.right * raycastLength, Color.green);
        }
        if (outputRaycastOrigin)
        {
            if (row.Length == 0) UnityEngine.Debug.Log("Raycast Origin: " + moveRow.transform.position);
            else UnityEngine.Debug.Log("Raycast Origin: " + row[j - 1].transform.position);
        }
        /*DEBUG RAY*/
        /*GET FIRST ROW ELEMENT*/
        if (rowDetectionDelay > 0) rowDetectionDelay -= Time.deltaTime; //The first detection needs to be delayed by a small amout otherwise it can bug out when moving the row
        if (row.Length == 0 && rowDetectionDelay <= 0)
        {
            j = 0;
            /*Shoot a raycast that check for the 'whatIsTable' layer, if it hits it adds the element to the array*/
            if (Physics2D.Raycast(moveRow.gameObject.transform.position, transform.TransformDirection(Vector3.right), (int)raycastLength, whatIsTable))
            {
                row = new SpriteRenderer[numberOfRowItems];
                layerHit = Physics2D.Raycast(moveRow.gameObject.transform.position, transform.TransformDirection(Vector3.right));
                row[j] = layerHit.transform.gameObject.GetComponent<SpriteRenderer>(); //add the element to the array
                /*Because you're shooting the element from a object that's on the 'whatIsTable' layer it will detect itself
                so you need to disable it's collider util it finds the next element*/
                row[j].transform.gameObject.GetComponent<Collider2D>().enabled = false; //disables current collider
                j++;
            }
        }
        /*GET FIRST ROW ELEMENT*/
        /*GET OTHER ROW ELEMENTS*/
        if (j < row.Length && row.Length != 0)
        {
            //same as before but shoot the raycast from an object in the array and not from an outside "start point"
            if (Physics2D.Raycast(row[j - 1].gameObject.transform.position, transform.TransformDirection(Vector3.right), (int)raycastLength, whatIsTable))
            {
                layerHit = Physics2D.Raycast(row[j - 1].gameObject.transform.position, transform.TransformDirection(Vector3.right));
                if (layerHit.transform.gameObject.name != row[j - 1].transform.gameObject.name)
                {
                    /*Once you've found the next element you can re-enable the previous element's collider and disable the current*/
                    row[j - 1].transform.gameObject.GetComponent<Collider2D>().enabled = true; //re-enables previous collider
                    row[j] = layerHit.transform.gameObject.GetComponent<SpriteRenderer>();
                    row[j].transform.gameObject.GetComponent<Collider2D>().enabled = false; //disables current collider
                    j++;
                }
            }
        }
        if (j == row.Length && row.Length != 0)
        {
            /*Since there are no more elements the last element's collider would stay disabled, this re-enables it*/
            row[j - 1].transform.gameObject.GetComponent<Collider2D>().enabled = true; //re-enables last collider
        }
        /*GET OTHER ROW ELEMENTS*/

    }

    private void MoveRight()
    {
        /*CHECK IF THE ARRAY IS FULL BEFORE MOVING THE SLOTS*/
        /*On slower computers it may take a few moments to fill the array, 
        this prevents the player from moving the row when not all elements have been detected*/
        bool isFull = false;
        int counter = 0;
        for (int k = 0; k < numberOfRowItems; k++)
        {
            if (row[k] != null) counter++;
        }
        if (counter == numberOfRowItems) isFull = true;
        /*CHECK IF THE ARRAY IS FULL BEFORE MOVING THE SLOTS*/
        /*IF ARRAY IS FULL MOVE THE ROW*/
        if (isFull)
        {
            int i;
            for (i = 0; i < row.Length; i++)
            {
                row[i].gameObject.transform.position += new Vector3(spriteLenght, 0, 0);
                if (row[i].gameObject.transform.position.x > rowLength) row[i].gameObject.transform.position = new Vector3(rowStart, 0, 0);
            }

            if (i == row.Length)
            {
                rowDetectionDelay = resetDelay;
                row = new SpriteRenderer[0]; //resets the row after moving it (this should also be done after moving a column)
                //UnityEngine.Debug.Log("Reseting Row: " + row.Length);
            }
        }
        /*IF ARRAY IS FULL MOVE THE ROW*/
    }
}


