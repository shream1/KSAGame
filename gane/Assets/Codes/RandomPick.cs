using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomPick : MonoBehaviour
{

    public Transform[] nodes;

   public List<string> list = new List<string> {"Kabsa" ,"Drink","Saled"} ;
    public Image images;

   public int pickedNumber;
    private Dictionary<Transform, GameObject> spawnedObjects = new Dictionary<Transform, GameObject>();

    public Material[] mat;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       // print(list[pickedNumber].Length);

        //makeStuff();
        if (Input.GetKeyDown(KeyCode.K))
        {
            makeFoodOrder();
        }
    }

   

    public GameObject cubes;

    void makeFoodOrder()
    {
        Transform picker = nodes[Random.Range(0, nodes.Length)];
        pickedNumber = Random.Range(0, list.Count);

        print(list[pickedNumber]);

        images = cubes.GetComponentInChildren<Image>();
        images.material = mat[pickedNumber];



        if (!spawnedObjects.ContainsKey(picker))
        {
            GameObject newObject = Instantiate(cubes, picker.position, Quaternion.identity);
            spawnedObjects[picker] = newObject;
        }
        else
        {
            Debug.Log("You can't do that, choose a different node.");
        }




    }



    
}
