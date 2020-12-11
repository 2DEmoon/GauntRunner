using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	/////////////////Object///////////////////////////
	[Header("References")]
	//public TextureScroller ground;
	public Text gameOverText;
	public Text tMinusText;
	public Text restartText;
	public RawImage timeBar;
	/////////////////////////////////////////////////
	[Header("Gameplay")]
	public float gameTime = 10f;

	float totalTimeElapsed = 0f;
    // Start is called before the first frame update
    void Start()
    {
    	Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        totalTimeElapsed += Time.deltaTime;
        gameTime -= Time.deltaTime;

        Tminus();
        DrawTimeBar();
        if (gameTime < 0f)
        	GameOver();
    }
    ///////////////////////////////////////////////////
    public void AdjustTime(float amount)
    {
    	gameTime += amount;
    	if (amount < 0)
    		SlowWorldDown();
    }

    void SlowWorldDown()
    {
    	CancelInvoke();
    	Time.timeScale = 0.5f;
    	Invoke("SpeedWorldUp", 1);
    }

    void SpeedWorldUp()
    {
    	Time.timeScale = 1f;
    }

    void GameOver()
    {
    	Time.timeScale = 0f;
    	timeBar.enabled = false;
    	tMinusText.enabled = false;
    	gameOverText.enabled = true;
    	restartText.enabled = true;
    }

    public void Restart()
    {
    	SceneManager.LoadScene("Main");
    }

    void Tminus()
    {
    	if (gameTime < 5f)
    	{
	    	tMinusText.enabled = true;
	    	int timeRemaining = Mathf.CeilToInt(gameTime);
	    	tMinusText.text = timeRemaining.ToString();
	    	//////////////////Change Alpha////////////////////
	    	Color tmpColor = tMinusText.color;
	    	tmpColor.a = gameTime - timeRemaining + 1;
	    	tMinusText.color = tmpColor;
	    	/////////////////////////////////////////////
	    }
	    else
	    	tMinusText.enabled = false;
    }

    void DrawTimeBar()
    {
    	Vector3 tmpScale = timeBar.transform.localScale;
    	tmpScale.x = (gameTime < 60f)?(gameTime / 60f):1f;
    	timeBar.transform.localScale = tmpScale;

    	Vector4 tmpColor = timeBar.color;
    	tmpColor = (gameTime < 5f)?(new Vector4(164, 0, 0, 100)):(new Vector4(255, 255, 255, 145));
    	timeBar.color = tmpColor;
    	//Debug.Log("========================="+timeBar.color.r+"  "+timeBar.color.g+"  "+timeBar.color.b+"  "+timeBar.color.a+"  ");
    }
}
