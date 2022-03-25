using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class receives an interaction call from every child Gameobject with component "InteractTextGroupChild".
//Used with helper InteractTextGroupChild class component.
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

public class InteractTextGroup : MonoBehaviour
{
    [TextArea(3,10)]
    public string text;
    
    public void OnInteract(Interactor interactor){
        //call interactor's public method ReceiveInteract
        //...with override method that gets a string as a parameter
        interactor.ReceiveInteract(text);
    }
}
