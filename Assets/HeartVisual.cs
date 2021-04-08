using System.Collections;
using CodeMonkey.Utils;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class HeartVisual : MonoBehaviour
{
    [SerializeField] private Sprite[] heartSprites;
    public static HeartLogic HSystemStatic;
    private List<HeartImage> heartsImageList;
    private HeartLogic HSystem;
    private bool isHealing;
    private static int total;

    private void Awake()
    {
        heartsImageList = new List<HeartImage>();
    }
    private void Start()
    {
        FunctionPeriodic.Create(HealingAnimatedPeriodic, .05f);
        if (GameManager.instance)
        {
            total = GameManager.instance.saveData.playerData.vitality;
            HeartLogic HSystem = new HeartLogic(total/2);
            HSystem.Damage(total - GameManager.instance.saveData.playerData.currentVitality);
            SetHeartsHealthSystem(HSystem);
        }
        else
        {
            total = 20;
            HeartLogic HSystem = new HeartLogic(5);
            SetHeartsHealthSystem(HSystem);
        }
        


    }

    public void SetHeartsHealthSystem(HeartLogic h)
    {
        this.HSystem = h;
        HSystemStatic = h;

        List<HeartLogic.Heart> heartList = HSystem.getHeartList();
        int row = 0, col = 0;
        int colMax = 5;
        float rowColsize = 65f;
        
        foreach(HeartLogic.Heart heart in heartList)
        {
            Vector2 heartAnchoredPosition = new Vector2(col * rowColsize, -row * rowColsize);
            CreateHeartImage(heartAnchoredPosition).setHeartFragment(heart.getFragmentAmount());

            col++;
            if(col >= colMax)
            {
                row++;
                col = 0;
            }
        }

        HSystem.OnDamaged += HeartLogic_OnDamaded;
        HSystem.OnHealed += HeartLogic_OnHealed;
        HSystem.OnDead += HeartLogic_OnDead;
    }

    private void HeartLogic_OnDead(object sender, System.EventArgs e)
    {
        Debug.Log("Muertisimo");
    }

    private void HeartLogic_OnDamaded(object sender, System.EventArgs e)
    {
        RefreshAllHearts();
    }
    private void HeartLogic_OnHealed(object sender, System.EventArgs e)
    {
        isHealing = true;
    }

    private void RefreshAllHearts()
    {
        List<HeartLogic.Heart> heartList = HSystem.getHeartList();
        for (int i = 0; i < heartsImageList.Count; i++)
        {
            HeartImage hImage = heartsImageList[i];
            HeartLogic.Heart heart = heartList[i];
            hImage.setHeartFragment(heart.getFragmentAmount());
        }
        float alpha = 1f / total * (total - GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().getCurrentHealth());
        GameObject.FindGameObjectWithTag("Mask").GetComponent<Image>().color = new Color(1, 1, 1, alpha);
    }

    private void HealingAnimatedPeriodic()
    {
        if (isHealing)
        {
            bool fullyHealed = true;
            List<HeartLogic.Heart> heartList = HSystem.getHeartList();
            for (int i = 0; i < heartsImageList.Count; i++)
            {
                HeartImage hImage = heartsImageList[i];
                HeartLogic.Heart heart = heartList[i];
                if (hImage.GetFragmentsAmount() != heart.getFragmentAmount())
                {
                    hImage.AddHeartVisualFragment();
                    fullyHealed = false;
                    break;
                }
            }
            if (fullyHealed)
            {
                isHealing = false;
            }
        }
    }


    private HeartImage CreateHeartImage(Vector2 anchor)
    {
        GameObject heartObject = new GameObject("Heart", typeof(Image));
        heartObject.transform.SetParent(transform);
        heartObject.transform.localPosition = Vector3.zero;

        heartObject.GetComponent<RectTransform>().anchoredPosition = anchor;
        heartObject.GetComponent<RectTransform>().sizeDelta = new Vector2(30, 30);

        Image heartImageUI = heartObject.GetComponent<Image>();
        heartImageUI.sprite = heartSprites[0];


        HeartImage heartImage = new HeartImage(this,heartImageUI);
        heartsImageList.Add(heartImage);
        return heartImage;
    }

    public class HeartImage
    {
        private int fragments;
        public Image heartImage;
        private HeartVisual hvisual;
        public HeartImage(HeartVisual hvisual, Image heartImage)
        {
            this.hvisual = hvisual;
            this.heartImage = heartImage;
        }

        public void setHeartFragment(int frag)
        {
            this.fragments = frag;
            switch (frag)
            {
                case 0: heartImage.sprite = hvisual.heartSprites[0]; break;
                case 1: heartImage.sprite = hvisual.heartSprites[1]; break;
                case 2: heartImage.sprite = hvisual.heartSprites[2]; break;
                case 3: heartImage.sprite = hvisual.heartSprites[3]; break;
                case 4: heartImage.sprite = hvisual.heartSprites[4]; break;
            }
        }

        public void AddHeartVisualFragment()
        {
            setHeartFragment(fragments+1);
        }

        public int GetFragmentsAmount()
        {
            return fragments;
        }
    }



}
