using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private string dialog;

    public void DisplayDialogue()
    {
        StartCoroutine(TypeSentence(dialog));
    }

    IEnumerator TypeSentence(string dialogue)
    {
        dialogText.text = "";
        foreach (char letter in dialogue)
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }


}
