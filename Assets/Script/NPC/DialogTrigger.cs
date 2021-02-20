using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public ObjectDialog dialogue;
    public void TriggerDialogue(){
        FindObjectOfType<DialogManager>().StartDialog(dialogue);
    }
}
