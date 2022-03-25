using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this helper class send an interaction call to the parent and main class "InteractTextGroup".
//used when the GameObject is a child of a parent with InteractText component attached.
//This is used so that all children with InteractTextGroupChild call the same parent InteractTextGroup.
//InteractTextGroup then calls interactor with only one same text for all of them children.
/*Hierarchy Example:
    MyHouse (no collider, InteractTextGroup)
      -Wall1 (collider, InteractTextGroupChild, tag:Interactable)
      -Wall2 (collider, InteractTextGroupChild, tag:Interactable)
      -Wall3 (collider, InteractTextGroupChild, tag:Interactable)
      -Wall4 (collider, InteractTextGroupChild, tag:Interactable)
      -Fence (collider, InteractTextGroupChild, tag:Interactable)

    All inside objects call OnInteract method on MyHouse...
    ...Then MyHouse sends a single text to Interactor "This is my house".
    otherwise every wall should have the text "This is my house".
*/

public class InteractTextGroupChild : MonoBehaviour, IInteractable
{
    private InteractTextGroup group; //parent object
    public string hintText;

    // Start is called before the first frame update
    void Start()
    {
        //search for component in any parent GameObject, stop when you find one or return null
        group = GetComponentInParent<InteractTextGroup>();
    }

    public void OnInteract(Interactor interactor){
        //call interactor's public method ReceiveInteract
        //...with override method that gets a string as a parameter
        if (group!=null) group.OnInteract(interactor);
    }

     public string GetTxt(){
        if(hintText!=null){
            return hintText;
        }
        return "error";
    }
}
