using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartLogic: MonoBehaviour{

    public const int MAX_FRAGMENTS = 4;
    public event EventHandler OnHealed;
    public event EventHandler OnDamaged;
    public event EventHandler OnDead;


    private List<Heart> heartList;
    public HeartLogic(int heartAmount)
    {
        heartList = new List<Heart>();
        for (int i = 0; i < heartAmount; i++)
        {
            Heart h = new Heart(4);
            heartList.Add(h);
        }
    }

    public List<Heart> getHeartList()
    {
        return heartList;
    }

    public void Damage(int damageAmount)
    {
        for (int i = heartList.Count-1; i>= 0; i--)
        {
            Heart heart = heartList[i];
            if(damageAmount > heart.getFragmentAmount())
            {
                damageAmount -= heart.getFragmentAmount();
                heart.Damage(heart.getFragmentAmount());
            }
            else
            {
                heart.Damage(damageAmount);
                break;
            }
        }
        if (OnDamaged != null) OnDamaged(this, EventArgs.Empty);

        if (isDead())
        {
            if (OnDead != null) OnDead(this, EventArgs.Empty);
        }
    }

    public void Heal(int healAmount)
    {
        for (int i = 0; i < heartList.Count; i++)
        {
            Heart heart = heartList[i];
            int missingFragments = MAX_FRAGMENTS - heart.getFragmentAmount();
            if(healAmount > missingFragments)
            {
                healAmount -= missingFragments;
                heart.Heal(missingFragments);
            }
            else
            {
                heart.Heal(healAmount);
                break;
            }
            if (OnHealed != null) OnHealed(this, EventArgs.Empty);
        }
    }

    public bool isDead()
    {
        return heartList[0].getFragmentAmount() == 0;
    }




    public class Heart
    {
        private int fragment;
        public Heart(int frag)
        {
            this.fragment = frag;
        }

        public int getFragmentAmount()
        {
            return fragment;
        }

        public void setFragments(int frag)
        {
            this.fragment = frag;
        }

        public void Damage(int damageAmount)
        {
            if(damageAmount >= fragment)
            {
                fragment = 0;
            }
            else
            {
                fragment -= damageAmount;
            }
        }

        public void Heal(int healAmount)
        {
            if(fragment + healAmount > MAX_FRAGMENTS)
            {
                fragment = MAX_FRAGMENTS;
            }
            else
            {
                fragment += healAmount;
            }
        }


    }



}
