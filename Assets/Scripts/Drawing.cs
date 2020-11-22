using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    public GameObject Selected;
    public GameObject parent;
    public AudioSource ClickSound;
    private bool CanDraw = true;
    //public Texture2D Paper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0)&&CanDraw)
        {
            Vector2 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 wordPos;
            wordPos = Camera.main.ScreenToWorldPoint(mousePos);
            var pixel = Instantiate(Selected, wordPos, Quaternion.identity);
            pixel.transform.SetParent(parent.transform);
            StartCoroutine(DeleteObject(3f, pixel));

        }
    }

    public void ChangePenColor(GameObject selected)
    {
        Selected = selected;
        ClickSound.Play();
    }

    public void swapCanDraw()
    {
        CanDraw = !CanDraw;
    }

    IEnumerator DeleteObject(float f, GameObject obj)
    {
        yield return new WaitForSeconds(f);
        Destroy(obj);
    }
}
