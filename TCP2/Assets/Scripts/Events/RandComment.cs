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

            if (counter >= 2 && counter <= 4)
                comments[0].gameObject.SetActive(true);
            else if (counter >= 4 && counter <= 6)
                comments[1].gameObject.SetActive(true);
            else if (counter >= 6 && counter <= 8)
                comments[2].gameObject.SetActive(true);
            else if (counter >= 8 && counter <= 10)
                comments[3].gameObject.SetActive(true);
            else if (counter >= 10 && counter <= 12)
            {
                comments[4].gameObject.SetActive(true);
                canRand = false;
            }
        }
	}
}
