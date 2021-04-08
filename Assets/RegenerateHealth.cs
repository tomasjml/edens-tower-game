using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerateHealth : MonoBehaviour
{
	int total = 0;
	int hp = 0;
	int aux = 0;
	float timePass = 0f;
	public GameObject _Hearts;
    private void Update()
    {
		hp = gameObject.GetComponent<PlayerHealth>().getCurrentHealth();
		total = gameObject.GetComponent<PlayerHealth>().getTotalHealth();


		if (hp < total-1)
        {
			aux = total - hp;
			timePass = timeRegenerate();
			if(aux < total)
            {
				if(Time.time > timePass)
                {
					_Hearts.GetComponent<HeartLogic>().Heal(2);
					gameObject.GetComponent<PlayerHealth>().setHealth(2);
					Debug.Log("Vida enviada");
                }
            }
        }
    }
    float timeRegenerate()
    {
		float time = 0f;
		if (GameManager.instance == true)
		{
			switch (GameManager.instance.saveData.difficulty)
			{
				case SaveData.Difficulty.Easy:
					time = Time.time + 3f;
					break;
				case SaveData.Difficulty.Normal:
					time = Time.time + 5f;
					break;
				case SaveData.Difficulty.Hard:
					time = Time.time + 10f;
					break;
				case SaveData.Difficulty.Hell:
					return -1;
			}
			return time;
		}
		else return Time.time + 3f;
		
		
    }
}
