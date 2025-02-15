using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPick : MonoBehaviour
{

    public Transform[] nodes;

    List<string> list = new List<string> {"Kabsa" ,"Drink","Saled"} ;

   public int pickedNumber;
    private Dictionary<Transform, GameObject> spawnedObjects = new Dictionary<Transform, GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        pickedNumber = Random.Range(0, list.Count);
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
    GameObject cube;
    public GameObject cubes;
    void makeFoodOrder()
    {
        Transform picker = nodes[Random.Range(0, nodes.Length)];


        if (!spawnedObjects.ContainsKey(picker))
        {
            GameObject newObject = Instantiate(cube, picker.position, Quaternion.identity);
            spawnedObjects[picker] = newObject;
        }
        else
        {
            Debug.Log("You can't do that, choose a different node.");
        }




    }



    GameObject proj;
    void makeStuff()
    {
        
        Vector3 tag = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) 
        {

             proj = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));

            proj.transform.position = tag;
            proj.transform.rotation = Quaternion.identity;

            proj.AddComponent<Rigidbody>();

            

        
        }
        Destroy(proj, 3);

    }
}
