using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebviewTest : MonoBehaviour
{
	public string url = "https://www.conductive.ai";
	private UniWebView webview;

	public void OpenWebview()
	{
		Debug.Log("OpenWebview");
		webview = gameObject.AddComponent<UniWebView>();
		webview.Frame = new Rect(0, 0, Screen.width, Screen.height);
		webview.ReferenceRectTransform = transform as RectTransform;
		webview.OnPageFinished += (view, statusCode, url) => { webview.Show(); };
		webview.Load(url);
	}

	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
