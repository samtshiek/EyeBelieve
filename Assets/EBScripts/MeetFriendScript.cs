using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeetFriendScript : MonoBehaviour
{
    StoryScript storyScript;
    GameObject friend;
    NavMeshAgent friendAgent;
    Animator friendAnimator;
    GameObject bedObject;
    FriendScript friendScript;
    

    // Start is called before the first frame update
    void Start()
    {
        friend = GameObject.Find("Friend");
        friendScript = friend.GetComponent<FriendScript>();
        friendAgent = friend.GetComponent<NavMeshAgent>();
        friendAnimator = friend.GetComponent<Animator>();
        bedObject = GameObject.Find("PFB_Bed");
        storyScript = bedObject.GetComponent<StoryScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        storyScript.text2.text = "Moving? " + friendAnimator.GetBool("moving") + " D: " + friendAgent.remainingDistance;

        DayOneMeetingFriend();

    }

    private void DayOneMeetingFriend()
    {
        if (storyScript.dayIncrement == 1)
        {
            if (friendAnimator.GetBool("moving") && friendAgent.remainingDistance < 0.2)
            {
                friendScript.shouldRotate = true;
            }

            if (friendScript.shouldRotate)
            {
                storyScript.text2.text = "Time to rotate!! " + friend.transform.rotation.eulerAngles.y;
                friend.transform.rotation = Quaternion.RotateTowards(friend.transform.rotation, Quaternion.Euler(new Vector3(0, 90, 0)), 70f * Time.deltaTime);

                if (friend.transform.rotation.eulerAngles.y >= 87.0 || friend.transform.rotation.eulerAngles.y <= 92.0)
                {
                    friendScript.shouldRotate = false;
                    friendScript.shouldSit = true;
                }
            }

            if (friendScript.shouldSit)
            {
                friendAnimator.SetBool("sitting", true);
                friendScript.shouldSit = false;
            }

            if (friendScript.shouldPlayControllersSitting)
            {
                friendAnimator.SetBool("usecontrollersSitting", true);
                friendScript.shouldPlayControllersSitting = false;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        storyScript.text2.text = "Meeting freiend overlap";
        if (other.gameObject.name == "OVRCameraRig")
        {
            Vector3 sofaSit = new Vector3(500.827f, 1.908356f, 493.224f);
            friendAgent.SetDestination(sofaSit);
            friendAnimator.SetBool("moving", true);
            storyScript.text2.text = "Meeting Friend Trigger";
        }
    }
}
