using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private Vector2 lastTapPos;
    private Vector3 startRotation;



    private float tileDistance;
    public Transform topTransform;
    public Transform goalTransform;
    public GameObject tilePrefbs;
    public List<Stage> allStages = new List<Stage>();
    private List<GameObject> spawnedLevels = new List<GameObject>();





    // Start is called before the first frame update
    void Awake()
    {
        startRotation = transform.localEulerAngles; 
        tileDistance = (topTransform.localPosition.y) - (goalTransform.localPosition.y + 0.1f);
        LoadStage(0);  
    }

    // Update is called once per frame
    void Update () {
        // Spin helix by using click (or finger press) and drag
        if (Input.GetMouseButton(0))
        {

            Vector2 curTapPos = Input.mousePosition;

            if (lastTapPos == Vector2.zero)
                lastTapPos = curTapPos;

            float delta = lastTapPos.x - curTapPos.x;
            lastTapPos = curTapPos;
            transform.Rotate(Vector3.up * delta);
        }

        if (Input.GetMouseButtonUp(0))
        {
            lastTapPos = Vector2.zero;
        }
    }
    

    public void LoadStage(int stageNumber){
        Stage stage = allStages[Mathf.Clamp(stageNumber, 0, allStages.Count -1)];

        Camera.main.backgroundColor = allStages[stageNumber].stageBackgroundColor;  //Game background color 
        FindObjectOfType<PlayerContoller>().GetComponent<Renderer>().material.color = allStages[stageNumber].stageBallColor;
        transform.localEulerAngles = startRotation;
        foreach(GameObject go in spawnedLevels)
            Destroy(go);
        //create the new levels
        float levelDistance = tileDistance/stage.levels.Count;
        float spawnPosY = topTransform.localPosition.y;

        for (int i=0;i<stage.levels.Count; i++){
            spawnPosY -= levelDistance;
            GameObject level = Instantiate(tilePrefbs,transform);
            level.transform.localPosition = new Vector3 (0,spawnPosY,0);
            spawnedLevels.Add(level);


            int partsToDisable = 12 - stage.levels[i].partCount;
            List<GameObject> disabledParts = new List<GameObject>();

            //Debug.Log("Should disable " + partsToDisable);

            while (disabledParts.Count < partsToDisable)
            {
                GameObject randomPart = level.transform.GetChild(Random.Range(0, level.transform.childCount)).gameObject;
                if (!disabledParts.Contains(randomPart))
                {
                    randomPart.SetActive(false);
                    disabledParts.Add(randomPart);
                   // Debug.Log("Disabled Part");
                }
            }


            // Mark parts as death parts
            List<GameObject> leftParts = new List<GameObject>();

            foreach (Transform t in level.transform)
            {
                t.GetComponent<Renderer>().material.color = allStages[stageNumber].stageLevelPartColor; // Set color of part

                if (t.gameObject.activeInHierarchy)
                    leftParts.Add(t.gameObject);
            }


            List <GameObject> deathParts = new List<GameObject>();
            //  Debug.Log("Should mark " + stage.levels[i].deathPathCount + " death parts");

            while (deathParts.Count < stage.levels[i].deathPathCount)
            {
                GameObject randomPart = leftParts[(Random.Range(0, leftParts.Count))];
                if (!deathParts.Contains(randomPart))
                {
                    randomPart.gameObject.AddComponent<DeathPath>();
                    deathParts.Add(randomPart);
                   // Debug.Log("Set death part");
                }
            }
            
        } 

    }


//         for (int i = 0; i < stage.levels.Count; i++)
//         {
//             spawnPosY -= levelDistance;
//             GameObject level = Instantiate(helixLevelPrefab, transform);
//             Debug.Log("Spawned Level");
//             level.transform.localPosition = new Vector3(0, spawnPosY, 0);
//             spawnedLevels.Add(level);

//             // Disable some parts (depending on level setup)
//             int partsToDisable = 12 - stage.levels[i].partCount;
//             List<GameObject> disabledParts = new List<GameObject>();

//             Debug.Log("Should disable " + partsToDisable);

//             while (disabledParts.Count < partsToDisable)
//             {
//                 GameObject randomPart = level.transform.GetChild(Random.Range(0, level.transform.childCount)).gameObject;
//                 if (!disabledParts.Contains(randomPart))
//                 {
//                     randomPart.SetActive(false);
//                     disabledParts.Add(randomPart);
//                     Debug.Log("Disabled Part");
//                 }
//             }


//     }
//     }
}
