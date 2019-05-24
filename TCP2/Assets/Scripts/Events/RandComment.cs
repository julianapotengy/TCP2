using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandComment : MonoBehaviour
{
    [SerializeField] List<Sprite> commentsImg = new List<Sprite>();
    public bool canRand;
    [SerializeField] Image[] comments;
    float counter = 0;

    void Start ()
    {
        canRand = true;

        if (canRand)
        {
            foreach (Image c in comments)
            {
                int i = Random.Range(0, commentsImg.Count);
                
                c.sprite = commentsImg[i];
                commentsImg.RemoveAt(i);
                c.gameObject.SetActive(false);
            }
        }
    }
	
	void Update ()
    {
		if(canRand)
        {
            counter += Time.deltaTime;

            if (counter >= 3 && counter <= 6)
                comments[0].gameObject.SetActive(true);
            else if (counter >= 6 && counter <= 9)
                comments[1].gameObject.SetActive(true);
            else if (counter >= 9 && counter <= 12)
                comments[2].gameObject.SetActive(true);
            else if (counter >= 12 && counter <= 15)
                comments[3].gameObject.SetActive(true);
            else if (counter >= 15 && counter <= 18)
            {
                comments[4].gameObject.SetActive(true);
                canRand = false;
            }
        }
	}
}
