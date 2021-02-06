using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlacePerson : MonoBehaviour
{
    public List<Sprite> faces;
    public List<GameObject> personControllers;
    public ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> arRaycastHits = new List<ARRaycastHit>();
    private List<PersonController> people = new List<PersonController>();
    public int maxPeople = 25;
    int currentPerson = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                if (Input.touchCount == 1)
                {
                    if (arRaycastManager.Raycast(touch.position, arRaycastHits)) {
                        var pose = arRaycastHits[0].pose;
                        PlacePersonAtPoint(pose.position);
                    }
                }
            }
        }
    }

    void PlacePersonAtPoint(Vector3 pos)
    {

        if (people.Count <= currentPerson)
        {
            int pp = Random.Range(0, personControllers.Count);
            GameObject g = Instantiate(personControllers[pp], pos, Quaternion.identity);
            PersonController person = g.GetComponent<PersonController>();
            people.Add(person);
        }
        else
        {
            people[currentPerson].gameObject.transform.position = pos;
        }

        int p = Random.Range(0, faces.Count);
        people[currentPerson].SetFace(faces[currentPerson%2]);

        currentPerson++;
        if(currentPerson > maxPeople)
        {
            currentPerson = 0;
        }
    }
}
