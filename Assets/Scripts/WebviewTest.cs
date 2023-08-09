
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebviewTest : MonoBehaviour
{
	public string url = "https://catalyst-web-client.vercel.app/contest/";
    public bool showToolbar = true;
    private UniWebView webview;

    void Start()
    {
        InitializeWebview();
        webview.Load(url);
    }

    private void InitializeWebview()
    {
        if (webview == null)
        {
            Debug.Log("Initializing Webview");
            var webviewGO = new GameObject("webviewGO");
            webview = webviewGO.AddComponent<UniWebView>();
            webview.Frame = new Rect(0, 0, Screen.width, Screen.height);
            webview.ReferenceRectTransform = transform as RectTransform;
            
            if (showToolbar)
                webview.EmbeddedToolbar.Show();

            webview.OnPageFinished += (view, statusCode, url) => { Debug.Log("Page Load Finished: " + url); };
        }
    }

    public void OpenWebview()
    {
        Debug.Log("OpenWebview");
        webview.Show();

        if (webview == null)
        {
            InitializeWebview();

						byte[] bytesToEncode = Encoding.UTF8.GetBytes ("{data:\"name\",unique_identifier:\"aad\"}");
						string encodedText = Convert.ToBase64String (bytesToEncode);

						webview.Load($"{url}/{encodedText}");
					}
    }

    void CloseWebView()
    {
        Destroy(webview);
        webview = null;
    }

    void OnDestroy()
    {
        CloseWebView();
    }

    void Update()
    {
        if (webview == null)
        {
            InitializeWebview();
            
						byte[] bytesToEncode = Encoding.UTF8.GetBytes ("{data:\"name\",unique_identifier:\"aad\"}");
						string encodedText = Convert.ToBase64String (bytesToEncode);

						webview.Load($"{url}/{encodedText}");
        }
    }
}
