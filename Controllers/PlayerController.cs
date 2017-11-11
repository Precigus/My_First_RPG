using UnityEngine.EventSystems;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public Interactable focus;

    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;


	// Use this for initialization
	void Start () {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);       //Move to where we hit

                RemoveFocus();          //Stop focusing an object

            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();      // Check if we hit an interactable object
                if (interactable != null)       //If we hit an interactable, set it as the focus object
                {
                    SetFocus(interactable);
                    motor.MoveToPoint(hit.point);
                }
            }
        }
    }
    void SetFocus (Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocus();
            }
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
                
        newFocus.OnFocus(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocus();
        }
        focus = null;
        motor.StopFollowingTarget();
    }
}
