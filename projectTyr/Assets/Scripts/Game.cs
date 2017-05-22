using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class Game : MonoBehaviour {

    public Text numberText;
    public Image backgroundImage;
    public GameObject backgroundPicker;
    public GameObject NumberCPicker;
    public GameObject NumberFPicker;
    public Font[] fonts;

    float number;

	// Use this for initialization
	void Start () {
        #if UNITY_EDITOR
                string adUnitId = "unused";
        #elif UNITY_ANDROID
                string adUnitId = "ca-app-pub-1527717066541177/8915564445";
        #elif UNITY_IPHONE
                string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
        #else
                string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        BannerView bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().AddTestDevice("03C0EA98BF27A650BE24FAEC8A113CFC").AddTestDevice("2A901C7E47C78759B3C6BD2560F59F0D").Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }
	
	// Update is called once per frame
	void Update () {
        number += Time.deltaTime;
        numberText.text = number.ToString("n1");
	}
    
    public void ChangeBackgroundColor(string colorC)
    {
        string rS = colorC.Substring(0, 3);
        float r = float.Parse(rS) / 255f;
        string gS = colorC.Substring(3, 3);
        float g = float.Parse(gS) / 255f;
        string bS = colorC.Substring(6, 3);
        float b = float.Parse(bS) / 255f;

        backgroundImage.color = new Color(r, g, b);
    }

    public void ChangeNumberColor(string colorC)
    {
        string rS = colorC.Substring(0, 3);
        float r = float.Parse(rS) / 255f;
        string gS = colorC.Substring(3, 3);
        float g = float.Parse(gS) / 255f;
        string bS = colorC.Substring(6, 3);
        float b = float.Parse(bS) / 255f;

        numberText.color = new Color(r, g, b);
    }

    public void ChangeNumberFont(int font)
    {
        numberText.font = fonts[font];
    }

    public void TogggleBackgroundPicker()
    {
        if(backgroundPicker.activeInHierarchy)
        {
            backgroundPicker.SetActive(false);
        } else
        {
            NumberCPicker.SetActive(false);
            NumberFPicker.SetActive(false);
            backgroundPicker.SetActive(true);
        }
    }

    public void TogggleNumberCPicker()
    {
        if (NumberCPicker.activeInHierarchy)
        {
            NumberCPicker.SetActive(false);
        }
        else
        {
            NumberFPicker.SetActive(false);
            backgroundPicker.SetActive(false);
            NumberCPicker.SetActive(true);
        }
    }

    public void TogggleNumberFPicker()
    {
        if (NumberFPicker.activeInHierarchy)
        {
            NumberFPicker.SetActive(false);
        }
        else
        {
            NumberCPicker.SetActive(false);
            backgroundPicker.SetActive(false);
            NumberFPicker.SetActive(true);
        }
    }

    void OnApplicationQuit()
    {
        Social.ReportScore((long)number, "CgkIjdu1vMYaEAIQAA", (bool success) => {
            // handle success or failure
        });
    }
}
