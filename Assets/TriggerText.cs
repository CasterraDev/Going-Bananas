using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TriggerText : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullTxt;

    public TextMeshProUGUI txt;
    private int maxVisibleCount;
    private int count = 0;
    // Start is called before the first frame update
    void Awake()
    {
        maxVisibleCount = txt.textInfo.characterCount;
        count = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        StartCoroutine(ShowText());

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        count = 0;
        txt.maxVisibleCharacters = 0;
    }

    IEnumerator ShowText()
    {
        while (true)
        {
            int visibleTxt = count % (maxVisibleCount + 1);
            txt.maxVisibleCharacters = visibleTxt;

            if (visibleTxt >= maxVisibleCount)
            {
                yield return new WaitForSeconds(1f);
            }
            count += 1;
            yield return new WaitForSeconds(.5f);
        }
    }
}
