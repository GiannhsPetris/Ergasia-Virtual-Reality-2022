using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

//version 1.1
public class Interactor : MonoBehaviour
{
    [Header("Output")] //--------------------------------------------------
    public GameObject currentInteractable; //interactable object that player is currently looking at
    GameObject lastInteractable; //saved last object for calculations between checks/frames
    
    [Header("Setup")] //--------------------------------------------------
    [SerializeField] private string targetTag = "Interactable"; //the tag name of the interactables
    [SerializeField] private float rayMaxDistance = 5; //interact max distance
    [SerializeField] private Transform cam;

    //layer mask determines which layers the layer have to search
    //for example layermash should be set to everything except maybe the player adn ingoreRaycast layer
    //Edit/Project Setting/Physics/Layer Collision Mask to see layer interaction
    [SerializeField] private LayerMask layerMask = ~0; //negative binary of 0 -> 2^32-1
    [SerializeField] private InteractorUI interactorUI;
    [SerializeField] private GameObject hint; //UI or 3D object hint (like "press E to interact")
    [SerializeField] private TextMeshProUGUI hintTextUI;
    [SerializeField] private string hintText;

    [Header("Buttons")] //--------------------------------------------------
    //[SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private KeyCode[] cancelInteractionKeys; //list of all cancel buttons

    //PlayerControls playerControls;

    //--------------------------------------------------
    //state booleans
    bool readyInteract;
    bool interacting;

    // Start is called before the first frame update
    void Start()
    {
        //reset variables
        currentInteractable = null;
        interacting = false;

        //console warning if variables doesn't have a reference
        //we may put if statements on methods but this will fill up the code without practical use
        //...other that we forgot to assign these. We rimind it on the Start method.
        if (interactorUI==null) Debug.LogWarning("Interactor: InteractorUI component was not set.");
        if (hint==null) Debug.LogWarning("Interactor: Hint GameObject was not set.");

        //call abort method that we know it resets variables instead of doing it here
        AbortInteract();
    }

    // Update is called once per frame
    void Update()
    {   
        currentInteractable = null;

        RaycastHit hit; //a ray with useful properties

        //Physics.Raycast(start position, direction, output, distance"lenght" of raycast)
        if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, rayMaxDistance, layerMask)) //raycast check
        {
            //output object's collider => then get object's transform and  others
            if (hit.collider.CompareTag(targetTag)){
                currentInteractable = hit.collider.gameObject;
               if(currentInteractable.GetComponent<IInteractable>() != null){hintText = currentInteractable.GetComponent<IInteractable>().GetTxt();}
            }
        }

        //if we are looking at an interactable object and we did NOT last frame/check
        if (currentInteractable != null && !readyInteract){
            ReadyInteract();
        }
        //if we are NOT looking at an interactable object and we did last frame/check
        else if (currentInteractable == null && readyInteract){
            AbortInteract();
        }

        //readyInteract && Input.GetKeyDown(interactKey)

        if(!interacting){ //if you aren't currently interacting
            if (readyInteract && Keyboard.current.eKey.wasPressedThisFrame){ //...but you are ready to interact AND pressing interact button
                Interact();
            }
        }
        else { //if interacting
            if (IsCancelButtonPressed()){ //is pressing any cancel button (movement buttons for example)
                EndInteract();
            }
            //if this frame the interactable object that we are looking changed
            //if current = null or if this frame/check the object is different from last frame/check
            //this is an extra cancelation check
            else if (currentInteractable == null || currentInteractable != lastInteractable){
                EndInteract();
            }
        }
        //if current interactable not null then match current and last
        //with lastInteractable we can check if current and last are different objects above this next line
        if (currentInteractable != null) lastInteractable = currentInteractable;
    }

    //ready interaction for player (maybe show a text on a canvas)
    void ReadyInteract(){
        readyInteract = true;

        hint.SetActive(true); //show interact hint
        hintTextUI.enabled = true;
        hintTextUI.text = hintText;
        
        //Debug.Log("Ready");
    }

    //cancel/abort interaction input for player (maybe hide a text on a canvas)
    void AbortInteract(){
        readyInteract = false;

        hint.SetActive(false); //hide interact hint
        hintTextUI.enabled = false;

        //Debug.Log("Abort");
    }

    void Interact(){
        interacting = true;
        readyInteract = true; //consistancy with EndInteract (not so useful)

        hint.SetActive(false); //hide interact hint
        hintTextUI.enabled = false;

        //search for IInteractable component, if found call OnInteract
        IInteractable interactable = currentInteractable.GetComponent<IInteractable>();
        if (interactable != null){
            interactable.OnInteract(this);
        }

        //Debug.Log("Interact");
    }

    void EndInteract(){
        interacting = false; 
        //setting readyInteract to false we allow for a clean check next frame/check
        //when an interacting is cancelled, a next suitable object could be ready to interact (already looking at it)
        //...but without setting readyInteract to false, it thinks we aren't allowed to search for anything new
        //(will not call ReadyInteract method properly) 
        readyInteract = false;

        //send message calls first method that finds on the interactable with name OnEndInteract
        //this is required cause IInteractable doesn't have OnEndInteract method
        //...and we SendMessage for any object that may have that method
        lastInteractable.SendMessage("OnEndInteract", SendMessageOptions.DontRequireReceiver);

        interactorUI.HideTextMessage(); //hide UI text element

        //Debug.Log("EndInteract");
    }

    //pubic override method that calls EndInteract if the GameObject that requested matches lastInteractable 
    public void EndInteract(GameObject requester){
        if (requester==lastInteractable)
            EndInteract();
    }

    //we call Oninteract method on our interactables and we expect to receive something
    //this can be a string or the object itself
    //a string can be returned from the text of a sign for example
    //example receive override methods
    public void ReceiveInteract(string message){
        //Debug.Log(message);
        //call interactorUI (a separete script that handles UI elements) and show text on UI
        interactorUI.ShowTextMessage(message);
    }

    public void ReceiveInteract(IInteractable interactable){
        //Debug.Log(interactable);
    }


    //returns true if any of the "cancel" keys is pressed, else return false
    bool IsCancelButtonPressed(){
        for (int i = 0; i < cancelInteractionKeys.Length; i++)
        {
            //if button was pressed down this frame
            if (Input.GetKeyDown(cancelInteractionKeys[i])){
                return true;
            }
        }
        return false;
    }
}
